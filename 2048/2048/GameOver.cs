using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class GameOver : Form
    {
        public int result;
        public GameOver()
        {
            InitializeComponent();
        }

        private void playAgainBtn_Click(object sender, EventArgs e)
        {
            result = 1;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            result = 0;
            Close();
        }
    }
}
