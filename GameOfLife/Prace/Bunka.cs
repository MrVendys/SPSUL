using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prace
{
    class Bunka
    {
        public bool ziva = false;
        int size;
        public Bunka(bool ziva, int size)
        {
            this.ziva = ziva;
            this.size = size;  
        }
        public void Vykresli(Graphics g,int i, int j)
        {
            if (ziva == true)
            {
                g.FillRectangle(Brushes.Green, i * size, j * size, size, size); 
            }
            else
            {
                g.FillRectangle(Brushes.White, i * size, j * size, size, size);
            }
        }
    }
}