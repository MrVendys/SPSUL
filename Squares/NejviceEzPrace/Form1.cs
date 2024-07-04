using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NejviceEzPrace
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddSquare(Color.Red);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            AddSquare(Color.Green);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddSquare(Color.Blue);
        }
       
        private void AddSquare(Color color)
        {
            Square s = new Square(color);
            s.Click += SquareClick;
            panel1.Controls.Add(s);
        }
        private void SquareClick(object sender, EventArgs e)
        {
            Square s = (Square)sender;
            panel1.Controls.Remove(s);
        }
    }
}
