using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace M_DevinerVersionWindows
{
    public partial class PromptForm : Form
    {
        public string Nom;
        public PromptForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nom = TextBox1.Text;
            Close();
        }
    }
}
