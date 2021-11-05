using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

using TesserNet;
using TradingPostDataExtractor.PerformanceProfiling;



namespace TradingPostDataExtractor
{
    public class ImageParser : IDisposable
    {
        private const string DebugImagesFolder = "images";

        private double _sizeModifier = 1;

        private ITesseract _tesseractForNumbers;
        private ITesseract _tesseractForText;

        public string DebugFilePath { get; private set; }

        public async Task<List<RawPriceData>> Parse(string language, Image image)
        {

            await InitializeTesseract(language);
            using var adjustedImage = image.AdjustSize(out var sizeModifier);
            _sizeModifier = sizeModifier;
            var result = Enumerable.Range(0, 9).Select(i => new RawPriceData
            {
                ItemName = GetItemName(adjustedImage, i),
                Price = GetItemPrice(adjustedImage, i),
                Availability = GetAvailability(adjustedImage, i)
            }).ToList();

            var debugImagesFolder = Path.Combine(Constants.DebugFolder, DebugImagesFolder);
            if (!Directory.Exists(debugImagesFolder))
            {
                Directory.CreateDirectory(debugImagesFolder);
            }

            DebugFilePath = Path.Combine(debugImagesFolder, $"{DateTime.UtcNow:yyyyMMddHHmmss}.png");
            using var debugImage = adjustedImage.ConvertToBlackAndWhite();
            debugImage.QuickNegative();
            debugImage.Save(DebugFilePath, ImageFormat.Png);

            return result;
        }

        private async Task InitializeTesseract(string language)
        {
            _tesseractForNumbers = await TesseractFactory.CreateAsync(null, true);
            _tesseractForText = await TesseractFactory.CreateAsync(language, false);
        }

        private string GetItemName(Image image, int row)
        {
            var result = GetTextFromRectangle(
                _tesseractForText,
                image,
                new Rectangle(ModifiedSize(689),
                    GetRowY(row),
                    ModifiedSize(275),
                    ModifiedSize(76)),
                true, true, false);
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
                    ModifiedSize(160),
                    ModifiedSize(76)),
                true, true, false);
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
                true, true, false);
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
            bool blackAndWhite)
        {

            using var croppedImage = image.CreateCrop(rect);

            Image adjustedImage = null;
            Image blackandwhiteImage = null;

            
            if (adjustImage)
            {
                adjustedImage = croppedImage.AdjustImage();
            }

            if (negative)
            {
                (adjustedImage ?? croppedImage).Negative();
            }

            if (blackAndWhite)
            {
                blackandwhiteImage = (adjustedImage ?? croppedImage).ConvertToBlackAndWhite();
            }
            
            var finalImage = blackandwhiteImage ??  adjustedImage ?? croppedImage;

#if DEBUG
            finalImage.Save(Path.Combine("megadebug", $"{rect.X}-{rect.Y}.png"), ImageFormat.Png);
#endif

            PerformanceProfiler.Current?.Start("ImageParser.Ocr");
            var result = tesseract.Read(finalImage).Trim();
            PerformanceProfiler.Current?.Stop("ImageParser.Ocr");

            adjustedImage?.Dispose();
            blackandwhiteImage?.Dispose();

            image.DrawRect(rect);
            return result;
        }

        //private void DrawRect(Image<Rgba32> image, Rectangle rectangle)
        //{
        //    PerformanceProfiler.Current?.Start("ImageParser.DrawRect");
        //    var lines = new List<PointF>();
        //    lines.Add(new PointF(rectangle.Left, rectangle.Top));
        //    lines.Add(new PointF(rectangle.Left, rectangle.Bottom));
        //    image.Mutate(i => i.DrawLines(Color.DarkBlue, 1f, lines.ToArray()));
        //    lines.Clear();
        //    lines.Add(new PointF(rectangle.Right, rectangle.Top));
        //    lines.Add(new PointF(rectangle.Right, rectangle.Bottom));
        //    image.Mutate(i => i.DrawLines(Color.DarkBlue, 1f, lines.ToArray()));
        //    lines.Clear();
        //    lines.Add(new PointF(rectangle.Left, rectangle.Top));
        //    lines.Add(new PointF(rectangle.Right, rectangle.Top));
        //    image.Mutate(i => i.DrawLines(Color.DarkBlue, 1f, lines.ToArray()));
        //    lines.Clear();
        //    lines.Add(new PointF(rectangle.Left, rectangle.Bottom));
        //    lines.Add(new PointF(rectangle.Right, rectangle.Bottom));
        //    image.Mutate(i => i.DrawLines(Color.DarkBlue, 1f, lines.ToArray()));
        //    PerformanceProfiler.Current?.Stop("ImageParser.DrawRect");
        //}

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
