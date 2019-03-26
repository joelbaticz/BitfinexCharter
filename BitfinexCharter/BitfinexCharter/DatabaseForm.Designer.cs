namespace BitfinexCharter
{
    partial class DatabaseForm
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
            this.btnUpdateDB = new System.Windows.Forms.Button();
            this.btnCheckDB = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCreateOtherCandles = new System.Windows.Forms.Button();
            this.brnRunBackground = new System.Windows.Forms.Button();
            this.lblStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnUpdateDB
            // 
            this.btnUpdateDB.Location = new System.Drawing.Point(12, 68);
            this.btnUpdateDB.Name = "btnUpdateDB";
            this.btnUpdateDB.Size = new System.Drawing.Size(487, 44);
            this.btnUpdateDB.TabIndex = 2;
            this.btnUpdateDB.Text = "Update Database...";
            this.btnUpdateDB.UseVisualStyleBackColor = true;
            this.btnUpdateDB.Click += new System.EventHandler(this.btnUpdateDB_Click);
            // 
            // btnCheckDB
            // 
            this.btnCheckDB.Location = new System.Drawing.Point(12, 118);
            this.btnCheckDB.Name = "btnCheckDB";
            this.btnCheckDB.Size = new System.Drawing.Size(487, 44);
            this.btnCheckDB.TabIndex = 7;
            this.btnCheckDB.Text = "Check Database Entries...";
            this.btnCheckDB.UseVisualStyleBackColor = true;
            this.btnCheckDB.Click += new System.EventHandler(this.btnCheckDB_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Location = new System.Drawing.Point(12, 13);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(487, 49);
            this.btnDelete.TabIndex = 8;
            this.btnDelete.Text = "Delete Candle Records";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCreateOtherCandles
            // 
            this.btnCreateOtherCandles.Location = new System.Drawing.Point(12, 169);
            this.btnCreateOtherCandles.Name = "btnCreateOtherCandles";
            this.btnCreateOtherCandles.Size = new System.Drawing.Size(487, 54);
            this.btnCreateOtherCandles.TabIndex = 9;
            this.btnCreateOtherCandles.Text = "Create Other Candles...";
            this.btnCreateOtherCandles.UseVisualStyleBackColor = true;
            this.btnCreateOtherCandles.Click += new System.EventHandler(this.btnCreateOtherCandles_Click);
            // 
            // brnRunBackground
            // 
            this.brnRunBackground.Location = new System.Drawing.Point(12, 286);
            this.brnRunBackground.Name = "brnRunBackground";
            this.brnRunBackground.Size = new System.Drawing.Size(487, 54);
            this.brnRunBackground.TabIndex = 10;
            this.brnRunBackground.Text = "Async Shit";
            this.brnRunBackground.UseVisualStyleBackColor = true;
            this.brnRunBackground.Click += new System.EventHandler(this.brnRunBackground_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(13, 372);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(120, 25);
            this.lblStatus.TabIndex = 11;
            this.lblStatus.Text = "Status: N/A";
            // 
            // DatabaseForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 409);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.brnRunBackground);
            this.Controls.Add(this.btnCreateOtherCandles);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCheckDB);
            this.Controls.Add(this.btnUpdateDB);
            this.Name = "DatabaseForm";
            this.Text = "Update Database";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnUpdateDB;
        private System.Windows.Forms.Button btnCheckDB;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCreateOtherCandles;
        private System.Windows.Forms.Button brnRunBackground;
        private System.Windows.Forms.Label lblStatus;
    }
}