using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using Parser.PerformanceProfiling;

namespace Parser
{
    public static class ImageExtensions
    {
        public static Image AdjustImage(this Image image, float brightness = 1.0f, float contrast = 3.0f, float gamma = 5.0f)
        {
            PerformanceProfiler.Current?.Start("Image.AdjustGamma");

            var adjustedBrightness = brightness - 1.0f;

            // create matrix that will brighten and contrast the image
            float[][] ptsArray ={
                new[] {contrast, 0, 0, 0, 0}, // scale red
                new[] {0, contrast, 0, 0, 0}, // scale green
                new[] {0, 0, contrast, 0, 0}, // scale blue
                new[] {0, 0, 0, 1.0f, 0}, // don't scale alpha
                new[] {adjustedBrightness, adjustedBrightness, adjustedBrightness, 0, 1}};

            var imageAttributes = new ImageAttributes();
            imageAttributes.ClearColorMatrix();
            imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
            imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);

            var newImage = new Bitmap(image.Width, image.Height);
            var g = Graphics.FromImage(newImage);
            g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height)
                , 0, 0, image.Width, image.Height,
                GraphicsUnit.Pixel, imageAttributes);
            PerformanceProfiler.Current?.Stop("Image.AdjustGamma");

            return newImage;
        }

        public static Image ConvertToBlackAndWhite(this Image image)
        {
            PerformanceProfiler.Current?.Start("Image.ConvertToBlackAndWhite");

            var grayMatrix = new[]
            {
                new[] {0.299f, 0.299f, 0.299f, 0f, 0f},
                new[] {0.587f, 0.587f, 0.587f, 0f, 0f},
                new[] {0.114f, 0.114f, 0.114f, 0f, 0f},
                new[] {0f, 0f, 0f, 1f, 0f},
                new[] {0f, 0f, 0f, 0f, 1f}
            };

            var ia = new ImageAttributes();
            ia.SetColorMatrix(new ColorMatrix(grayMatrix));
            ia.SetThreshold(0.2f); // Change this threshold as needed
            var rc = new Rectangle(0, 0, image.Width, image.Height);
            var newImage = new Bitmap(image.Width, image.Height);
            using var gr = Graphics.FromImage(newImage);
            gr.DrawImage(image, rc, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, ia);
            PerformanceProfiler.Current?.Stop("Image.ConvertToBlackAndWhite");
            return newImage;
        }

        public static Image CreateCrop(this Image image, Rectangle rectangle)
        {
            PerformanceProfiler.Current?.Start("Image.CreateCrop");
            var nb = new Bitmap(rectangle.Width, rectangle.Height);
            using var g = Graphics.FromImage(nb);
            g.DrawImage(image, -rectangle.X, -rectangle.Y);
            PerformanceProfiler.Current?.Stop("Image.CreateCrop");
            return nb;
        }

        public static Image Resize(this Image image, int newWidth, int newHeight)
        {
            PerformanceProfiler.Current?.Start("Image.Resize");

            var resizedImage = new Bitmap(newWidth, newHeight);
            using var thumbGraph = Graphics.FromImage(resizedImage);
            thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
            thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
            thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
            var imageRectangle = new Rectangle(0, 0, newWidth, newHeight);

            thumbGraph.DrawImage(image, imageRectangle);
            PerformanceProfiler.Current?.Stop("Image.Resize");

            return resizedImage;
        }

        public static Image QuickNegative(this Image image)
        {
            PerformanceProfiler.Current?.Start("Image.QuickNegative");
            var colorMatrix = new ColorMatrix(new[]
            {
                new float[] {-1, 0, 0, 0, 0},
                new float[] {0, -1, 0, 0, 0},
                new float[] {0, 0, -1, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {1, 1, 1, 0, 1}
            });

            var attributes = new ImageAttributes();

            attributes.SetColorMatrix(colorMatrix);

            using var g = Graphics.FromImage(image);
            g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height),
                0, 0, image.Width, image.Height, GraphicsUnit.Pixel, attributes);
            image.Save("temp.bmp", ImageFormat.Bmp);
            var result = Image.FromFile("temp.bmp", false);
            PerformanceProfiler.Current?.Stop("Image.QuickNegative");
            return result;
        }


        public static Image AdjustSize(this Image image, out double sizeModifier)
        {
            PerformanceProfiler.Current?.Start("Image.AdjustSize");

            const int baseWidth = 1920;
            const int baseHeight = 1080;
            const double baseRatio = 0.5625d;

            sizeModifier = 1;
            if (image.Width == baseWidth && image.Height == baseHeight)
            {
                return (Image)image.Clone();
            }

            sizeModifier = (double)image.Height / baseHeight;

            var newImage = image;
            
            // Wider screen
            if ((double)image.Height / image.Width - baseRatio < 0)
            {
                var cropWidth = ModifiedSize(baseWidth, sizeModifier);
                var cropHeight = image.Height;
                var rect = new Rectangle((image.Width - cropWidth) / 2, 0, cropWidth, cropHeight);
                newImage = image.CreateCrop(rect);
            }
            PerformanceProfiler.Current?.Stop("Image.AdjustSize");
  return newImage;
        }

        public static void DrawRect(this Image image, Rectangle rectangle)
        {
            PerformanceProfiler.Current?.Start("Image.DrawRect");
            using var g = Graphics.FromImage(image);
            g.DrawRectangle(new Pen(Color.White, 1), rectangle);
            PerformanceProfiler.Current?.Stop("Image.DrawRect");

        }

        private static int ModifiedSize(int imageSize, double sizeModifier)
        {
            return (int)(imageSize * sizeModifier);
        }
    }
}
