using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using TesserNet;
using TradingPostDataExtractor.Models;
using TradingPostDataExtractor.PerformanceProfiling;



namespace TradingPostDataExtractor
{
    public class ImageParser : IDisposable
    {
        private readonly bool _highPerformanceMode;
        private double _sizeModifier = 1;

        private ITesseract _tesseractForNumbers;
        private ITesseract _tesseractForText;

        public const string DebugFilePath = "processed-image.png";

        public ImageParser(bool highPerformanceMode)
        {
            _highPerformanceMode = highPerformanceMode;
        }

        public async Task<List<RawPriceData>> Parse(string language, Image image)
        {

            await InitializeTesseract(language);
            using var adjustedImage = image.AdjustSize(out var sizeModifier);
            _sizeModifier = sizeModifier;
            var result = Enumerable.Range(0, 9).Select(i => new RawPriceData
            {
                ItemName = GetItemName(adjustedImage, i),
                Price = GetItemPrice(adjustedImage, i),
                GearScore = GetGearScore(adjustedImage, i),
                Tier = GetTier(adjustedImage, i),
                Availability = GetAvailability(adjustedImage, i)
            }).ToList();

            if (!_highPerformanceMode)
            {
                using var debugImage = adjustedImage.ConvertToBlackAndWhite();
                debugImage.Save(DebugFilePath, ImageFormat.Png);
            }

            return result;
        }

        private async Task InitializeTesseract(string language)
        {
            _tesseractForNumbers = await TesseractFactory.CreateAsync(null, true);
            _tesseractForText = await TesseractFactory.CreateAsync(language, false);
        }

        private string GetItemName(Image image, int row)
        {
            _tesseractForText.Options.PageSegmentation = PageSegmentation.SegmentationOsd;
            _tesseractForText.Options.Whitelist = "";

            var result = GetTextFromRectangle(
                _tesseractForText,
                image,
                new Rectangle(ModifiedSize(689),
                    GetRowY(row),
                    ModifiedSize(275),
                    ModifiedSize(76)),
                true, true, false, false);
            result = result.Replace("\n", " ");
            return result;
        }


        private string GetItemPrice(Image image, int row)
        {
            return GetTextFromRectangle(
                _tesseractForNumbers,
                image,
                new Rectangle(
                    ModifiedSize(964),
                    GetRowY(row),
                    ModifiedSize(146),
                    ModifiedSize(76)),
                true, true, false, false).Replace(" ","");
        }


        private string GetTier(Image image, int row)
        {
            _tesseractForText.Options.PageSegmentation = PageSegmentation.Raw;
            _tesseractForText.Options.Whitelist = "IV";
            return GetTextFromRectangle(
                _tesseractForText,
                image,
                new Rectangle(
                    ModifiedSize(1113),
                    GetRowY(row),
                    ModifiedSize(55),
                    ModifiedSize(76)),
                true, true, false, false);
        }

        private string GetGearScore(Image image, int row)
        {
            return GetTextFromRectangle(
                _tesseractForNumbers,
                image,
                new Rectangle(
                    ModifiedSize(1167),
                    GetRowY(row),
                    ModifiedSize(65),
                    ModifiedSize(76)),
                false, true, false, false);
        }

        private string GetAvailability(Image image, int row)
        {
            return GetTextFromRectangle(
                _tesseractForNumbers,
                image,
                new Rectangle(
                    ModifiedSize(1510),
                    GetRowY(row),
                    ModifiedSize(60),
                    ModifiedSize(76)),
                true, true, false, false, 1, 3, 5);
        }

        private int GetRowY(int row)
        {
            return ModifiedSize(319 + (row * 77));
        }

        private string GetTextFromRectangle
            (ITesseract tesseract,
            Image image,
            Rectangle rect,
            bool adjustImage,
            bool negative,
            bool blackAndWhite,
            bool resize,
            float brightness = 1,
            float contrast = 3,
            float gamma = 5
            )
        {

            using var croppedImage = image.CreateCrop(rect);

            Image resizedImage = null;
            Image adjustedImage = null;
            Image negativeImage = null;
            Image blackandwhiteImage = null;

            if (resize)
            {
                resizedImage = croppedImage.Resize(rect.Width * 4, rect.Height * 4);
            }

            if (adjustImage)
            {
                adjustedImage = (resizedImage ?? croppedImage).AdjustImage(brightness, contrast, gamma);
            }

            if (negative)
            {
                negativeImage = (adjustedImage ?? resizedImage ?? croppedImage).QuickNegative();
            }

            if (blackAndWhite)
            {
                blackandwhiteImage = (negativeImage ?? adjustedImage ?? resizedImage ?? croppedImage).ConvertToBlackAndWhite();
            }

            var finalImage = blackandwhiteImage ?? negativeImage ?? adjustedImage ?? resizedImage ?? croppedImage;

#if DEBUG
            if (!_highPerformanceMode)
            {
                if (!Directory.Exists("megadebug"))
                {
                    Directory.CreateDirectory("megadebug");
                }

                finalImage.Save(Path.Combine("megadebug", $"{rect.X}-{rect.Y}.png"), ImageFormat.Png);
            }
#endif

            PerformanceProfiler.Current?.Start("ImageParser.Ocr");
            var result = tesseract.Read(finalImage).Trim();
            PerformanceProfiler.Current?.Stop("ImageParser.Ocr");

            resizedImage?.Dispose();
            adjustedImage?.Dispose();
            negativeImage?.Dispose();
            blackandwhiteImage?.Dispose();
            if (!_highPerformanceMode)
            {
                image.DrawRect(rect);
            }

            return result;
        }

        private int ModifiedSize(int imageSize)
        {
            return (int)(imageSize * _sizeModifier);
        }

        ~ImageParser()
        {
            Dispose(false);
        }

        #region IDisposable Support
        private bool _disposedValue;

        protected virtual void Dispose(bool disposing)
        {
            if (_disposedValue)
            {
                return;
            }

            _disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion


    }
}
