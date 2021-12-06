
namespace Parser
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
            this.ExportPricesSaveDialog = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.ServerLabel = new System.Windows.Forms.Label();
            this.Server = new System.Windows.Forms.ComboBox();
            this.RegionLabel = new System.Windows.Forms.Label();
            this.Region = new System.Windows.Forms.ComboBox();
            this.UploadToServer = new System.Windows.Forms.CheckBox();
            this.DebugMode = new System.Windows.Forms.CheckBox();
            this.PerformanceLabel = new System.Windows.Forms.Label();
            this.PerformanceGrid = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.LanguageDropdown = new System.Windows.Forms.ComboBox();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusBarLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.UpdateNotification = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProgressBar = new System.Windows.Forms.ToolStripProgressBar();
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
            this.ImageParseWorker = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.PerformanceGrid)).BeginInit();
            this.StatusBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParsedResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.RawResults)).BeginInit();
            this.SuspendLayout();
            // 
            // ExportPricesSaveDialog
            // 
            this.ExportPricesSaveDialog.DefaultExt = "Json File|*.json";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Image Files|*.BMP;*.JPG;*.GIF;*.PNG|All files (*.*)|*.*";
            this.openFileDialog1.Multiselect = true;
            // 
            // ServerLabel
            // 
            this.ServerLabel.AutoSize = true;
            this.ServerLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ServerLabel.Location = new System.Drawing.Point(11, 140);
            this.ServerLabel.Name = "ServerLabel";
            this.ServerLabel.Size = new System.Drawing.Size(45, 15);
            this.ServerLabel.TabIndex = 56;
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
            this.Server.Location = new System.Drawing.Point(149, 137);
            this.Server.Name = "Server";
            this.Server.Size = new System.Drawing.Size(121, 23);
            this.Server.TabIndex = 55;
            // 
            // RegionLabel
            // 
            this.RegionLabel.AutoSize = true;
            this.RegionLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RegionLabel.Location = new System.Drawing.Point(11, 112);
            this.RegionLabel.Name = "RegionLabel";
            this.RegionLabel.Size = new System.Drawing.Size(46, 15);
            this.RegionLabel.TabIndex = 54;
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
            this.Region.Location = new System.Drawing.Point(149, 109);
            this.Region.Name = "Region";
            this.Region.Size = new System.Drawing.Size(121, 23);
            this.Region.TabIndex = 53;
            this.Region.SelectedIndexChanged += new System.EventHandler(this.Region_SelectedIndexChanged);
            // 
            // UploadToServer
            // 
            this.UploadToServer.AutoSize = true;
            this.UploadToServer.Location = new System.Drawing.Point(11, 84);
            this.UploadToServer.Name = "UploadToServer";
            this.UploadToServer.Size = new System.Drawing.Size(370, 19);
            this.UploadToServer.TabIndex = 52;
            this.UploadToServer.Text = "Also anonymously upload to shared price database during export";
            this.UploadToServer.UseVisualStyleBackColor = true;
            this.UploadToServer.CheckedChanged += new System.EventHandler(this.UploadToServer_CheckedChanged);
            // 
            // DebugMode
            // 
            this.DebugMode.AutoSize = true;
            this.DebugMode.Location = new System.Drawing.Point(418, 7);
            this.DebugMode.Name = "DebugMode";
            this.DebugMode.Size = new System.Drawing.Size(95, 19);
            this.DebugMode.TabIndex = 51;
            this.DebugMode.Text = "Debug Mode";
            this.DebugMode.UseVisualStyleBackColor = true;
            this.DebugMode.CheckedChanged += new System.EventHandler(this.DebugMode_CheckedChanged);
            // 
            // PerformanceLabel
            // 
            this.PerformanceLabel.AutoSize = true;
            this.PerformanceLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PerformanceLabel.Location = new System.Drawing.Point(14, 613);
            this.PerformanceLabel.Name = "PerformanceLabel";
            this.PerformanceLabel.Size = new System.Drawing.Size(80, 15);
            this.PerformanceLabel.TabIndex = 50;
            this.PerformanceLabel.Text = "Performance";
            this.PerformanceLabel.Visible = false;
            // 
            // PerformanceGrid
            // 
            this.PerformanceGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.PerformanceGrid.Location = new System.Drawing.Point(14, 631);
            this.PerformanceGrid.Name = "PerformanceGrid";
            this.PerformanceGrid.RowHeadersVisible = false;
            this.PerformanceGrid.RowTemplate.Height = 25;
            this.PerformanceGrid.Size = new System.Drawing.Size(553, 129);
            this.PerformanceGrid.TabIndex = 49;
            this.PerformanceGrid.Visible = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label6.Location = new System.Drawing.Point(10, 58);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(112, 15);
            this.label6.TabIndex = 48;
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
            this.LanguageDropdown.Location = new System.Drawing.Point(149, 55);
            this.LanguageDropdown.Name = "LanguageDropdown";
            this.LanguageDropdown.Size = new System.Drawing.Size(121, 23);
            this.LanguageDropdown.TabIndex = 47;
            // 
            // StatusBar
            // 
            this.StatusBar.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarLabel1,
            this.UpdateNotification,
            this.ProgressBar});
            this.StatusBar.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.StatusBar.Location = new System.Drawing.Point(0, 329);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(578, 22);
            this.StatusBar.SizingGrip = false;
            this.StatusBar.TabIndex = 46;
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
            // ProgressBar
            // 
            this.ProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(250, 16);
            this.ProgressBar.Step = 1;
            this.ProgressBar.Visible = false;
            // 
            // ParsedResultsLabel
            // 
            this.ParsedResultsLabel.AutoSize = true;
            this.ParsedResultsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ParsedResultsLabel.Location = new System.Drawing.Point(293, 316);
            this.ParsedResultsLabel.Name = "ParsedResultsLabel";
            this.ParsedResultsLabel.Size = new System.Drawing.Size(87, 15);
            this.ParsedResultsLabel.TabIndex = 45;
            this.ParsedResultsLabel.Text = "Parsed Results";
            this.ParsedResultsLabel.Visible = false;
            // 
            // ParsedResults
            // 
            this.ParsedResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParsedResults.Location = new System.Drawing.Point(293, 334);
            this.ParsedResults.Name = "ParsedResults";
            this.ParsedResults.RowHeadersVisible = false;
            this.ParsedResults.RowTemplate.Height = 25;
            this.ParsedResults.Size = new System.Drawing.Size(273, 276);
            this.ParsedResults.TabIndex = 44;
            this.ParsedResults.Visible = false;
            // 
            // RawResultsLabel
            // 
            this.RawResultsLabel.AutoSize = true;
            this.RawResultsLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.RawResultsLabel.Location = new System.Drawing.Point(14, 316);
            this.RawResultsLabel.Name = "RawResultsLabel";
            this.RawResultsLabel.Size = new System.Drawing.Size(74, 15);
            this.RawResultsLabel.TabIndex = 43;
            this.RawResultsLabel.Text = "Raw Results";
            this.RawResultsLabel.Visible = false;
            // 
            // RawResults
            // 
            this.RawResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RawResults.Location = new System.Drawing.Point(14, 334);
            this.RawResults.Name = "RawResults";
            this.RawResults.RowHeadersVisible = false;
            this.RawResults.RowTemplate.Height = 25;
            this.RawResults.Size = new System.Drawing.Size(273, 276);
            this.RawResults.TabIndex = 42;
            this.RawResults.Visible = false;
            // 
            // FromImageButton
            // 
            this.FromImageButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FromImageButton.Location = new System.Drawing.Point(14, 193);
            this.FromImageButton.Name = "FromImageButton";
            this.FromImageButton.Size = new System.Drawing.Size(269, 120);
            this.FromImageButton.TabIndex = 41;
            this.FromImageButton.Text = "Open Screenshots";
            this.FromImageButton.UseVisualStyleBackColor = true;
            this.FromImageButton.Visible = false;
            this.FromImageButton.Click += new System.EventHandler(this.FromImageButton_Click);
            // 
            // ExportPricesButton
            // 
            this.ExportPricesButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ExportPricesButton.Location = new System.Drawing.Point(289, 193);
            this.ExportPricesButton.Name = "ExportPricesButton";
            this.ExportPricesButton.Size = new System.Drawing.Size(273, 120);
            this.ExportPricesButton.TabIndex = 40;
            this.ExportPricesButton.Text = "Export Prices";
            this.ExportPricesButton.UseVisualStyleBackColor = true;
            this.ExportPricesButton.Click += new System.EventHandler(this.ExportPricesButton_Click);
            // 
            // TotalItems
            // 
            this.TotalItems.AutoSize = true;
            this.TotalItems.Location = new System.Drawing.Point(149, 32);
            this.TotalItems.Name = "TotalItems";
            this.TotalItems.Size = new System.Drawing.Size(13, 15);
            this.TotalItems.TabIndex = 39;
            this.TotalItems.Text = "0";
            this.TotalItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(10, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 38;
            this.label4.Text = "Total Items";
            // 
            // CapturedPricesCount
            // 
            this.CapturedPricesCount.AutoSize = true;
            this.CapturedPricesCount.Location = new System.Drawing.Point(149, 7);
            this.CapturedPricesCount.Name = "CapturedPricesCount";
            this.CapturedPricesCount.Size = new System.Drawing.Size(13, 15);
            this.CapturedPricesCount.TabIndex = 37;
            this.CapturedPricesCount.Text = "0";
            this.CapturedPricesCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(10, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 15);
            this.label2.TabIndex = 36;
            this.label2.Text = "Parsed Prices Count";
            // 
            // ImageParseWorker
            // 
            this.ImageParseWorker.WorkerReportsProgress = true;
            this.ImageParseWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.ImageParseWorker_DoWork);
            this.ImageParseWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.ImageParseWorker_ProgressChanged);
            this.ImageParseWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.ImageParseWorker_RunWorkerCompleted);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(578, 351);
            this.Controls.Add(this.ServerLabel);
            this.Controls.Add(this.Server);
            this.Controls.Add(this.RegionLabel);
            this.Controls.Add(this.Region);
            this.Controls.Add(this.UploadToServer);
            this.Controls.Add(this.DebugMode);
            this.Controls.Add(this.PerformanceLabel);
            this.Controls.Add(this.PerformanceGrid);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.LanguageDropdown);
            this.Controls.Add(this.StatusBar);
            this.Controls.Add(this.ParsedResultsLabel);
            this.Controls.Add(this.ParsedResults);
            this.Controls.Add(this.RawResultsLabel);
            this.Controls.Add(this.RawResults);
            this.Controls.Add(this.FromImageButton);
            this.Controls.Add(this.ExportPricesButton);
            this.Controls.Add(this.TotalItems);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CapturedPricesCount);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Parser";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PerformanceGrid)).EndInit();
            this.StatusBar.ResumeLayout(false);
            this.StatusBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ParsedResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.RawResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.SaveFileDialog ExportPricesSaveDialog;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label ServerLabel;
        private System.Windows.Forms.ComboBox Server;
        private System.Windows.Forms.Label RegionLabel;
        private System.Windows.Forms.ComboBox Region;
        private System.Windows.Forms.CheckBox UploadToServer;
        private System.Windows.Forms.CheckBox DebugMode;
        private System.Windows.Forms.Label PerformanceLabel;
        private System.Windows.Forms.DataGridView PerformanceGrid;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox LanguageDropdown;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarLabel1;
        private System.Windows.Forms.ToolStripStatusLabel UpdateNotification;
        private System.Windows.Forms.Label ParsedResultsLabel;
        private System.Windows.Forms.DataGridView ParsedResults;
        private System.Windows.Forms.Label RawResultsLabel;
        private System.Windows.Forms.DataGridView RawResults;
        private System.Windows.Forms.Button FromImageButton;
        private System.Windows.Forms.Button ExportPricesButton;
        private System.Windows.Forms.Label TotalItems;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label CapturedPricesCount;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker ImageParseWorker;
        private System.Windows.Forms.ToolStripProgressBar ProgressBar;
    }
}

