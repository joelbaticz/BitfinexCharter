namespace BitfinexCharter
{
    partial class CheckDBForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lblNoOfCandles = new System.Windows.Forms.Label();
            this.lblNoOfCandlesActual = new System.Windows.Forms.Label();
            this.lblNoOfProcessedCandlesActual = new System.Windows.Forms.Label();
            this.lblNoOfProcessedCandles = new System.Windows.Forms.Label();
            this.lblMissingCandles = new System.Windows.Forms.Label();
            this.lblMissingCandlesActual = new System.Windows.Forms.Label();
            this.llDuplicateCandles = new System.Windows.Forms.Label();
            this.lblDuplicateCandlesActual = new System.Windows.Forms.Label();
            this.lblFixedRecords = new System.Windows.Forms.Label();
            this.lblFixedRecordsActual = new System.Windows.Forms.Label();
            this.btnStart = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.prgCheck = new System.Windows.Forms.ProgressBar();
            this.btnStop = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblNoOfCandles
            // 
            this.lblNoOfCandles.AutoSize = true;
            this.lblNoOfCandles.Location = new System.Drawing.Point(13, 13);
            this.lblNoOfCandles.Name = "lblNoOfCandles";
            this.lblNoOfCandles.Size = new System.Drawing.Size(160, 25);
            this.lblNoOfCandles.TabIndex = 0;
            this.lblNoOfCandles.Text = "No. of Candles:";
            // 
            // lblNoOfCandlesActual
            // 
            this.lblNoOfCandlesActual.AutoSize = true;
            this.lblNoOfCandlesActual.Location = new System.Drawing.Point(205, 13);
            this.lblNoOfCandlesActual.Name = "lblNoOfCandlesActual";
            this.lblNoOfCandlesActual.Size = new System.Drawing.Size(47, 25);
            this.lblNoOfCandlesActual.TabIndex = 1;
            this.lblNoOfCandlesActual.Text = "N/A";
            // 
            // lblNoOfProcessedCandlesActual
            // 
            this.lblNoOfProcessedCandlesActual.AutoSize = true;
            this.lblNoOfProcessedCandlesActual.Location = new System.Drawing.Point(205, 50);
            this.lblNoOfProcessedCandlesActual.Name = "lblNoOfProcessedCandlesActual";
            this.lblNoOfProcessedCandlesActual.Size = new System.Drawing.Size(47, 25);
            this.lblNoOfProcessedCandlesActual.TabIndex = 2;
            this.lblNoOfProcessedCandlesActual.Text = "N/A";
            // 
            // lblNoOfProcessedCandles
            // 
            this.lblNoOfProcessedCandles.AutoSize = true;
            this.lblNoOfProcessedCandles.Location = new System.Drawing.Point(13, 50);
            this.lblNoOfProcessedCandles.Name = "lblNoOfProcessedCandles";
            this.lblNoOfProcessedCandles.Size = new System.Drawing.Size(120, 25);
            this.lblNoOfProcessedCandles.TabIndex = 3;
            this.lblNoOfProcessedCandles.Text = "Processed:";
            // 
            // lblMissingCandles
            // 
            this.lblMissingCandles.AutoSize = true;
            this.lblMissingCandles.Location = new System.Drawing.Point(13, 89);
            this.lblMissingCandles.Name = "lblMissingCandles";
            this.lblMissingCandles.Size = new System.Drawing.Size(170, 25);
            this.lblMissingCandles.TabIndex = 5;
            this.lblMissingCandles.Text = "Missing records:";
            // 
            // lblMissingCandlesActual
            // 
            this.lblMissingCandlesActual.AutoSize = true;
            this.lblMissingCandlesActual.Location = new System.Drawing.Point(205, 89);
            this.lblMissingCandlesActual.Name = "lblMissingCandlesActual";
            this.lblMissingCandlesActual.Size = new System.Drawing.Size(47, 25);
            this.lblMissingCandlesActual.TabIndex = 4;
            this.lblMissingCandlesActual.Text = "N/A";
            // 
            // llDuplicateCandles
            // 
            this.llDuplicateCandles.AutoSize = true;
            this.llDuplicateCandles.Location = new System.Drawing.Point(13, 130);
            this.llDuplicateCandles.Name = "llDuplicateCandles";
            this.llDuplicateCandles.Size = new System.Drawing.Size(186, 25);
            this.llDuplicateCandles.TabIndex = 7;
            this.llDuplicateCandles.Text = "Duplicate records:";
            // 
            // lblDuplicateCandlesActual
            // 
            this.lblDuplicateCandlesActual.AutoSize = true;
            this.lblDuplicateCandlesActual.Location = new System.Drawing.Point(205, 130);
            this.lblDuplicateCandlesActual.Name = "lblDuplicateCandlesActual";
            this.lblDuplicateCandlesActual.Size = new System.Drawing.Size(47, 25);
            this.lblDuplicateCandlesActual.TabIndex = 6;
            this.lblDuplicateCandlesActual.Text = "N/A";
            // 
            // lblFixedRecords
            // 
            this.lblFixedRecords.AutoSize = true;
            this.lblFixedRecords.Location = new System.Drawing.Point(13, 172);
            this.lblFixedRecords.Name = "lblFixedRecords";
            this.lblFixedRecords.Size = new System.Drawing.Size(149, 25);
            this.lblFixedRecords.TabIndex = 8;
            this.lblFixedRecords.Text = "Fixed records:";
            // 
            // lblFixedRecordsActual
            // 
            this.lblFixedRecordsActual.AutoSize = true;
            this.lblFixedRecordsActual.Location = new System.Drawing.Point(205, 172);
            this.lblFixedRecordsActual.Name = "lblFixedRecordsActual";
            this.lblFixedRecordsActual.Size = new System.Drawing.Size(47, 25);
            this.lblFixedRecordsActual.TabIndex = 9;
            this.lblFixedRecordsActual.Text = "N/A";
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(18, 211);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(619, 67);
            this.btnStart.TabIndex = 10;
            this.btnStart.Text = "Check 1m Candles";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 505);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(649, 37);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlblStatus
            // 
            this.tlblStatus.Name = "tlblStatus";
            this.tlblStatus.Size = new System.Drawing.Size(30, 32);
            this.tlblStatus.Text = "...";
            // 
            // prgCheck
            // 
            this.prgCheck.Location = new System.Drawing.Point(18, 285);
            this.prgCheck.Name = "prgCheck";
            this.prgCheck.Size = new System.Drawing.Size(619, 67);
            this.prgCheck.TabIndex = 12;
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(18, 359);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(619, 79);
            this.btnStop.TabIndex = 13;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // CheckDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(649, 542);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.prgCheck);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnStart);
            this.Controls.Add(this.lblFixedRecordsActual);
            this.Controls.Add(this.lblFixedRecords);
            this.Controls.Add(this.llDuplicateCandles);
            this.Controls.Add(this.lblDuplicateCandlesActual);
            this.Controls.Add(this.lblMissingCandles);
            this.Controls.Add(this.lblMissingCandlesActual);
            this.Controls.Add(this.lblNoOfProcessedCandles);
            this.Controls.Add(this.lblNoOfProcessedCandlesActual);
            this.Controls.Add(this.lblNoOfCandlesActual);
            this.Controls.Add(this.lblNoOfCandles);
            this.Name = "CheckDBForm";
            this.Text = "CheckDBProgressForm";
            this.Load += new System.EventHandler(this.CheckDBForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblNoOfCandles;
        private System.Windows.Forms.Label lblNoOfCandlesActual;
        private System.Windows.Forms.Label lblNoOfProcessedCandlesActual;
        private System.Windows.Forms.Label lblNoOfProcessedCandles;
        private System.Windows.Forms.Label lblMissingCandles;
        private System.Windows.Forms.Label lblMissingCandlesActual;
        private System.Windows.Forms.Label llDuplicateCandles;
        private System.Windows.Forms.Label lblDuplicateCandlesActual;
        private System.Windows.Forms.Label lblFixedRecords;
        private System.Windows.Forms.Label lblFixedRecordsActual;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlblStatus;
        private System.Windows.Forms.ProgressBar prgCheck;
        private System.Windows.Forms.Button btnStop;
    }
}