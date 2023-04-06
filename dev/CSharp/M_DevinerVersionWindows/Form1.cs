using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using M_Deviner_BOL;
using Microsoft.VisualBasic;

namespace M_DevinerVersionWindows
{
    public partial class Form1 : Form
    {
        public int Proposition = 0;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            LblReponse.Text = TxtPropo.Text;
            TxtPropo.SelectAll();
            Proposition = int.Parse(TxtPropo.Text);
            var x = Metier.Proposer(Proposition);

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var form2 = new PromptForm();
            form2.ShowDialog();
            LblNom.Text = form2.Nom;
        }

        private void TxtPropo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8) e.KeyChar = (char) 0;
        }

        private void BtnOk_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void TxtPropo_KeyUp(object sender, KeyEventArgs e)
        {
            BtnOk.Enabled = TxtPropo.Text.Length > 0;

        }
    }
}
