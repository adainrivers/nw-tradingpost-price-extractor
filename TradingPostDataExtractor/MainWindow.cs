using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Newtonsoft.Json;
using NonInvasiveKeyboardHookLibrary;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Formats.Bmp;
using SixLabors.ImageSharp.PixelFormats;
using Color = System.Drawing.Color;
using Image = System.Drawing.Image;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;

namespace TradingPostDataExtractor
{
    public partial class MainForm : Form
    {
        private const string NewWorldRunning = "Running";
        private const string NewWorldNotRunning = "Not Running";

        private static readonly BmpDecoder BmpDecoder = new ();
        private List<PriceData> _prices = new();
        private List<RawPriceData> _invalidPrices = new();
        private List<RawPriceData> _rawPrices = new();
        private static readonly RawPriceDataParser PriceDataParser = new();

        private string _newWorldGameWindowDimensions;

        private readonly KeyboardHookManager _keyboardHooks = new();

        public MainForm()
        {
            InitializeComponent();
            SetNewWorldProcess();
        }

        private static Process _newWorldProcess;

        public static void SetNewWorldProcess()
        {
            _newWorldProcess = Process.GetProcesses().FirstOrDefault(p => p.MainWindowTitle == "New World" && !p.HasExited);
        }

        public void UpdateStatus()
        {
            if (_newWorldProcess == null || _newWorldProcess.HasExited)
            {
                NewWorldStatus.Text = NewWorldNotRunning;
                NewWorldStatus.ForeColor = Color.Red;
                TakeScreenshotButton.Enabled = false;
                TimerProcessRefresher.Enabled = true;
                _keyboardHooks.Stop();
            }
            else
            {
                NewWorldStatus.Text = NewWorldRunning;
                NewWorldStatus.ForeColor = Color.Green;
                TakeScreenshotButton.Enabled = true;
                TimerProcessRefresher.Enabled = false;
                _keyboardHooks.Start();
            }

            ExportPricesButton.Enabled = _prices.Count > 0;
            CapturedPricesCount.Text = _prices.Count.ToString();
            TotalItems.Text = _prices.Sum(p => p.Availability).ToString();
        }

        private void OnTakeScreenshotButton_Click(object sender, EventArgs e)
        {
            TakeScreenshot();
        }

        private void TakeScreenshot()
        {
            SafeInvoke(() =>
            {
                _keyboardHooks.Stop();
                var currentText = TakeScreenshotButton.Text;
                TakeScreenshotButton.Text = "Processing";
                TakeScreenshotButton.Enabled = false;
                using var capturedImage = CaptureApplication();
                if (capturedImage == null)
                {
                    return;
                }
                SetPreviewImage(capturedImage);
                ParseImage(capturedImage);
                TakeScreenshotButton.Text = currentText;
                TakeScreenshotButton.Enabled = true;
                _keyboardHooks.Start();
            });
        }

        private Image CaptureApplication()
        {
            var rect = new User32.Rect();
            User32.GetWindowRect(_newWorldProcess.MainWindowHandle, ref rect);

            var width = rect.right - rect.left;
            var height = rect.bottom - rect.top;


            _newWorldGameWindowDimensions = $"{width}x{height}";

            if (width != 1920 && height != 1080)
            {
                MessageBox.Show(
                    $"This application only works if New World is running in Full-Screen mode at 1920x1080 resolution. Your's is {width}x{height}. I can see what I can do if you can send a screenshot of the Trading Post (with some items visible) to me on Discord. Thank you, and sorry.",
                    "Error");
                return null;
            }

            var bmp = new Bitmap(width, height, PixelFormat.Format32bppArgb);
            using var graphics = Graphics.FromImage(bmp);
            graphics.CopyFromScreen(rect.left, rect.top, 0, 0, new Size(width, height), CopyPixelOperation.SourceCopy);
            return bmp;
        }

        private void SafeInvoke(Action act)
        {
            try
            {
                Invoke(act);
            }
            catch (InvalidOperationException)
            {
            }
        }

        private static class User32
        {
            [StructLayout(LayoutKind.Sequential)]
            public readonly struct Rect
            {
                public readonly int left;
                public readonly int top;
                public readonly int right;
                public readonly int bottom;
            }

