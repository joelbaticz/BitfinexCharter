namespace BitfinexCharter
{
    partial class LearningForm
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
            this.btnLearn = new System.Windows.Forms.Button();
            this.grpCurrentSet = new System.Windows.Forms.GroupBox();
            this.btnPreviousCandle = new System.Windows.Forms.Button();
            this.btnNextCandle = new System.Windows.Forms.Button();
            this.lblStartRecordActual = new System.Windows.Forms.Label();
            this.lblStartRecord = new System.Windows.Forms.Label();
            this.picCandleChart = new System.Windows.Forms.PictureBox();
            this.btnPredict = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblResolution = new System.Windows.Forms.Label();
            this.cbResolution = new System.Windows.Forms.ComboBox();
            this.lblNoOfCandles = new System.Windows.Forms.Label();
            this.cbNoOfCandles = new System.Windows.Forms.ComboBox();
            this.btnStop = new System.Windows.Forms.Button();
            this.prgLearn = new System.Windows.Forms.ProgressBar();
            this.lbFeatures = new System.Windows.Forms.ListBox();
            this.btnSort = new System.Windows.Forms.Button();
            this.grpCurrentSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCandleChart)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnLearn
            // 
            this.btnLearn.Location = new System.Drawing.Point(12, 12);
            this.btnLearn.Name = "btnLearn";
            this.btnLearn.Size = new System.Drawing.Size(239, 67);
            this.btnLearn.TabIndex = 1;
            this.btnLearn.Text = "Learn...";
            this.btnLearn.UseVisualStyleBackColor = true;
            this.btnLearn.Click += new System.EventHandler(this.btnLearn_Click);
            // 
            // grpCurrentSet
            // 
            this.grpCurrentSet.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpCurrentSet.Controls.Add(this.btnPreviousCandle);
            this.grpCurrentSet.Controls.Add(this.btnNextCandle);
            this.grpCurrentSet.Controls.Add(this.lblStartRecordActual);
            this.grpCurrentSet.Controls.Add(this.lblStartRecord);
            this.grpCurrentSet.Controls.Add(this.picCandleChart);
            this.grpCurrentSet.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCurrentSet.Location = new System.Drawing.Point(12, 140);
            this.grpCurrentSet.Name = "grpCurrentSet";
            this.grpCurrentSet.Size = new System.Drawing.Size(1534, 654);
            this.grpCurrentSet.TabIndex = 2;
            this.grpCurrentSet.TabStop = false;
            this.grpCurrentSet.Text = "Current Set";
            // 
            // btnPreviousCandle
            // 
            this.btnPreviousCandle.Location = new System.Drawing.Point(479, 22);
            this.btnPreviousCandle.Name = "btnPreviousCandle";
            this.btnPreviousCandle.Size = new System.Drawing.Size(61, 52);
            this.btnPreviousCandle.TabIndex = 4;
            this.btnPreviousCandle.Text = "<<";
            this.btnPreviousCandle.UseVisualStyleBackColor = true;
            this.btnPreviousCandle.Click += new System.EventHandler(this.btnPreviousCandle_Click);
            // 
            // btnNextCandle
            // 
            this.btnNextCandle.Location = new System.Drawing.Point(545, 22);
            this.btnNextCandle.Name = "btnNextCandle";
            this.btnNextCandle.Size = new System.Drawing.Size(61, 52);
            this.btnNextCandle.TabIndex = 3;
            this.btnNextCandle.Text = ">>";
            this.btnNextCandle.UseVisualStyleBackColor = true;
            this.btnNextCandle.Click += new System.EventHandler(this.btnNextCandle_Click);
            // 
            // lblStartRecordActual
            // 
            this.lblStartRecordActual.AutoSize = true;
            this.lblStartRecordActual.Location = new System.Drawing.Point(138, 30);
            this.lblStartRecordActual.Name = "lblStartRecordActual";
            this.lblStartRecordActual.Size = new System.Drawing.Size(46, 25);
            this.lblStartRecordActual.TabIndex = 2;
            this.lblStartRecordActual.Text = "N/A";
            // 
            // lblStartRecord
            // 
            this.lblStartRecord.AutoSize = true;
            this.lblStartRecord.Location = new System.Drawing.Point(6, 30);
            this.lblStartRecord.Name = "lblStartRecord";
            this.lblStartRecord.Size = new System.Drawing.Size(126, 25);
            this.lblStartRecord.TabIndex = 1;
            this.lblStartRecord.Text = "Start Record:";
            // 
            // picCandleChart
            // 
            this.picCandleChart.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.picCandleChart.Location = new System.Drawing.Point(6, 85);
            this.picCandleChart.Name = "picCandleChart";
            this.picCandleChart.Size = new System.Drawing.Size(1233, 563);
            this.picCandleChart.TabIndex = 0;
            this.picCandleChart.TabStop = false;
            // 
            // btnPredict
            // 
            this.btnPredict.Location = new System.Drawing.Point(687, 12);
            this.btnPredict.Name = "btnPredict";
            this.btnPredict.Size = new System.Drawing.Size(225, 67);
            this.btnPredict.TabIndex = 3;
            this.btnPredict.Text = "Predict";
            this.btnPredict.UseVisualStyleBackColor = true;
            this.btnPredict.Click += new System.EventHandler(this.btnPredict_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 819);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(1, 0, 13, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1851, 35);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlblStatus
            // 
            this.tlblStatus.Name = "tlblStatus";
            this.tlblStatus.Size = new System.Drawing.Size(28, 30);
            this.tlblStatus.Text = "...";
            // 
            // lblResolution
            // 
            this.lblResolution.AutoSize = true;
            this.lblResolution.Location = new System.Drawing.Point(918, 12);
            this.lblResolution.Name = "lblResolution";
            this.lblResolution.Size = new System.Drawing.Size(109, 25);
            this.lblResolution.TabIndex = 5;
            this.lblResolution.Text = "Resolution:";
            // 
            // cbResolution
            // 
            this.cbResolution.FormattingEnabled = true;
            this.cbResolution.Items.AddRange(new object[] {
            "1m",
            "5m",
            "15m",
            "30m",
            "1hr"});
            this.cbResolution.Location = new System.Drawing.Point(1067, 10);
            this.cbResolution.Name = "cbResolution";
            this.cbResolution.Size = new System.Drawing.Size(195, 32);
            this.cbResolution.TabIndex = 6;
            this.cbResolution.Text = "1m";
            this.cbResolution.SelectedIndexChanged += new System.EventHandler(this.cbResolution_SelectedIndexChanged);
            // 
            // lblNoOfCandles
            // 
            this.lblNoOfCandles.AutoSize = true;
            this.lblNoOfCandles.Location = new System.Drawing.Point(918, 55);
            this.lblNoOfCandles.Name = "lblNoOfCandles";
            this.lblNoOfCandles.Size = new System.Drawing.Size(147, 25);
            this.lblNoOfCandles.TabIndex = 7;
            this.lblNoOfCandles.Text = "No. of Candles:";
            // 
            // cbNoOfCandles
            // 
            this.cbNoOfCandles.FormattingEnabled = true;
            this.cbNoOfCandles.Items.AddRange(new object[] {
            "15",
            "30",
            "60",
            "120",
            "150",
            "300",
            "600"});
            this.cbNoOfCandles.Location = new System.Drawing.Point(1067, 47);
            this.cbNoOfCandles.Name = "cbNoOfCandles";
            this.cbNoOfCandles.Size = new System.Drawing.Size(195, 32);
            this.cbNoOfCandles.TabIndex = 8;
            this.cbNoOfCandles.Text = "60";
            this.cbNoOfCandles.SelectedIndexChanged += new System.EventHandler(this.cbNoOfCandles_SelectedIndexChanged);
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(257, 12);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(209, 67);
            this.btnStop.TabIndex = 9;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // prgLearn
            // 
            this.prgLearn.Location = new System.Drawing.Point(12, 86);
            this.prgLearn.Name = "prgLearn";
            this.prgLearn.Size = new System.Drawing.Size(1039, 26);
            this.prgLearn.TabIndex = 10;
            // 
            // lbFeatures
            // 
            this.lbFeatures.Dock = System.Windows.Forms.DockStyle.Right;
            this.lbFeatures.FormattingEnabled = true;
            this.lbFeatures.ItemHeight = 24;
            this.lbFeatures.Location = new System.Drawing.Point(1272, 0);
            this.lbFeatures.Name = "lbFeatures";
            this.lbFeatures.Size = new System.Drawing.Size(579, 819);
            this.lbFeatures.TabIndex = 11;
            // 
            // btnSort
            // 
            this.btnSort.Location = new System.Drawing.Point(472, 12);
            this.btnSort.Name = "btnSort";
            this.btnSort.Size = new System.Drawing.Size(209, 67);
            this.btnSort.TabIndex = 12;
            this.btnSort.Text = "Collate/Sort";
            this.btnSort.UseVisualStyleBackColor = true;
            this.btnSort.Click += new System.EventHandler(this.btnSort_Click);
            // 
            // LearningForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1851, 854);
            this.Controls.Add(this.btnSort);
            this.Controls.Add(this.lbFeatures);
            this.Controls.Add(this.prgLearn);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.cbNoOfCandles);
            this.Controls.Add(this.lblNoOfCandles);
            this.Controls.Add(this.cbResolution);
            this.Controls.Add(this.lblResolution);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnPredict);
            this.Controls.Add(this.grpCurrentSet);
            this.Controls.Add(this.btnLearn);
            this.Name = "LearningForm";
            this.Text = "Learning";
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.grpCurrentSet.ResumeLayout(false);
            this.grpCurrentSet.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCandleChart)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnLearn;
        private System.Windows.Forms.GroupBox grpCurrentSet;
        private System.Windows.Forms.PictureBox picCandleChart;
        private System.Windows.Forms.Label lblStartRecordActual;
        private System.Windows.Forms.Label lblStartRecord;
        private System.Windows.Forms.Button btnNextCandle;
        private System.Windows.Forms.Button btnPreviousCandle;
        private System.Windows.Forms.Button btnPredict;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlblStatus;
        private System.Windows.Forms.Label lblResolution;
        private System.Windows.Forms.ComboBox cbResolution;
        private System.Windows.Forms.Label lblNoOfCandles;
        private System.Windows.Forms.ComboBox cbNoOfCandles;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.ProgressBar prgLearn;
        private System.Windows.Forms.ListBox lbFeatures;
        private System.Windows.Forms.Button btnSort;
    }
}