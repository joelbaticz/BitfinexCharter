namespace BitfinexCharter
{
    partial class ConnectionForm
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
            this.lblConnection = new System.Windows.Forms.Label();
            this.prgConnection = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // lblConnection
            // 
            this.lblConnection.AutoSize = true;
            this.lblConnection.Location = new System.Drawing.Point(56, 48);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(258, 25);
            this.lblConnection.TabIndex = 0;
            this.lblConnection.Text = "Connecting to database...";
            // 
            // prgConnection
            // 
            this.prgConnection.Location = new System.Drawing.Point(61, 110);
            this.prgConnection.Name = "prgConnection";
            this.prgConnection.Size = new System.Drawing.Size(410, 38);
            this.prgConnection.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.prgConnection.TabIndex = 1;
            // 
            // ConnectionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 256);
            this.Controls.Add(this.prgConnection);
            this.Controls.Add(this.lblConnection);
            this.Name = "ConnectionForm";
            this.Text = "Connecting to Database";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.ProgressBar prgConnection;
    }
}