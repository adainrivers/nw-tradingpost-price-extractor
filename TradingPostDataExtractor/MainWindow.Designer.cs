
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
            this.TakeScreenshotButton = new System.Windows.Forms.Button();
            this.ImagePreview = new System.Windows.Forms.PictureBox();
            this.TimerNewWorldStatus = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.NewWorldStatus = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CapturedPricesCount = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.TotalItems = new System.Windows.Forms.Label();
            this.ExportPricesButton = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.TimerProcessRefresher = new System.Windows.Forms.Timer(this.components);
            this.ExportPricesSaveDialog = new System.Windows.Forms.SaveFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreview)).BeginInit();
            this.SuspendLayout();
            // 
            // TakeScreenshotButton
            // 
            this.TakeScreenshotButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.TakeScreenshotButton.Location = new System.Drawing.Point(659, 145);
            this.TakeScreenshotButton.Name = "TakeScreenshotButton";
            this.TakeScreenshotButton.Size = new System.Drawing.Size(226, 120);
            this.TakeScreenshotButton.TabIndex = 0;
            this.TakeScreenshotButton.Text = "Capture Screen and Extract Prices (CTRL-H)";
            this.TakeScreenshotButton.UseVisualStyleBackColor = true;
            this.TakeScreenshotButton.Click += new System.EventHandler(this.OnTakeScreenshotButton_Click);
            // 
            // ImagePreview
            // 
            this.ImagePreview.Location = new System.Drawing.Point(12, 12);
            this.ImagePreview.Name = "ImagePreview";
            this.ImagePreview.Size = new System.Drawing.Size(640, 360);
            this.ImagePreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ImagePreview.TabIndex = 1;
            this.ImagePreview.TabStop = false;
            // 
            // TimerNewWorldStatus
            // 
            this.TimerNewWorldStatus.Enabled = true;
            this.TimerNewWorldStatus.Tick += new System.EventHandler(this.TimerNewWorldStatus_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(658, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 2;
            this.label1.Text = "New World";
            // 
            // NewWorldStatus
            // 
            this.NewWorldStatus.AutoSize = true;
            this.NewWorldStatus.Location = new System.Drawing.Point(788, 12);
            this.NewWorldStatus.Name = "NewWorldStatus";
            this.NewWorldStatus.Size = new System.Drawing.Size(52, 15);
            this.NewWorldStatus.TabIndex = 3;
            this.NewWorldStatus.Text = "Running";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(658, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(130, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Captured Prices Count";
            // 
            // CapturedPricesCount
            // 
            this.CapturedPricesCount.AutoSize = true;
            this.CapturedPricesCount.Location = new System.Drawing.Point(788, 37);
            this.CapturedPricesCount.Name = "CapturedPricesCount";
            this.CapturedPricesCount.Size = new System.Drawing.Size(13, 15);
            this.CapturedPricesCount.TabIndex = 5;
            this.CapturedPricesCount.Text = "0";
            this.CapturedPricesCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label4.Location = new System.Drawing.Point(658, 62);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(69, 15);
            this.label4.TabIndex = 6;
            this.label4.Text = "Total Items";
            // 
            // TotalItems
            // 
            this.TotalItems.AutoSize = true;
            this.TotalItems.Location = new System.Drawing.Point(788, 62);
            this.TotalItems.Name = "TotalItems";
            this.TotalItems.Size = new System.Drawing.Size(13, 15);
            this.TotalItems.TabIndex = 7;
            this.TotalItems.Text = "0";
            this.TotalItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ExportPricesButton
            // 
            this.ExportPricesButton.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ExportPricesButton.Location = new System.Drawing.Point(659, 271);
            this.ExportPricesButton.Name = "ExportPricesButton";
            this.ExportPricesButton.Size = new System.Drawing.Size(226, 101);
            this.ExportPricesButton.TabIndex = 8;
            this.ExportPricesButton.Text = "Export Prices";
            this.ExportPricesButton.UseVisualStyleBackColor = true;
            this.ExportPricesButton.Click += new System.EventHandler(this.ExportPricesButton_Click);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(897, 384);
            this.Controls.Add(this.ExportPricesButton);
            this.Controls.Add(this.TotalItems);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CapturedPricesCount);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NewWorldStatus);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ImagePreview);
            this.Controls.Add(this.TakeScreenshotButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Trading Post Data Extractor";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ImagePreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button TakeScreenshotButton;
        private System.Windows.Forms.PictureBox ImagePreview;
        private System.Windows.Forms.Timer TimerNewWorldStatus;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label NewWorldStatus;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label CapturedPricesCount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label TotalItems;
        private System.Windows.Forms.Button ExportPricesButton;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Timer TimerProcessRefresher;
        private System.Windows.Forms.SaveFileDialog ExportPricesSaveDialog;
    }
}

