namespace BitfinexCharter
{
    partial class StartForm
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
            this.btnDatabaseFunctions = new System.Windows.Forms.Button();
            this.btnLearningFunctions = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tlblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDatabaseFunctions
            // 
            this.btnDatabaseFunctions.Location = new System.Drawing.Point(145, 102);
            this.btnDatabaseFunctions.Name = "btnDatabaseFunctions";
            this.btnDatabaseFunctions.Size = new System.Drawing.Size(268, 64);
            this.btnDatabaseFunctions.TabIndex = 0;
            this.btnDatabaseFunctions.Text = "Database Functions...";
            this.btnDatabaseFunctions.UseVisualStyleBackColor = true;
            this.btnDatabaseFunctions.Click += new System.EventHandler(this.btnDatabaseFunctions_Click);
            // 
            // btnLearningFunctions
            // 
            this.btnLearningFunctions.Location = new System.Drawing.Point(145, 173);
            this.btnLearningFunctions.Name = "btnLearningFunctions";
            this.btnLearningFunctions.Size = new System.Drawing.Size(268, 65);
            this.btnLearningFunctions.TabIndex = 1;
            this.btnLearningFunctions.Text = "Learning Functions...";
            this.btnLearningFunctions.UseVisualStyleBackColor = true;
            this.btnLearningFunctions.Click += new System.EventHandler(this.btnLearningFunctions_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlblStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 340);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(595, 37);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tlblStatus
            // 
            this.tlblStatus.Name = "tlblStatus";
            this.tlblStatus.Size = new System.Drawing.Size(263, 32);
            this.tlblStatus.Text = "Database: Connecting...";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(595, 377);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.btnLearningFunctions);
            this.Controls.Add(this.btnDatabaseFunctions);
            this.Name = "Form1";
            this.Text = "Bitfinex Charter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDatabaseFunctions;
        private System.Windows.Forms.Button btnLearningFunctions;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel tlblStatus;
    }
}

