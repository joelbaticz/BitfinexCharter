namespace BitfinexCharter
{
    partial class CreateCandlesForm
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
            this.lblSource = new System.Windows.Forms.Label();
            this.lblDestination = new System.Windows.Forms.Label();
            this.cbDestination = new System.Windows.Forms.ComboBox();
            this.cbSource = new System.Windows.Forms.ComboBox();
            this.btnCreate = new System.Windows.Forms.Button();
            this.lblSourceRecords = new System.Windows.Forms.Label();
            this.lblSourceRecordsActual = new System.Windows.Forms.Label();
            this.lblRecordsToBeMadeActual = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.prgCreate = new System.Windows.Forms.ProgressBar();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnStop = new System.Windows.Forms.Button();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSource
            // 
            this.lblSource.AutoSize = true;
            this.lblSource.Location = new System.Drawing.Point(13, 13);
            this.lblSource.Name = "lblSource";
            this.lblSource.Size = new System.Drawing.Size(86, 25);
            this.lblSource.TabIndex = 0;
            this.lblSource.Text = "Source:";
            // 
            // lblDestination
            // 
            this.lblDestination.AutoSize = true;
            this.lblDestination.Location = new System.Drawing.Point(13, 62);
            this.lblDestination.Name = "lblDestination";
            this.lblDestination.Size = new System.Drawing.Size(126, 25);
            this.lblDestination.TabIndex = 1;
            this.lblDestination.Text = "Destination:";
            // 
            // cbDestination
            // 
            this.cbDestination.FormattingEnabled = true;
            this.cbDestination.Items.AddRange(new object[] {
            "5 minutes",
            "15 minutes",
            "30 minutes",
            "1 hour"});
            this.cbDestination.Location = new System.Drawing.Point(145, 59);
            this.cbDestination.Name = "cbDestination";
            this.cbDestination.Size = new System.Drawing.Size(297, 33);
            this.cbDestination.TabIndex = 2;
            this.cbDestination.Text = "5 minutes";
            this.cbDestination.SelectedIndexChanged += new System.EventHandler(this.cbDestination_SelectedIndexChanged);
            // 
            // cbSource
            // 
            this.cbSource.FormattingEnabled = true;
            this.cbSource.Items.AddRange(new object[] {
            "1 minute",
            "5 minutes",
            "15 minutes",
            "30 minutes",
            "1 hour"});
            this.cbSource.Location = new System.Drawing.Point(145, 10);
            this.cbSource.Name = "cbSource";
            this.cbSource.Size = new System.Drawing.Size(297, 33);
            this.cbSource.TabIndex = 3;
            this.cbSource.Text = "1 minute";
            this.cbSource.SelectedIndexChanged += new System.EventHandler(this.cbSource_SelectedIndexChanged);
            // 
            // btnCreate
            // 
            this.btnCreate.Location = new System.Drawing.Point(18, 103);
            this.btnCreate.Name = "btnCreate";
            this.btnCreate.Size = new System.Drawing.Size(424, 116);
            this.btnCreate.TabIndex = 4;
            this.btnCreate.Text = "Create Candles";
            this.btnCreate.UseVisualStyleBackColor = true;
            this.btnCreate.Click += new System.EventHandler(this.btnCreate_Click);
            // 
            // lblSourceRecords
            // 
            this.lblSourceRecords.AutoSize = true;
            this.lblSourceRecords.Location = new System.Drawing.Point(18, 250);
            this.lblSourceRecords.Name = "lblSourceRecords";
            this.lblSourceRecords.Size = new System.Drawing.Size(172, 25);
            this.lblSourceRecords.TabIndex = 5;
            this.lblSourceRecords.Text = "Source Records:";
            // 
            // lblSourceRecordsActual
            // 
            this.lblSourceRecordsActual.AutoSize = true;
            this.lblSourceRecordsActual.Location = new System.Drawing.Point(237, 250);
            this.lblSourceRecordsActual.Name = "lblSourceRecordsActual";
            this.lblSourceRecordsActual.Size = new System.Drawing.Size(47, 25);
            this.lblSourceRecordsActual.TabIndex = 6;
            this.lblSourceRecordsActual.Text = "N/A";
            // 
            // lblRecordsToBeMadeActual
            // 
            this.lblRecordsToBeMadeActual.AutoSize = true;
            this.lblRecordsToBeMadeActual.Location = new System.Drawing.Point(237, 290);
            this.lblRecordsToBeMadeActual.Name = "lblRecordsToBeMadeActual";
            this.lblRecordsToBeMadeActual.Size = new System.Drawing.Size(47, 25);
            this.lblRecordsToBeMadeActual.TabIndex = 8;
            this.lblRecordsToBeMadeActual.Text = "N/A";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 290);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 25);
            this.label2.TabIndex = 7;
            this.label2.Text = "Records to be made:";
            // 
            // prgCreate
            // 
            this.prgCreate.Location = new System.Drawing.Point(23, 329);
            this.prgCreate.Name = "prgCreate";
            this.prgCreate.Size = new System.Drawing.Size(419, 58);
            this.prgCreate.TabIndex = 9;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 477);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(462, 38);
            this.statusStrip1.TabIndex = 10;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlblStatus
            // 
            this.tlblStatus.Name = "tlblStatus";
            this.tlblStatus.Size = new System.Drawing.Size(30, 33);
            this.tlblStatus.Text = "...";
            // 
            // btnStop
            // 
            this.btnStop.Location = new System.Drawing.Point(23, 394);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(419, 60);
            this.btnStop.TabIndex = 11;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // CreateCandlesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 515);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.prgCreate);
            this.Controls.Add(this.lblRecordsToBeMadeActual);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblSourceRecordsActual);
            this.Controls.Add(this.lblSourceRecords);
            this.Controls.Add(this.btnCreate);
            this.Controls.Add(this.cbSource);
            this.Controls.Add(this.cbDestination);
            this.Controls.Add(this.lblDestination);
            this.Controls.Add(this.lblSource);
            this.Name = "CreateCandlesForm";
            this.Text = "CreateCandlesForm";
            this.Load += new System.EventHandler(this.CreateCandlesForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSource;
        private System.Windows.Forms.Label lblDestination;
        private System.Windows.Forms.ComboBox cbDestination;
        private System.Windows.Forms.ComboBox cbSource;
        private System.Windows.Forms.Button btnCreate;
        private System.Windows.Forms.Label lblSourceRecords;
        private System.Windows.Forms.Label lblSourceRecordsActual;
        private System.Windows.Forms.Label lblRecordsToBeMadeActual;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ProgressBar prgCreate;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlblStatus;
        private System.Windows.Forms.Button btnStop;
    }
}