            [DllImport("user32.dll")]
            public static extern IntPtr GetWindowRect(IntPtr hWnd, ref Rect rect);
        }

        private void ParseImage(Image image)
        {
            using var imageParser = new ImageParser();
            var result = imageParser.Parse(ToImageSharp(image));
            _rawPrices.AddRange(result);
            result.ForEach(r =>
            {
                if (PriceDataParser.TryParse(r, out var priceData))
                {
                    _prices.Add(priceData);
                }
                else
                {
                    _invalidPrices.Add(r);
                }
            });

        }

        private void SetPreviewImage(Image image)
        {
            Image clonedImg = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb);
            using var copy = Graphics.FromImage(clonedImg);
            copy.DrawImage(image, 0, 0);
            ImagePreview.Image = clonedImg;
        }

        public static Image<Rgba32> ToImageSharp(Image bmp)
        {
            if (bmp is null)
            {
                throw new ArgumentNullException(nameof(bmp));
            }

            using var ms = new MemoryStream();
            bmp.Save(ms, ImageFormat.Bmp);
            ms.Position = 0;
            return SixLabors.ImageSharp.Image.Load<Rgba32>(ms, BmpDecoder);
        }

        private void TimerNewWorldStatus_Tick(object sender, EventArgs e)
        {
            UpdateStatus();
        }

        private void TimerProcessRefresher_Tick(object sender, EventArgs e)
        {
            SetNewWorldProcess();
        }

        private void ExportPricesButton_Click(object sender, EventArgs e)
        {
            var saveFileDialog1 = new SaveFileDialog
            {
                Filter = "Json File|*.json", 
                Title = "Export Prices"
            };
            saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            var fileName = saveFileDialog1.FileName;
            if (!string.IsNullOrEmpty(fileName))
            {
                File.WriteAllText(fileName,JsonConvert.SerializeObject(_prices,Formatting.Indented),Encoding.UTF8);

                var debugInfo = new DebugInfo
                {
                    NewWorldGameWindowDimensions = _newWorldGameWindowDimensions,
                    RawPriceData = _rawPrices,
                    InvalidPriceData = _invalidPrices
                };

                File.WriteAllText($"DebugInfo-{DateTime.UtcNow:yyyyMMddHHmmss}.json", JsonConvert.SerializeObject(debugInfo, Formatting.Indented));
                _prices = new List<PriceData>();
                _rawPrices = new List<RawPriceData>();
                _invalidPrices = new List<RawPriceData>();
            }
        }

        private void RegisterHotKeys()
        {
            ////_khm.RegisterHotkey(NonInvasiveKeyboardHookLibrary.ModifierKeys.Control, 0x48, TakeScreenshot);
            _keyboardHooks.Start();
            //_keyboardHooks.RegisterHotkey(0, 0x7B, TakeScreenshot);
            _keyboardHooks.RegisterHotkey(0, 0x7A, TakeScreenshot);
        }



        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            RegisterHotKeys();
            LoadConfiguration(this);
        }

        private const string ConfigurationFile = "config.json";

        public static void SaveConfiguration(Form form)
        {
            var configuration = new Configuration
            {
                WindowLocation = form.Location,
                WindowState = form.WindowState
            };

            File.WriteAllText(ConfigurationFile, JsonConvert.SerializeObject(configuration));
        }

        public static void LoadConfiguration(Form form)
        {
            if (!File.Exists(ConfigurationFile))
            {
                return;
            }

            var configuration = JsonConvert.DeserializeObject<Configuration>(File.ReadAllText(ConfigurationFile));
            if (configuration != null)
            {
                if (configuration.WindowState.HasValue)
                {
                    form.WindowState = configuration.WindowState.Value;
                }

                if (configuration.WindowLocation.HasValue)
                {
                    form.Location = configuration.WindowLocation.Value;
                }
            }
        }

        public class Configuration
        {
            public FormWindowState? WindowState { get; set; }

            public Point? WindowLocation { get; set; }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfiguration(this);
            _keyboardHooks?.UnregisterAll();
            _keyboardHooks?.Stop();
        }

        private void MainForm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
        }
    }
}
