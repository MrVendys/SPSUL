using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NejviceEzPrace
{
    public partial class Square : UserControl
    {
        public Square(Color color)
        {
            InitializeComponent();
            this.BackColor = color;
        }       

    }
}
