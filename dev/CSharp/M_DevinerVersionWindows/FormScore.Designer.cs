namespace M_DevinerVersionWindows
{
    partial class FormScore
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
            this.LbxScore = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // LbxScore
            // 
            this.LbxScore.FormattingEnabled = true;
            this.LbxScore.ItemHeight = 16;
            this.LbxScore.Location = new System.Drawing.Point(12, 12);
            this.LbxScore.Name = "LbxScore";
            this.LbxScore.Size = new System.Drawing.Size(425, 356);
            this.LbxScore.TabIndex = 0;
            // 
            // FormScore
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(456, 389);
            this.Controls.Add(this.LbxScore);
            this.Name = "FormScore";
            this.Text = "FormScore";
            this.Load += new System.EventHandler(this.FormScore_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox LbxScore;
    }
}