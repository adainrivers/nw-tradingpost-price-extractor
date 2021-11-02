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
        private static readonly RawPriceDataParser PriceDataParser = new();

        private readonly KeyboardHookManager khm = new();

        public MainForm()
        {
            InitializeComponent();
            khm.Start();
            SetupHotkeys();
            SetNewWorldProcess();
        }

        public static Process NewWorldProcess;

        public void SetNewWorldProcess()
        {
            NewWorldProcess = Process.GetProcesses().FirstOrDefault(p => p.MainWindowTitle == "New World" && !p.HasExited);
        }

        public void UpdateStatus()
        {
            if (NewWorldProcess == null || NewWorldProcess.HasExited)
            {
                NewWorldStatus.Text = NewWorldNotRunning;
                NewWorldStatus.ForeColor = Color.Red;
                TakeScreenshotButton.Enabled = false;
                TimerProcessRefresher.Enabled = true;
            }
            else
            {
                NewWorldStatus.Text = NewWorldRunning;
                NewWorldStatus.ForeColor = Color.Green;
                TakeScreenshotButton.Enabled = true;
                TimerProcessRefresher.Enabled = false;
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
                var currentText = TakeScreenshotButton.Text;
                TakeScreenshotButton.Text = "Processing";
                TakeScreenshotButton.Enabled = false;
                using var capturedImage = CaptureApplication();
                SetPreviewImage(capturedImage);
                ParseImage(capturedImage);
                TakeScreenshotButton.Text = currentText;
                TakeScreenshotButton.Enabled = true;
            });
        }

        private Image CaptureApplication()
        {
            var rect = new User32.Rect();
            User32.GetWindowRect(NewWorldProcess.MainWindowHandle, ref rect);

            var width = rect.right - rect.left;
            var height = rect.bottom - rect.top;

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
                _prices = new List<PriceData>();
                _invalidPrices = new List<RawPriceData>();
            }
        }

        private void SetupHotkeys()
        {
            khm.RegisterHotkey(NonInvasiveKeyboardHookLibrary.ModifierKeys.Control, 0x48, TakeScreenshot);
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            khm.UnregisterAll();
            khm.Stop();
            Environment.Exit(0);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LoadWindowState(this);
        }

        private const string WindowStateFile = "windowstate.json";

        public static void SaveWindowState(Form form)
        {
            var state = new WindowStateInfo
            {
                WindowLocation = form.Location,
                WindowState = form.WindowState
            };

            File.WriteAllText(WindowStateFile, JsonConvert.SerializeObject(state));
        }

        public static void LoadWindowState(Form form)
        {
            if (!File.Exists(WindowStateFile))
            {
                return;
            }

            var state = JsonConvert.DeserializeObject<WindowStateInfo>(File.ReadAllText(WindowStateFile));
            if (state != null)
            {
                if (state.WindowState.HasValue)
                {
                    form.WindowState = state.WindowState.Value;
                }

                if (state.WindowLocation.HasValue)
                {
                    form.Location = state.WindowLocation.Value;
                }
            }
        }

        public class WindowStateInfo
        {
            public FormWindowState? WindowState { get; set; }

            public Point? WindowLocation { get; set; }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveWindowState(this);
        }
    }
}
