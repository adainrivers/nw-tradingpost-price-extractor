using System.IO;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Advanced;
using SixLabors.ImageSharp.Formats;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.PixelFormats;

namespace TradingPostDataExtractor
{
    public static class ImageSharpExtensions
    {
        public static byte[] ToArray<TPixel>(this Image<TPixel> image, IImageFormat imageFormat) where TPixel : unmanaged, IPixel<TPixel>
        {
            using var memoryStream = new MemoryStream();
            var imageEncoder = image.GetConfiguration().ImageFormatsManager.FindEncoder(imageFormat);
            image.Save(memoryStream, imageEncoder);
            return memoryStream.ToArray();
        }

        public static System.Drawing.Bitmap ToBitmap<TPixel>(this Image<TPixel> image) where TPixel : unmanaged, IPixel<TPixel>
        {
            using var memoryStream = new MemoryStream();
            var imageEncoder = image.GetConfiguration().ImageFormatsManager.FindEncoder(PngFormat.Instance);
            image.Save(memoryStream, imageEncoder);

            memoryStream.Seek(0, SeekOrigin.Begin);

            return new System.Drawing.Bitmap(memoryStream);
        }

        public static Image<TPixel> ToImageSharpImage<TPixel>(this System.Drawing.Bitmap bitmap) where TPixel : unmanaged, IPixel<TPixel>
        {
            using var memoryStream = new MemoryStream();
            bitmap.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

            memoryStream.Seek(0, SeekOrigin.Begin);

            return Image.Load<TPixel>(memoryStream);
        }
    }
}
