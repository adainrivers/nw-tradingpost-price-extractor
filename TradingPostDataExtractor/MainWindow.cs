using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using NonInvasiveKeyboardHookLibrary;
using TradingPostDataExtractor.PerformanceProfiling;
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

        private List<PriceData> _prices = new();
        private List<RawPriceData> _invalidPrices = new();
        private List<RawPriceData> _rawPrices = new();

        private List<PriceData> _currentScreenshotPrices = new();
        private List<RawPriceData> _currentScreenshotRawPrices = new();
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

        private async void OnTakeScreenshotButton_Click(object sender, EventArgs e)
        {
            await TakeScreenshot();
        }

        private async Task TakeScreenshot()
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
            await ProcessImage(capturedImage);

            RawResults.DataSource = _currentScreenshotRawPrices;
            ParsedResults.DataSource = _currentScreenshotPrices;
            TakeScreenshotButton.Text = currentText;
            TakeScreenshotButton.Enabled = true;
            _keyboardHooks.Start();
        }

        private Image CaptureApplication()
        {
            var rect = new User32.Rect();
            User32.GetWindowRect(_newWorldProcess.MainWindowHandle, ref rect);

            var width = rect.right - rect.left;
            var height = rect.bottom - rect.top;


            _newWorldGameWindowDimensions = $"{width}x{height}";

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
            catch (InvalidOperationException e)
            {
                StatusBarLabel1.Text = e.Message;
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

        private async Task ParseImage(Image image)
        {
            try
            {
                using var imageParser = new ImageParser();
                var result = await imageParser.Parse(GetLanguageCode(LanguageDropdown.Text), image);
                ImagePreview.ImageLocation = imageParser.DebugFilePath;
                _rawPrices.AddRange(result);

                var parsedPrices = new List<PriceData>();
                var invalidPrices = new List<RawPriceData>();
                result.ForEach(r =>
                {
                    if (PriceDataParser.TryParse(r, out var priceData))
                    {
                        parsedPrices.Add(priceData);
                    }
                    else
                    {
                        invalidPrices.Add(r);
                    }
                });

                _currentScreenshotPrices = parsedPrices.ToList();
                _currentScreenshotRawPrices = result.ToList();

                _invalidPrices.AddRange(invalidPrices);
                _prices.AddRange(parsedPrices);
            }
            catch (Exception e)
            {
                StatusBarLabel1.Text = e.Message;
            }

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
                File.WriteAllText(fileName, JsonConvert.SerializeObject(_prices, Formatting.Indented), Encoding.UTF8);

                var debugInfo = new DebugInfo
                {
                    NewWorldGameWindowDimensions = _newWorldGameWindowDimensions,
                    RawPriceData = _rawPrices,
                    InvalidPriceData = _invalidPrices
                };

                var debugFilePath = Path.Combine(Constants.DebugFolder,
                    $"DebugInfo-{DateTime.UtcNow:yyyyMMddHHmmss}.json");
                File.WriteAllText(debugFilePath, JsonConvert.SerializeObject(debugInfo, Formatting.Indented));
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
//#if DEBUG
            FromImageButton.Visible = true;
            PerformanceGrid.Visible = true;
            PerformanceLabel.Visible = true;
//#endif
            RegisterHotKeys();
            LoadConfiguration();

            if (!Directory.Exists(Constants.DebugFolder))
            {
                Directory.CreateDirectory(Constants.DebugFolder);
            }
        }

        private const string ConfigurationFile = "config.json";

        public void SaveConfiguration()
        {
            var configuration = new Configuration
            {
                WindowLocation = Location,
                WindowState = WindowState,
                GameUILanguage = LanguageDropdown.Text,
                Size = Size
                
            };
            File.WriteAllText(ConfigurationFile, JsonConvert.SerializeObject(configuration));
        }

        public void LoadConfiguration()
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
                    WindowState = configuration.WindowState.Value;
                }

                if (configuration.WindowLocation.HasValue)
                {
                    Location = configuration.WindowLocation.Value;
                }

                if (configuration.Size.HasValue)
                {
                    Size = configuration.Size.Value;
                }

                if (!string.IsNullOrWhiteSpace(configuration.GameUILanguage))
                {
                    LanguageDropdown.Text = configuration.GameUILanguage;
                }
                else
                {
                    LanguageDropdown.Text = "English";
                }
            }
        }

        public class Configuration
        {
            public FormWindowState? WindowState { get; set; }

            public Point? WindowLocation { get; set; }

            public string GameUILanguage { get; set; } = "English";
            public Size? Size { get; set; }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfiguration();
            _keyboardHooks?.UnregisterAll();
            _keyboardHooks?.Stop();
        }

        private void MainForm_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
        }

        private async void FromImageButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                using var image = Image.FromFile(openFileDialog1.FileName);
                await ProcessImage(image);
                RawResults.DataSource = _currentScreenshotRawPrices;
                ParsedResults.DataSource = _currentScreenshotPrices;
            }
        }

        private async Task ProcessImage(Image image)
        {
            StatusBarLabel1.Text = $"Processing...";
            var stopwatch = new Stopwatch();
            stopwatch.Start();
            await ParseImage(image);
            //SetPreviewImage(image);
            StatusBarLabel1.Text = $"Processed in {stopwatch.ElapsedMilliseconds} ms.";
            PerformanceGrid.DataSource = PerformanceProfiler.Current.GetProfiles().Select(pp =>
                new { Profile = pp.Key, TotalMS = Math.Round(pp.Value.TotalMilliseconds * 100) / 100, AverageMS = Math.Round(pp.Value.AverageMilliseconds * 100) / 100, pp.Value.ExecutionsCount }).OrderByDescending(a=>a.TotalMS) .ToList();

            PerformanceProfiler.Current = new PerformanceProfiler();
        }

        private void LanguageDropdown_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private string GetLanguageCode(string languageName)
        {
            switch (languageName)
            {
                case "English":
                    return "eng";
                case "French":
                    return "fra";
                case "Spanish":
                    return "spa";
                case "German":
                    return "deu";
                case "Italian":
                    return "ita";
                case "Polish":
                    return "pol";
                case "Portuguese":
                    return "por";
                default:
                    return "eng";
            }
        }

        private void MainForm_ResizeEnd(object sender, EventArgs e)
        {
            splitContainer1.SplitterDistance = splitContainer1.Width - splitContainer1.Panel2.MinimumSize.Width;
        }
    }
}
