namespace BitfinexCharter
{
    partial class UpdateDBForm
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
            this.lblLatestTimeStamp = new System.Windows.Forms.Label();
            this.lblRecordsProcessed = new System.Windows.Forms.Label();
            this.lblEarliestTimeStamp = new System.Windows.Forms.Label();
            this.lblEarliestTimeStampActual = new System.Windows.Forms.Label();
            this.lblRecordsProcessedActual = new System.Windows.Forms.Label();
            this.lblLatestTimeStampActual = new System.Windows.Forms.Label();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.prgUpdate = new System.Windows.Forms.ProgressBar();
            this.btnStop = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblLatestTimeStamp
            // 
            this.lblLatestTimeStamp.AutoSize = true;
            this.lblLatestTimeStamp.Location = new System.Drawing.Point(12, 13);
            this.lblLatestTimeStamp.Name = "lblLatestTimeStamp";
            this.lblLatestTimeStamp.Size = new System.Drawing.Size(191, 25);
            this.lblLatestTimeStamp.TabIndex = 0;
            this.lblLatestTimeStamp.Text = "Latest TimeStamp:";
            // 
            // lblRecordsProcessed
            // 
            this.lblRecordsProcessed.AutoSize = true;
            this.lblRecordsProcessed.Location = new System.Drawing.Point(12, 98);
            this.lblRecordsProcessed.Name = "lblRecordsProcessed";
            this.lblRecordsProcessed.Size = new System.Drawing.Size(206, 25);
            this.lblRecordsProcessed.TabIndex = 1;
            this.lblRecordsProcessed.Text = "Records Processed:";
            // 
            // lblEarliestTimeStamp
            // 
            this.lblEarliestTimeStamp.AutoSize = true;
            this.lblEarliestTimeStamp.Location = new System.Drawing.Point(12, 55);
            this.lblEarliestTimeStamp.Name = "lblEarliestTimeStamp";
            this.lblEarliestTimeStamp.Size = new System.Drawing.Size(204, 25);
            this.lblEarliestTimeStamp.TabIndex = 2;
            this.lblEarliestTimeStamp.Text = "Earliest TimeStamp:";
            // 
            // lblEarliestTimeStampActual
            // 
            this.lblEarliestTimeStampActual.AutoSize = true;
            this.lblEarliestTimeStampActual.Location = new System.Drawing.Point(272, 55);
            this.lblEarliestTimeStampActual.Name = "lblEarliestTimeStampActual";
            this.lblEarliestTimeStampActual.Size = new System.Drawing.Size(47, 25);
            this.lblEarliestTimeStampActual.TabIndex = 5;
            this.lblEarliestTimeStampActual.Text = "N/A";
            // 
            // lblRecordsProcessedActual
            // 
            this.lblRecordsProcessedActual.AutoSize = true;
            this.lblRecordsProcessedActual.Location = new System.Drawing.Point(272, 98);
            this.lblRecordsProcessedActual.Name = "lblRecordsProcessedActual";
            this.lblRecordsProcessedActual.Size = new System.Drawing.Size(47, 25);
            this.lblRecordsProcessedActual.TabIndex = 4;
            this.lblRecordsProcessedActual.Text = "N/A";
            // 
            // lblLatestTimeStampActual
            // 
            this.lblLatestTimeStampActual.AutoSize = true;
            this.lblLatestTimeStampActual.Location = new System.Drawing.Point(272, 13);
            this.lblLatestTimeStampActual.Name = "lblLatestTimeStampActual";
            this.lblLatestTimeStampActual.Size = new System.Drawing.Size(47, 25);
            this.lblLatestTimeStampActual.TabIndex = 3;
            this.lblLatestTimeStampActual.Text = "N/A";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(17, 151);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(643, 72);
            this.btnUpdate.TabIndex = 8;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // prgUpdate
            // 
            this.prgUpdate.Location = new System.Drawing.Point(17, 230);
            this.prgUpdate.Name = "prgUpdate";
            this.prgUpdate.Size = new System.Drawing.Size(643, 35);
            this.prgUpdate.TabIndex = 9;
            // 
            // btnStop
            // 
            this.btnStop.Enabled = false;
            this.btnStop.Location = new System.Drawing.Point(17, 271);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(643, 72);
            this.btnStop.TabIndex = 10;
            this.btnStop.Text = "Stop";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 357);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(672, 37);
            this.statusStrip1.TabIndex = 11;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlblStatus
            // 
            this.tlblStatus.Name = "tlblStatus";
            this.tlblStatus.Size = new System.Drawing.Size(30, 32);
            this.tlblStatus.Text = "...";
            // 
            // UpdateDBForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 394);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.prgUpdate);
            this.Controls.Add(this.btnUpdate);
            this.Controls.Add(this.lblEarliestTimeStampActual);
            this.Controls.Add(this.lblRecordsProcessedActual);
            this.Controls.Add(this.lblLatestTimeStampActual);
            this.Controls.Add(this.lblEarliestTimeStamp);
            this.Controls.Add(this.lblRecordsProcessed);
            this.Controls.Add(this.lblLatestTimeStamp);
            this.Name = "UpdateDBForm";
            this.Text = "Updating DB...";
            this.Load += new System.EventHandler(this.UpdateDBProgressForm_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblLatestTimeStamp;
        private System.Windows.Forms.Label lblRecordsProcessed;
        private System.Windows.Forms.Label lblEarliestTimeStamp;
        private System.Windows.Forms.Label lblEarliestTimeStampActual;
        private System.Windows.Forms.Label lblRecordsProcessedActual;
        private System.Windows.Forms.Label lblLatestTimeStampActual;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.ProgressBar prgUpdate;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlblStatus;
    }
}