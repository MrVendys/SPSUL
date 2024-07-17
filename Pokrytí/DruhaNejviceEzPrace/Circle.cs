using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DruhaNejviceEzPrace
{
    //Trida na promenne a vykreslovani Kruhu
    class Circle
    {
        public Point start;
        public Point end;
        public int size;
        public void Draw(Graphics g)
        {
            g.FillEllipse(new SolidBrush(Color.Blue), (int)(this.start.X - this.size), (int)(this.start.Y - this.size), (int)(2 * this.size), (int)(2 * this.size));
        }
    }
}
