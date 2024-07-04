using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Cell : UserControl
    {
        public int value { set; get; }
        public Cell()
        {
            InitializeComponent();

        }
        public void setValue(int v)
        {
            if(v == 0)
            {
                label1.Text = "";
            }
            else
            {
                label1.Text = v.ToString();
            }
            value = v;
            setBackground();
        }
        public void setBackground()
        {
            if (value == 0 )
                label1.BackColor = Color.White;
            if (value == 2)
                label1.BackColor = Color.FromArgb(238, 228, 218);
            if (value == 4)
                label1.BackColor = Color.FromArgb(237, 224, 200);
            if (value == 8)
                label1.BackColor = Color.FromArgb(242, 177, 121);
            if (value == 16)
                label1.BackColor = Color.FromArgb(245, 149, 99);
            if (value == 32)
                label1.BackColor = Color.FromArgb(246, 124, 95);
            if (value == 64)
                label1.BackColor = Color.FromArgb(246, 94, 59);
            if (value == 128)
                label1.BackColor = Color.FromArgb(237, 207, 114);
            if (value == 256)
                label1.BackColor = Color.FromArgb(237, 204, 97);
            if (value == 512)
                label1.BackColor = Color.FromArgb(237, 200, 80);
            if (value == 1024)
                label1.BackColor = Color.FromArgb(237, 197, 63);
            if (value == 2048)
                label1.BackColor = Color.FromArgb(237, 194, 468);

        }

    }
}
