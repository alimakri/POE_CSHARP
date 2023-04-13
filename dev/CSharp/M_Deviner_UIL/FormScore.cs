using M_Deviner_BOL;
using System;
using System.Collections;
using System.Windows.Forms;

namespace M_DevinerVersionWindows
{
    public partial class FormScore : Form
    {
        public FormScore()
        {
            InitializeComponent();
        }

        private void FormScore_Load(object sender, EventArgs e)
        {
            ArrayList al = Metier.GetMeilleursScores();
            for(int i=0; i < al.Count; i += 2)
            {
                LbxScore.Items.Add(al[i]+ "   -   " + al[i+1]);
            }
        }
    }
}
