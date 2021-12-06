using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Parser.GitHub;
using Parser.Models;
using Parser.PerformanceProfiling;
using Image = System.Drawing.Image;
using Size = System.Drawing.Size;

namespace Parser
{
    public partial class MainForm : Form
    {
        //private List<PriceData> _prices = new();
        //private List<RawPriceData> _invalidPrices = new();
        //private List<RawPriceData> _rawPrices = new();

        private WorkerData _workerData = new WorkerData();

        private static readonly RawPriceDataParser PriceDataParser = new();

        public MainForm()
        {
            InitializeComponent();

        }

        private async void ExportPricesButton_Click(object sender, EventArgs e)
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
                var json = JsonConvert.SerializeObject(_workerData.PriceData, Formatting.Indented);
                await File.WriteAllTextAsync(fileName, json, Encoding.UTF8);

                if (DebugMode.Checked)
                {
                    var debugInfo = new DebugInfo
                    {
                        RawPriceData = _workerData.RawPrices,
                        InvalidPriceData = _workerData.InvalidPrices
                    };

                    var debugFilePath = Path.Combine(Constants.DebugFolder,
                        $"DebugInfo-{DateTime.UtcNow:yyyyMMddHHmmss}.json");
                    await File.WriteAllTextAsync(debugFilePath, JsonConvert.SerializeObject(debugInfo, Formatting.Indented));
                }
                if (UploadToServer.Checked)
                {
                    await PriceDataUploader.Upload(json, Region.Text, Server.Text);
                }

