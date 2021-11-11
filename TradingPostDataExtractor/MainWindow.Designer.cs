
namespace TradingPostDataExtractor
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.TimerNewWorldStatus = new System.Windows.Forms.Timer(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.TimerProcessRefresher = new System.Windows.Forms.Timer(this.components);
            this.ExportPricesSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.ImagePreview = new System.Windows.Forms.PictureBox();
            this.ServerLabel = new System.Windows.Forms.Label();
            this.Server = new System.Windows.Forms.ComboBox();
            this.RegionLabel = new System.Windows.Forms.Label();
            this.Region = new System.Windows.Forms.ComboBox();
            this.UploadToServer = new System.Windows.Forms.CheckBox();
            this.HighPerformanceMode = new System.Windows.Forms.CheckBox();
            this.PerformanceLabel = new System.Windows.Forms.Label();
            this.PerformanceGrid = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.LanguageDropdown = new System.Windows.Forms.ComboBox();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusBarLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.UpdateNotification = new System.Windows.Forms.ToolStripStatusLabel();
            this.ParsedResultsLabel = new System.Windows.Forms.Label();
            this.ParsedResults = new System.Windows.Forms.DataGridView();
            this.RawResultsLabel = new System.Windows.Forms.Label();
            this.RawResults = new System.Windows.Forms.DataGridView();
            this.FromImageButton = new System.Windows.Forms.Button();
            this.ExportPricesButton = new System.Windows.Forms.Button();
            this.TotalItems = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.CapturedPricesCount = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.NewWorldStatus = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TakeScreenshotButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PerformanceGrid)).BeginInit();
            this.StatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParsedResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RawResults)).BeginInit();
            this.SuspendLayout();
            // 
            // TimerNewWorldStatus
            // 
            this.TimerNewWorldStatus.Enabled = true;
            this.TimerNewWorldStatus.Tick += new System.EventHandler(this.TimerNewWorldStatus_Tick);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            // 
            // TimerProcessRefresher
            // 
            this.TimerProcessRefresher.Enabled = true;
            this.TimerProcessRefresher.Interval = 3000;
            this.TimerProcessRefresher.Tick += new System.EventHandler(this.TimerProcessRefresher_Tick);
            // 
            // ExportPricesSaveDialog
            // 
            this.ExportPricesSaveDialog.DefaultExt = "Json File|*.json";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Image Files|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel2;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ImagePreview);
            this.splitContainer1.Panel1.Padding = new System.Windows.Forms.Padding(10);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.ServerLabel);
            this.splitContainer1.Panel2.Controls.Add(this.Server);
            this.splitContainer1.Panel2.Controls.Add(this.RegionLabel);
            this.splitContainer1.Panel2.Controls.Add(this.Region);
            this.splitContainer1.Panel2.Controls.Add(this.UploadToServer);
            this.splitContainer1.Panel2.Controls.Add(this.HighPerformanceMode);
            this.splitContainer1.Panel2.Controls.Add(this.PerformanceLabel);
            this.splitContainer1.Panel2.Controls.Add(this.PerformanceGrid);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.LanguageDropdown);
            this.splitContainer1.Panel2.Controls.Add(this.StatusBar);
            this.splitContainer1.Panel2.Controls.Add(this.ParsedResultsLabel);
            this.splitContainer1.Panel2.Controls.Add(this.ParsedResults);
            this.splitContainer1.Panel2.Controls.Add(this.RawResultsLabel);
            this.splitContainer1.Panel2.Controls.Add(this.RawResults);
            this.splitContainer1.Panel2.Controls.Add(this.FromImageButton);
            this.splitContainer1.Panel2.Controls.Add(this.ExportPricesButton);
            this.splitContainer1.Panel2.Controls.Add(this.TotalItems);
            this.splitContainer1.Panel2.Controls.Add(this.label4);
            this.splitContainer1.Panel2.Controls.Add(this.CapturedPricesCount);
            this.splitContainer1.Panel2.Controls.Add(this.label2);
            this.splitContainer1.Panel2.Controls.Add(this.NewWorldStatus);
            this.splitContainer1.Panel2.Controls.Add(this.label1);
            this.splitContainer1.Panel2.Controls.Add(this.TakeScreenshotButton);
            this.splitContainer1.Panel2.Padding = new System.Windows.Forms.Padding(10);
            this.splitContainer1.Panel2MinSize = 584;
            this.splitContainer1.Size = new System.Drawing.Size(1139, 806);
            this.splitContainer1.SplitterDistance = 550;
            this.splitContainer1.TabIndex = 11;
            // 
            // ImagePreview
            // 
            this.ImagePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImagePreview.Location = new System.Drawing.Point(10, 10);
            this.ImagePreview.Name = "ImagePreview";
            this.ImagePreview.Size = new System.Drawing.Size(530, 786);
            this.ImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImagePreview.TabIndex = 2;
            this.ImagePreview.TabStop = false;
            // 
            // ServerLabel
            // 
            this.ServerLabel.AutoSize = true;
            this.ServerLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ServerLabel.Location = new System.Drawing.Point(14, 169);
            this.ServerLabel.Name = "ServerLabel";
            this.ServerLabel.Size = new System.Drawing.Size(45, 15);
            this.ServerLabel.TabIndex = 35;
            this.ServerLabel.Text = "Server";
            // 
            // Server
            // 
            this.Server.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Server.FormattingEnabled = true;
            this.Server.Items.AddRange(new object[] {
            "English",
            "French",
            "Spanish",
            "German",
            "Italian",
            "Polish",
            "Portuguese"});
            this.Server.Location = new System.Drawing.Point(152, 166);
            this.Server.Name = "Server";
            this.Server.Size = new System.Drawing.Size(121, 23);
            this.Server.TabIndex = 34;
            // 
            // RegionLabel
            // 
            this.RegionLabel.AutoSize = true;
            this.RegionLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RegionLabel.Location = new System.Drawing.Point(14, 141);
            this.RegionLabel.Name = "RegionLabel";
            this.RegionLabel.Size = new System.Drawing.Size(46, 15);
            this.RegionLabel.TabIndex = 33;
            this.RegionLabel.Text = "Region";
            // 
            // Region
            // 
            this.Region.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Region.FormattingEnabled = true;
            this.Region.Items.AddRange(new object[] {
            "English",
            "French",
            "Spanish",
            "German",
            "Italian",
            "Polish",
            "Portuguese"});
            this.Region.Location = new System.Drawing.Point(152, 138);
            this.Region.Name = "Region";
            this.Region.Size = new System.Drawing.Size(121, 23);
            this.Region.TabIndex = 32;
            this.Region.SelectedIndexChanged += new System.EventHandler(this.Region_SelectedIndexChanged);
            // 
            // UploadToServer
            // 
            this.UploadToServer.AutoSize = true;
            this.UploadToServer.Location = new System.Drawing.Point(14, 113);
            this.UploadToServer.Name = "UploadToServer";
            this.UploadToServer.Size = new System.Drawing.Size(443, 19);
            this.UploadToServer.TabIndex = 31;
            this.UploadToServer.Text = "Also anonymously upload to gaming.tools shared price database during export";
            this.UploadToServer.UseVisualStyleBackColor = true;
            this.UploadToServer.CheckedChanged += new System.EventHandler(this.UploadToServer_CheckedChanged);
            // 
            // HighPerformanceMode
            // 
            this.HighPerformanceMode.AutoSize = true;
            this.HighPerformanceMode.Location = new System.Drawing.Point(409, 54);
            this.HighPerformanceMode.Name = "HighPerformanceMode";
            this.HighPerformanceMode.Size = new System.Drawing.Size(157, 19);
            this.HighPerformanceMode.TabIndex = 30;
            this.HighPerformanceMode.Text = "High Performance Mode";
            this.HighPerformanceMode.UseVisualStyleBackColor = true;
            this.HighPerformanceMode.CheckedChanged += new System.EventHandler(this.HighPerformanceMode_CheckedChanged);
            // 
            // PerformanceLabel
            // 
            this.PerformanceLabel.AutoSize = true;
            this.PerformanceLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PerformanceLabel.Location = new System.Drawing.Point(14, 619);
            this.PerformanceLabel.Name = "PerformanceLabel";
            this.PerformanceLabel.Size = new System.Drawing.Size(80, 15);
            this.PerformanceLabel.TabIndex = 29;
            this.PerformanceLabel.Text = "Performance";
            this.PerformanceLabel.Visible = false;
            // 
            // PerformanceGrid
            // 
            this.PerformanceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PerformanceGrid.Location = new System.Drawing.Point(14, 637);
            this.PerformanceGrid.Name = "PerformanceGrid";
            this.PerformanceGrid.RowHeadersVisible = false;
            this.PerformanceGrid.RowTemplate.Height = 25;
            this.PerformanceGrid.Size = new System.Drawing.Size(553, 129);
            this.PerformanceGrid.TabIndex = 28;
            this.PerformanceGrid.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(13, 87);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 15);
            this.label6.TabIndex = 27;
            this.label6.Text = "Game UI Language";
            // 
            // LanguageDropdown
            // 
            this.LanguageDropdown.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.LanguageDropdown.FormattingEnabled = true;
            this.LanguageDropdown.Items.AddRange(new object[] {
            "English",
            "French",
            "Spanish",
            "German",
            "Italian",
            "Polish",
            "Portuguese"});
            this.LanguageDropdown.Location = new System.Drawing.Point(152, 84);
            this.LanguageDropdown.Name = "LanguageDropdown";
            this.LanguageDropdown.Size = new System.Drawing.Size(121, 23);
            this.LanguageDropdown.TabIndex = 26;
            this.LanguageDropdown.SelectedIndexChanged += new System.EventHandler(this.LanguageDropdown_SelectedIndexChanged);
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarLabel1,
            this.UpdateNotification});
            this.StatusBar.Location = new System.Drawing.Point(10, 774);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(565, 22);
            this.StatusBar.SizingGrip = false;
            this.StatusBar.TabIndex = 25;
            this.StatusBar.Text = "statusStrip1";
            // 
            // StatusBarLabel1
            // 
            this.StatusBarLabel1.Name = "StatusBarLabel1";
            this.StatusBarLabel1.Size = new System.Drawing.Size(0, 17);
            this.StatusBarLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // UpdateNotification
            // 
            this.UpdateNotification.IsLink = true;
            this.UpdateNotification.Name = "UpdateNotification";
            this.UpdateNotification.Size = new System.Drawing.Size(0, 17);
            this.UpdateNotification.Click += new System.EventHandler(this.UpdateNotification_Click);
            // 
            // ParsedResultsLabel
            // 
            this.ParsedResultsLabel.AutoSize = true;
            this.ParsedResultsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ParsedResultsLabel.Location = new System.Drawing.Point(293, 322);
            this.ParsedResultsLabel.Name = "ParsedResultsLabel";
            this.ParsedResultsLabel.Size = new System.Drawing.Size(87, 15);
            this.ParsedResultsLabel.TabIndex = 24;
            this.ParsedResultsLabel.Text = "Parsed Results";
            // 
            // ParsedResults
            // 
            this.ParsedResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParsedResults.Location = new System.Drawing.Point(293, 340);
            this.ParsedResults.Name = "ParsedResults";
            this.ParsedResults.RowHeadersVisible = false;
            this.ParsedResults.RowTemplate.Height = 25;
            this.ParsedResults.Size = new System.Drawing.Size(273, 276);
            this.ParsedResults.TabIndex = 23;
            // 
            // RawResultsLabel
            // 
            this.RawResultsLabel.AutoSize = true;
            this.RawResultsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RawResultsLabel.Location = new System.Drawing.Point(14, 322);
            this.RawResultsLabel.Name = "RawResultsLabel";
            this.RawResultsLabel.Size = new System.Drawing.Size(74, 15);
            this.RawResultsLabel.TabIndex = 22;
            this.RawResultsLabel.Text = "Raw Results";
            // 
            // RawResults
            // 
            this.RawResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RawResults.Location = new System.Drawing.Point(14, 340);
            this.RawResults.Name = "RawResults";
            this.RawResults.RowHeadersVisible = false;
            this.RawResults.RowTemplate.Height = 25;
            this.RawResults.Size = new System.Drawing.Size(273, 276);
            this.RawResults.TabIndex = 21;
            // 
            // FromImageButton
            // 
            this.FromImageButton.Location = new System.Drawing.Point(452, 13);
            this.FromImageButton.Name = "FromImageButton";
            this.FromImageButton.Size = new System.Drawing.Size(115, 35);
            this.FromImageButton.TabIndex = 19;
            this.FromImageButton.Text = "From Image";
            this.FromImageButton.UseVisualStyleBackColor = true;
            this.FromImageButton.Visible = false;
            this.FromImageButton.Click += new System.EventHandler(this.FromImageButton_Click);
            // 
            // ExportPricesButton
            // 
            this.ExportPricesButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ExportPricesButton.Location = new System.Drawing.Point(289, 199);
            this.ExportPricesButton.Name = "ExportPricesButton";
            this.ExportPricesButton.Size = new System.Drawing.Size(273, 120);
            this.ExportPricesButton.TabIndex = 18;
            this.ExportPricesButton.Text = "Export Prices";
            this.ExportPricesButton.UseVisualStyleBackColor = true;
            this.ExportPricesButton.Click += new System.EventHandler(this.ExportPricesButton_Click);
            // 
            // TotalItems
            // 
            this.TotalItems.AutoSize = true;
            this.TotalItems.Location = new System.Drawing.Point(152, 61);
            this.TotalItems.Name = "TotalItems";
            this.TotalItems.Size = new System.Drawing.Size(13, 15);
            this.TotalItems.TabIndex = 17;
            this.TotalItems.Text = "0";
            this.TotalItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(13, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "Total Items";
            // 
            // CapturedPricesCount
            // 
            this.CapturedPricesCount.AutoSize = true;
            this.CapturedPricesCount.Location = new System.Drawing.Point(152, 36);
            this.CapturedPricesCount.Name = "CapturedPricesCount";
            this.CapturedPricesCount.Size = new System.Drawing.Size(13, 15);
            this.CapturedPricesCount.TabIndex = 15;
            this.CapturedPricesCount.Text = "0";
            this.CapturedPricesCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(13, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 14;
            this.label2.Text = "Captured Prices Count";
            // 
            // NewWorldStatus
            // 
            this.NewWorldStatus.AutoSize = true;
            this.NewWorldStatus.Location = new System.Drawing.Point(152, 11);
            this.NewWorldStatus.Name = "NewWorldStatus";
            this.NewWorldStatus.Size = new System.Drawing.Size(52, 15);
            this.NewWorldStatus.TabIndex = 13;
            this.NewWorldStatus.Text = "Running";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 12;
            this.label1.Text = "New World";
            // 
            // TakeScreenshotButton
            // 
            this.TakeScreenshotButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TakeScreenshotButton.Location = new System.Drawing.Point(13, 199);
            this.TakeScreenshotButton.Name = "TakeScreenshotButton";
            this.TakeScreenshotButton.Size = new System.Drawing.Size(273, 120);
            this.TakeScreenshotButton.TabIndex = 11;
            this.TakeScreenshotButton.Text = "Capture Screen and Extract Prices (F11)";
            this.TakeScreenshotButton.UseVisualStyleBackColor = true;
            this.TakeScreenshotButton.Click += new System.EventHandler(this.OnTakeScreenshotButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 806);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Trading Post Data Extractor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResizeEnd += new System.EventHandler(this.MainForm_ResizeEnd);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PerformanceGrid)).EndInit();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParsedResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RawResults)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Timer TimerNewWorldStatus;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer TimerProcessRefresher;
        private System.Windows.Forms.SaveFileDialog ExportPricesSaveDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox ImagePreview;
        private System.Windows.Forms.Button FromImageButton;
        private System.Windows.Forms.Button ExportPricesButton;
        private System.Windows.Forms.Label TotalItems;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label CapturedPricesCount;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label NewWorldStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button TakeScreenshotButton;
        private System.Windows.Forms.Label RawResultsLabel;
        private System.Windows.Forms.DataGridView RawResults;
        private System.Windows.Forms.Label ParsedResultsLabel;
        private System.Windows.Forms.DataGridView ParsedResults;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarLabel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox LanguageDropdown;
        private System.Windows.Forms.DataGridView PerformanceGrid;
        private System.Windows.Forms.Label PerformanceLabel;
        private System.Windows.Forms.CheckBox HighPerformanceMode;
        private System.Windows.Forms.Label ServerLabel;
        private System.Windows.Forms.ComboBox Server;
        private System.Windows.Forms.Label RegionLabel;
        private System.Windows.Forms.ComboBox Region;
        private System.Windows.Forms.CheckBox UploadToServer;
        private System.Windows.Forms.ToolStripStatusLabel UpdateNotification;
    }
}

