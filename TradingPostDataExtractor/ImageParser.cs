using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Drawing.Processing;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;
using SixLabors.ImageSharp.Processing;
using TesserNet;
using TradingPostDataExtractor.PerformanceProfiling;
using Color = SixLabors.ImageSharp.Color;
using Image = System.Drawing.Image;
using PointF = SixLabors.ImageSharp.PointF;
using Rectangle = SixLabors.ImageSharp.Rectangle;


namespace TradingPostDataExtractor
{
    public class ImageParser : IDisposable
    {
        private const string DebugImagesFolder = "images";

        private double _sizeModifier = 1;

        private ITesseract _tesseractForNumbers ;
        private ITesseract _tesseractForText;
        private static readonly BmpDecoder BmpDecoder = new();

        public string DebugFilePath { get; private set; }

        public async Task<List<RawPriceData>> Parse(string language, Image image)
        {

            await InitializeTesseract(language);
            AdjustGamma(image);
            var imageSharpImage = ToImageSharp(image);
            PrepareImage(imageSharpImage);
            var result =  Enumerable.Range(0, 9).Select(i => new RawPriceData
            {
                ItemName = GetItemName(imageSharpImage, i),
                Price = GetItemPrice(imageSharpImage, i),
                Availability = GetAvailability(imageSharpImage, i)
            }).ToList();

            var debugImagesFolder = Path.Combine(Constants.DebugFolder, DebugImagesFolder);
            if (!Directory.Exists(debugImagesFolder))
            {
                Directory.CreateDirectory(debugImagesFolder);
            }

            DebugFilePath = Path.Combine(debugImagesFolder, $"{DateTime.UtcNow:yyyyMMddHHmmss}.png");
            await imageSharpImage.SaveAsync(DebugFilePath, new PngEncoder());

            return result;
        }

        private static Image<Rgba32> ToImageSharp(Image bmp)
        {
            PerformanceProfiler.Current?.Start("ImageParser.ToImageSharp");
            if (bmp is null)
            {
                throw new ArgumentNullException(nameof(bmp));
            }

            using var ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Bmp);
            ms.Position = 0;
            var result = SixLabors.ImageSharp.Image.Load<Rgba32>(ms, BmpDecoder);
            PerformanceProfiler.Current?.Stop("ImageParser.ToImageSharp");
            return result;
        }

        private Image AdjustGamma(Image image)
        {
            PerformanceProfiler.Current?.Start("ImageParser.AdjustGamma");
            //var adjustedImage = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb); ;
            var brightness = 1.0f; 
            var contrast = 2.0f;
            var gamma = 5.0f; 

            var adjustedBrightness = brightness - 1.0f;
            // create matrix that will brighten and contrast the image
            float[][] ptsArray ={
                new float[] {contrast, 0, 0, 0, 0}, // scale red
                new float[] {0, contrast, 0, 0, 0}, // scale green
                new float[] {0, 0, contrast, 0, 0}, // scale blue
                new float[] {0, 0, 0, 1.0f, 0}, // don't scale alpha
                new float[] {adjustedBrightness, adjustedBrightness, adjustedBrightness, 0, 1}};

            var imageAttributes = new ImageAttributes();
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(new System.Drawing.Imaging.ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);
            var g = Graphics.FromImage(image);
            g.DrawImage(image, new System.Drawing.Rectangle(0, 0, image.Width, image.Height)
                , 0, 0, image.Width, image.Height,
                GraphicsUnit.Pixel, imageAttributes);

            //ConvertToBlackAndWhite(image);

            PerformanceProfiler.Current?.Stop("ImageParser.AdjustGamma");
            return image;
        }

        private static void ConvertToBlackAndWhite(Image image)
        {
            using var gr = Graphics.FromImage(image);
            var grayMatrix = new[]
            {
                new[] {0.299f, 0.299f, 0.299f, 0f, 0f},
                new[] {0.587f, 0.587f, 0.587f, 0f, 0f},
                new[] {0.114f, 0.114f, 0.114f, 0f, 0f},
                new[] {0f, 0f, 0f, 1f, 0f},
                new[] {0f, 0f, 0f, 0f, 1f}
            };

            var ia = new ImageAttributes();
            ia.SetColorMatrix(new System.Drawing.Imaging.ColorMatrix(grayMatrix));
            ia.SetThreshold(0.2f); // Change this threshold as needed
            var rc = new System.Drawing.Rectangle(0, 0, image.Width, image.Height);
            gr.DrawImage(image, rc, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ia);
        }