                _workerData = new WorkerData();
                RawResults.DataSource = null;
                ParsedResults.DataSource = null;
                PerformanceGrid.DataSource = null;
                CapturedPricesCount.Text = _workerData.PriceData.Count.ToString();
                TotalItems.Text = _workerData.PriceData.Sum(p => p.Availability).ToString();
                StatusBarLabel1.Text = $"Saved to {fileName}";
            }
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Environment.Exit(0);
        }

        private async void MainForm_Load(object sender, EventArgs e)
        {
            FromImageButton.Visible = true;

            Region.DataSource = Servers.GetRegions();
            Region.Text = "TEST";

            LoadConfiguration();

            UpdateServersVisibility();

            if (!string.IsNullOrWhiteSpace(Region.Text))
            {
                var selectedServer = Server.Text;
                Server.DataSource = Servers.GetServers(Region.Text);
                Server.Text = Region.Text == "TEST" ? "Test" : selectedServer;
            }

            if (!Directory.Exists(Constants.DebugFolder))
            {
                Directory.CreateDirectory(Constants.DebugFolder);
            }
            await CheckForUpdate();
        }


        private async Task CheckForUpdate()
        {
            var latestRelease = await GitHubApiClient.GetLatestReleaseAsync();
            var latestVersionNumber = GitHubApiClient.GetNumericReleaseNumber(latestRelease);

            var currentVersion = typeof(MainForm).Assembly.GetName().Version;
            if (currentVersion != null)
            {
                var currentVersionNumber =
                    currentVersion.Major * 100 + currentVersion.Minor * 10 + currentVersion.Build;

                if (currentVersionNumber < latestVersionNumber)
                {
                    UpdateNotification.Text = "A new version is available. Click to download.";
                    UpdateNotification.Tag = latestRelease.HtmlUrl;
                }
            }
        }

        #region Configuration
        private const string ConfigurationFile = "config.json";

        public void SaveConfiguration()
        {
            var configuration = new Configuration
            {
                WindowLocation = Location,
                WindowState = WindowState,
                GameUILanguage = LanguageDropdown.Text,
                Size = Size,
                UploadToServer = UploadToServer.Checked,
                Server = Server.Text,
                Region = Region.Text

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

                //if (configuration.Size.HasValue)
                //{
                //    Size = configuration.Size.Value;
                //}

                if (!string.IsNullOrWhiteSpace(configuration.GameUILanguage))
                {
                    LanguageDropdown.Text = configuration.GameUILanguage;
                }
                else
                {
                    LanguageDropdown.Text = "English";
                }

                if (configuration.UploadToServer.HasValue)
                {
                    UploadToServer.Checked = configuration.UploadToServer.Value;
                }

                if (configuration.Region != null)
                {
                    Region.Text = configuration.Region;
                }


                if (configuration.Server != null)
                {
                    Server.Text = configuration.Server;
                }


            }
        }

        #endregion


        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveConfiguration();
        }


        private void FromImageButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var stopwatch = new Stopwatch();
                stopwatch.Start();
                StatusBarLabel1.Text = $"Processing...";

                _workerData ??= new WorkerData();

                _workerData.Files = openFileDialog1.FileNames.ToList();
                _workerData.LanguageCode = GetLanguageCode(LanguageDropdown.Text);
                _workerData.Stopwatch = new Stopwatch();
                _workerData.Stopwatch.Start();
                FromImageButton.Enabled = false;
                ExportPricesButton.Enabled = false;
                ProgressBar.Visible = true;
                ImageParseWorker.RunWorkerAsync(_workerData);
            }
        }




        private void DebugMode_CheckedChanged(object sender, EventArgs e)
        {
            RawResultsLabel.Visible = DebugMode.Checked;
            RawResults.Visible = DebugMode.Checked;
            ParsedResults.Visible = DebugMode.Checked;
            ParsedResultsLabel.Visible = DebugMode.Checked;
            PerformanceLabel.Visible = DebugMode.Checked;
            PerformanceGrid.Visible = DebugMode.Checked;

            Size = DebugMode.Checked ? new Size(Size.Width, 845) : new Size(Size.Width, 390);
        }

        private void UploadToServer_CheckedChanged(object sender, EventArgs e)
        {
            UpdateServersVisibility();
        }

        private void UpdateServersVisibility()
        {
            Region.Visible = UploadToServer.Checked;
            Server.Visible = UploadToServer.Checked;
            RegionLabel.Visible = UploadToServer.Checked;
            ServerLabel.Visible = UploadToServer.Checked;
        }

        private void Region_SelectedIndexChanged(object sender, EventArgs e)
        {
            var serverText = Server.Text;
            Server.DataSource = Servers.GetServers(Region.Text);
            Server.Text = serverText;
        }

        private void UpdateNotification_Click(object sender, EventArgs e)
        {
            var link = UpdateNotification.Tag.ToString();
            if (link != null && link.StartsWith("https://"))
            {
                var psInfo = new ProcessStartInfo
                {
                    FileName = link,
                    UseShellExecute = true
                };
                Process.Start(psInfo);
            }
        }

        private void ImageParseWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (e.Argument is WorkerData workerData)
            {
                for (var i = 0; i < workerData.Files.Count; i++)
                {
                    var fileName = workerData.Files[i];
                    using var image = Image.FromFile(fileName);
                    ParseImage(image, workerData);
                    var progress = (int)((double)(i + 1) / workerData.Files.Count * 100);
                    ImageParseWorker.ReportProgress(progress);
                }
            }

        }

        private void ImageParseWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            ProgressBar.Value = e.ProgressPercentage;
        }

        private void ImageParseWorker_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        {
            ProgressBar.Value = 0;
            FromImageButton.Enabled = true;
            ExportPricesButton.Enabled = true;
            ProgressBar.Visible = false;

            ExportPricesButton.Enabled = _workerData.PriceData.Count > 0;
            CapturedPricesCount.Text = _workerData.PriceData.Count.ToString();
            TotalItems.Text = _workerData.PriceData.Sum(p => p.Availability).ToString();
            StatusBarLabel1.Text = $"Processed in {_workerData.Stopwatch.ElapsedMilliseconds} ms.";

            if (DebugMode.Checked)
            {
                RawResults.DataSource = _workerData.RawPrices.ToList();
                ParsedResults.DataSource = _workerData.PriceData.ToList();
                PerformanceGrid.DataSource = PerformanceProfiler.Current.GetProfiles().Select(pp =>
                    new
                    {
                        Profile = pp.Key,
                        TotalMS = Math.Round(pp.Value.TotalMilliseconds * 100) / 100,
                        AverageMS = Math.Round(pp.Value.AverageMilliseconds * 100) / 100,
                        pp.Value.ExecutionsCount
                    }).OrderByDescending(a => a.TotalMS).ToList();
            }
        }

        private void ParseImage(Image image, WorkerData workerData)
        {
            try
            {
                using var imageParser = new ImageParser(!DebugMode.Checked);
                var result = imageParser.Parse(_workerData.LanguageCode, image);

                workerData.RawPrices.AddRange(result);

                result.ForEach(r =>
                {
                    if (PriceDataParser.TryParse(r, out var priceData))
                    {
                        workerData.PriceData.Add(priceData);
                    }
                    else
                    {
                        workerData.InvalidPrices.Add(r);
                    }
                });
            }
            catch (Exception e)
            {
                StatusBarLabel1.Text = e.Message;
            }

        }

        private static string GetLanguageCode(string languageName)
        {
            return languageName switch
            {
                "English" => "eng",
                "French" => "fra",
                "Spanish" => "spa",
                "German" => "deu",
                "Italian" => "ita",
                "Polish" => "pol",
                "Portuguese" => "por",
                _ => "eng"
            };
        }
    }

    public class WorkerData
    {
        public List<string> Files { get; set; }
        public List<PriceData> PriceData { get; set; } = new List<PriceData>();
        public List<RawPriceData> InvalidPrices { get; set; } = new List<RawPriceData>();
        public List<RawPriceData> RawPrices { get; set; } = new List<RawPriceData>();
        public string LanguageCode { get; set; }
        public Stopwatch Stopwatch { get; set; }

    }
}
