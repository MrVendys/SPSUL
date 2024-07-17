using System.Drawing;

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
            g.FillRectangle(ziva == true ? Brushes.Green : Brushes.White, i * size, j * size, size, size); 
        }
    }
}