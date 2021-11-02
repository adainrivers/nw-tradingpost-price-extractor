using System;
using System.Collections.Generic;
using System.Linq;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using TesserNet;
using Rectangle = SixLabors.ImageSharp.Rectangle;


namespace TradingPostDataExtractor
{
    public class ImageParser : IDisposable
    {
        private readonly ITesseract _tesseractForNumbers = new TesseractPool(new TesseractOptions
        {
            PageSegmentation = PageSegmentation.Line,
            Numeric = true,
            Whitelist = "0123456789,.",
        });
        private readonly ITesseract _tesseractForText = new TesseractPool(new TesseractOptions
        {
            PageSegmentation = PageSegmentation.Line,
            Numeric = false,
            //Whitelist = "[]0123456789 ,.",
        });

        public List<RawPriceData> Parse(Image<Rgba32> image)
        {
            return Enumerable.Range(0, 9).Select(i => new RawPriceData
            {
                ItemName = GetItemName(image, i),
                Price = GetItemPrice(image, i),
                Availability = GetAvailability(image, i)
            }).ToList();


        }

        private string GetItemName(Image<Rgba32> image, int row)
        {
            return GetTextFromRectangle(_tesseractForText, image, new Rectangle(689, GetRowY(row), 275, 76));
        }

        private string GetItemPrice(Image<Rgba32> image, int row)
        {
            return GetTextFromRectangle(_tesseractForNumbers, image, new Rectangle(964, GetRowY(row), 160, 76));
        }

        private string GetAvailability(Image<Rgba32> image, int row)
        {
            return GetTextFromRectangle(_tesseractForNumbers, image, new Rectangle(1510, GetRowY(row), 60, 76));
        }

        private static int GetRowY(int row)
        {
            return 319 + (row * 77);
        }

        private static string GetTextFromRectangle(ITesseract tesseract, Image<Rgba32> image, Rectangle rect)
        {
            using var crop = GetCrop(image, rect);

            return tesseract.Read(crop).Trim();
        }


        private static Image<Rgba32> GetCrop(Image<Rgba32> image, Rectangle rect)
        {
            var clone = image.Clone();
            clone.Mutate(i => i.Crop(rect).Invert());
            return clone;
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

            _tesseractForNumbers?.Dispose();
            _tesseractForText?.Dispose();

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
