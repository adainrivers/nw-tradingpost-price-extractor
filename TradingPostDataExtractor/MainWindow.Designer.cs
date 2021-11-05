
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
            this.PerformanceGrid = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.LanguageDropdown = new System.Windows.Forms.ComboBox();
            this.StatusBar = new System.Windows.Forms.StatusStrip();
            this.StatusBarLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.label5 = new System.Windows.Forms.Label();
            this.ParsedResults = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
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
            this.label7 = new System.Windows.Forms.Label();
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
            this.splitContainer1.Panel2.Controls.Add(this.label7);
            this.splitContainer1.Panel2.Controls.Add(this.PerformanceGrid);
            this.splitContainer1.Panel2.Controls.Add(this.label6);
            this.splitContainer1.Panel2.Controls.Add(this.LanguageDropdown);
            this.splitContainer1.Panel2.Controls.Add(this.StatusBar);
            this.splitContainer1.Panel2.Controls.Add(this.label5);
            this.splitContainer1.Panel2.Controls.Add(this.ParsedResults);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
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
            this.splitContainer1.Size = new System.Drawing.Size(1473, 801);
            this.splitContainer1.SplitterDistance = 893;
            this.splitContainer1.TabIndex = 11;
            // 
            // ImagePreview
            // 
            this.ImagePreview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ImagePreview.Location = new System.Drawing.Point(10, 10);
            this.ImagePreview.Name = "ImagePreview";
            this.ImagePreview.Size = new System.Drawing.Size(873, 781);
            this.ImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImagePreview.TabIndex = 2;
            this.ImagePreview.TabStop = false;
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
            this.StatusBarLabel1});
            this.StatusBar.Location = new System.Drawing.Point(10, 769);
            this.StatusBar.Name = "StatusBar";
            this.StatusBar.Size = new System.Drawing.Size(556, 22);
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
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label5.Location = new System.Drawing.Point(293, 282);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 15);
            this.label5.TabIndex = 24;
            this.label5.Text = "Parsed Results";
            // 
            // ParsedResults
            // 
            this.ParsedResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.ParsedResults.Location = new System.Drawing.Point(293, 300);
            this.ParsedResults.Name = "ParsedResults";
            this.ParsedResults.RowHeadersVisible = false;
            this.ParsedResults.RowTemplate.Height = 25;
            this.ParsedResults.Size = new System.Drawing.Size(273, 311);
            this.ParsedResults.TabIndex = 23;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(14, 282);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 15);
            this.label3.TabIndex = 22;
            this.label3.Text = "Raw Results";
            // 
            // RawResults
            // 
            this.RawResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.RawResults.Location = new System.Drawing.Point(14, 300);
            this.RawResults.Name = "RawResults";
            this.RawResults.RowHeadersVisible = false;
            this.RawResults.RowTemplate.Height = 25;
            this.RawResults.Size = new System.Drawing.Size(273, 311);
            this.RawResults.TabIndex = 21;
            // 
            // FromImageButton
            // 
            this.FromImageButton.Location = new System.Drawing.Point(448, 106);
            this.FromImageButton.Name = "FromImageButton";
            this.FromImageButton.Size = new System.Drawing.Size(115, 35);
            this.FromImageButton.TabIndex = 19;
            this.FromImageButton.Text = "From Image";
            this.FromImageButton.UseVisualStyleBackColor = true;
            this.FromImageButton.Click += new System.EventHandler(this.FromImageButton_Click);
            // 
            // ExportPricesButton
            // 
            this.ExportPricesButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ExportPricesButton.Location = new System.Drawing.Point(290, 147);
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
            this.TakeScreenshotButton.Location = new System.Drawing.Point(14, 147);
            this.TakeScreenshotButton.Name = "TakeScreenshotButton";
            this.TakeScreenshotButton.Size = new System.Drawing.Size(273, 120);
            this.TakeScreenshotButton.TabIndex = 11;
            this.TakeScreenshotButton.Text = "Capture Screen and Extract Prices (F11)";
            this.TakeScreenshotButton.UseVisualStyleBackColor = true;
            this.TakeScreenshotButton.Click += new System.EventHandler(this.OnTakeScreenshotButton_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label7.Location = new System.Drawing.Point(14, 619);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(80, 15);
            this.label7.TabIndex = 29;
            this.label7.Text = "Performance";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1473, 801);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Trading Post Data Extractor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView RawResults;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView ParsedResults;
        private System.Windows.Forms.StatusStrip StatusBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarLabel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox LanguageDropdown;
        private System.Windows.Forms.DataGridView PerformanceGrid;
        private System.Windows.Forms.Label label7;
    }
}

