using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tekken
{
    public partial class WinnerForm : Form
    {
        public int result = 0;
        public WinnerForm(Fighter winner)
        {
            //Vezme obrazek viteze ze souboru a vlozi do pictureboxu
            InitializeComponent();
            pictureBox1.Image = Image.FromFile(winner.ImgPath);
            nameLbl.Text = winner.Name;
        }

        private void rematchBtn_Click(object sender, EventArgs e)
        {
            result = 1;
            Close();
        }

        private void fighterSelectBtn_Click(object sender, EventArgs e)
        {
            result = 2;
            Close();
        }
    }
}
