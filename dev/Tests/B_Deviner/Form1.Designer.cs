namespace M_DevinerVersionWindows
{
    partial class Form1
    {
        /// <summary>
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur Windows Form

        /// <summary>
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.TxtPropo = new System.Windows.Forms.TextBox();
            this.LblPropo = new System.Windows.Forms.Label();
            this.BtnOk = new System.Windows.Forms.Button();
            this.LblReponse = new System.Windows.Forms.Label();
            this.LblNom = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fichierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.affichageDesScoresToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtPropo
            // 
            this.TxtPropo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TxtPropo.Location = new System.Drawing.Point(298, 101);
            this.TxtPropo.MaxLength = 2;
            this.TxtPropo.Name = "TxtPropo";
            this.TxtPropo.Size = new System.Drawing.Size(165, 30);
            this.TxtPropo.TabIndex = 0;
            this.TxtPropo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TxtPropo_KeyPress);
            this.TxtPropo.KeyUp += new System.Windows.Forms.KeyEventHandler(this.TxtPropo_KeyUp);
            // 
            // LblPropo
            // 
            this.LblPropo.AutoSize = true;
            this.LblPropo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblPropo.Location = new System.Drawing.Point(52, 104);
            this.LblPropo.Name = "LblPropo";
            this.LblPropo.Size = new System.Drawing.Size(164, 25);
            this.LblPropo.TabIndex = 1;
            this.LblPropo.Text = "Votre proposition ";
            // 
            // BtnOk
            // 
            this.BtnOk.Enabled = false;
            this.BtnOk.Location = new System.Drawing.Point(298, 156);
            this.BtnOk.Name = "BtnOk";
            this.BtnOk.Size = new System.Drawing.Size(165, 97);
            this.BtnOk.TabIndex = 1;
            this.BtnOk.Text = "&Ok";
            this.BtnOk.UseVisualStyleBackColor = true;
            this.BtnOk.Click += new System.EventHandler(this.BtnOk_Click);
            this.BtnOk.KeyUp += new System.Windows.Forms.KeyEventHandler(this.BtnOk_KeyUp);
            // 
            // LblReponse
            // 
            this.LblReponse.AutoSize = true;
            this.LblReponse.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblReponse.Location = new System.Drawing.Point(51, 183);
            this.LblReponse.Name = "LblReponse";
            this.LblReponse.Size = new System.Drawing.Size(138, 31);
            this.LblReponse.TabIndex = 3;
            this.LblReponse.Text = "En attente";
            // 
            // LblNom
            // 
            this.LblNom.AutoSize = true;
            this.LblNom.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LblNom.Location = new System.Drawing.Point(191, 20);
            this.LblNom.Name = "LblNom";
            this.LblNom.Size = new System.Drawing.Size(100, 29);
            this.LblNom.TabIndex = 4;
            this.LblNom.Text = "Bonjour";
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fichierToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(524, 28);
            this.menuStrip1.TabIndex = 5;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            this.fichierToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.affichageDesScoresToolStripMenuItem,
            this.quitterToolStripMenuItem});
            this.fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            this.fichierToolStripMenuItem.Size = new System.Drawing.Size(66, 24);
            this.fichierToolStripMenuItem.Text = "&Fichier";
            // 
            // affichageDesScoresToolStripMenuItem
            // 
            this.affichageDesScoresToolStripMenuItem.Name = "affichageDesScoresToolStripMenuItem";
            this.affichageDesScoresToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.affichageDesScoresToolStripMenuItem.Text = "&Affichage des scores";
            this.affichageDesScoresToolStripMenuItem.Click += new System.EventHandler(this.affichageDesScoresToolStripMenuItem_Click);
            // 
            // quitterToolStripMenuItem
            // 
            this.quitterToolStripMenuItem.Name = "quitterToolStripMenuItem";
            this.quitterToolStripMenuItem.Size = new System.Drawing.Size(228, 26);
            this.quitterToolStripMenuItem.Text = "&Quitter";
            this.quitterToolStripMenuItem.Click += new System.EventHandler(this.quitterToolStripMenuItem_Click);
            // 
            // Form1
            // 
            this.AcceptButton = this.BtnOk;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PeachPuff;
            this.ClientSize = new System.Drawing.Size(524, 289);
            this.Controls.Add(this.LblNom);
            this.Controls.Add(this.LblReponse);
            this.Controls.Add(this.BtnOk);
            this.Controls.Add(this.LblPropo);
            this.Controls.Add(this.TxtPropo);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Deviner un nombre";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox TxtPropo;
        private System.Windows.Forms.Label LblPropo;
        private System.Windows.Forms.Button BtnOk;
        private System.Windows.Forms.Label LblReponse;
        private System.Windows.Forms.Label LblNom;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fichierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem affichageDesScoresToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitterToolStripMenuItem;
    }
}