        private async Task InitializeTesseract(string language)
        {
            _tesseractForNumbers = await TesseractFactory.CreateAsync(null, true);
            _tesseractForText = await TesseractFactory.CreateAsync(language, false);
        }

        private void PrepareImage(Image<Rgba32> image)
        {
            PerformanceProfiler.Current?.Start("ImageParser.PrepareImage");

            image.Mutate(i=>i.Invert());
            const int baseWidth = 1920;
            const int baseHeight = 1080;
            const double baseRatio = 0.5625d;

            if (image.Width == baseWidth && image.Height == baseHeight)
            {
                return;
            }

            _sizeModifier = (double)image.Height / baseHeight;

            // Wider screen
            if ((double)image.Height / image.Width - baseRatio < 0)
            {
                var cropWidth = ModifiedSize(baseWidth);
                var cropHeight = image.Height;
                var rect = new Rectangle((image.Width - cropWidth) / 2, 0, cropWidth, cropHeight);
                image.Mutate(i=>i.Crop(rect));
            }
            PerformanceProfiler.Current?.Stop("ImageParser.PrepareImage");

        }


        private string GetItemName(Image<Rgba32> image, int row)
        {
            var result = GetTextFromRectangle(_tesseractForText, image, new Rectangle(ModifiedSize(689), GetRowY(row), ModifiedSize(275), ModifiedSize(76)));
            result = result.Replace("\n", " ");
            return result;
        }

        private string GetItemPrice(Image<Rgba32> image, int row)
        {
            return GetTextFromRectangle(_tesseractForNumbers, image, new Rectangle(ModifiedSize(964), GetRowY(row), ModifiedSize(160), ModifiedSize(76)));
        }

        private string GetAvailability(Image<Rgba32> image, int row)
        {
            return GetTextFromRectangle(_tesseractForNumbers, image, new Rectangle(ModifiedSize(1510), GetRowY(row), ModifiedSize(60), ModifiedSize(76)));
        }

        private int GetRowY(int row)
        {
            return ModifiedSize(319 + (row * 77));
        }

        private string GetTextFromRectangle(ITesseract tesseract, Image<Rgba32> image, Rectangle rect)
        {
            PerformanceProfiler.Current?.Start("ImageParser.Ocr");
            var result =  tesseract.Read(image, rect).Trim();
            PerformanceProfiler.Current?.Stop("ImageParser.Ocr");

            DrawRect(image, rect);
            return result;
        }

        private void DrawRect(Image<Rgba32> image, Rectangle rectangle)
        {
            PerformanceProfiler.Current?.Start("ImageParser.DrawRect");
            var lines = new List<PointF>();
            lines.Add(new PointF(rectangle.Left, rectangle.Top));
            lines.Add(new PointF(rectangle.Left, rectangle.Bottom));
            image.Mutate(i => i.DrawLines(Color.DarkBlue, 1f, lines.ToArray()));
            lines.Clear();
            lines.Add(new PointF(rectangle.Right, rectangle.Top));
            lines.Add(new PointF(rectangle.Right, rectangle.Bottom));
            image.Mutate(i => i.DrawLines(Color.DarkBlue, 1f, lines.ToArray()));
            lines.Clear();
            lines.Add(new PointF(rectangle.Left, rectangle.Top));
            lines.Add(new PointF(rectangle.Right, rectangle.Top));
            image.Mutate(i => i.DrawLines(Color.DarkBlue, 1f, lines.ToArray()));
            lines.Clear();
            lines.Add(new PointF(rectangle.Left, rectangle.Bottom));
            lines.Add(new PointF(rectangle.Right, rectangle.Bottom));
            image.Mutate(i => i.DrawLines(Color.DarkBlue, 1f, lines.ToArray()));
            PerformanceProfiler.Current?.Stop("ImageParser.DrawRect");
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
