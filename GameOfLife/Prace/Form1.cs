using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Prace
{
    public partial class Form1 : Form
    {
        Bunka[,] pole;
        Bunka[,] pole2;
        bool odpocet = false;
        public Form1()
        {
            InitializeComponent();
            GenerujBunky();
        }
        public void GenerujBunky()
        {
            int pocet = 0;
            pole = new Bunka[47, 47];
            pole2 = new Bunka[47, 47];
            for (int i = 0; i < 47; i++)
            {
                for (int j = 0; j < 47; j++)
                {
                    pole[i, j] = new Bunka(false, 10);
                    pole2[i, j] = new Bunka(false, 10);
                    pocet++;
                }
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 1; i < 47 - 1; i++)
            {
                for (int j = 1; j < 47 - 1; j++)
                {
                    pole[i, j].Vykresli(e.Graphics,i,j);
                }
            }
        }
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / 10;
            int y = e.Y / 10;
            pole[x, y].ziva = !pole[x, y].ziva;
            panel1.Refresh();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 47; i++)
            {
                for (int j = 0; j < 47; j++)
                {
                    pole[i, j].ziva = false;
                }
            }
            Random r = new Random();
            double a = (double)Cislo.Value;
            Console.WriteLine(a.ToString());
            double b = (a / 100) * ((pole.GetLength(1)-1) * (pole.GetLength(0)-1));
            Console.WriteLine(b.ToString());

          for (int i = 0; i < b; i++)
            {
                int r1 = r.Next(1, 47);
                int r2 = r.Next(1, 47);

                if (pole[r1, r2].ziva == false)
                {
                    pole[r1, r2].ziva = true;
                }
                else
                {
                    i--;
                }
            }
            panel1.Refresh();
        }
        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();
            panel1.Refresh();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            pole2 = new Bunka[47,47];
            for (int i = 0; i < 47; i++)
            {
                for (int j = 0; j < 47; j++)
                {
                    pole2[i, j] = new Bunka(false, 10);
                }
            }
            for (int i = 1; i < 46; i++)
            {            
                for (int j = 1; j < 46; j++)
                {
                    int soused = GetPocetSousedu(i, j);     
                    if (pole[i, j].ziva == true)
                    {  
                        if (soused < 2)
                        {
                            pole2[i, j].ziva = false;
                        }
                        if (soused == 2 || soused == 3) 
                        {
                            pole2[i, j].ziva = true;
                        }
                        if (soused > 3)
                        {
                            pole2[i, j].ziva = false;
                        }
        
                    }
                    else
                    {
                        if (soused == 3)
                        {
                            pole2[i, j].ziva = true;
                        }
                    }
                }
            }
            pole = pole2;
            panel1.Refresh();
        }
        public int GetPocetSousedu(int x, int y)
        {
            int pocet = 0;
            for (int i = -1; i < 2; i++)
            {
                for (int j = -1; j < 2; j++)
                {
                    if (!(i == 0 && j == 0))  
                    {
                        if (pole[x + i, y + j].ziva == true)                
                        {  
                            pocet++;
                        }
                    }
                }
            }
            return pocet;
        }
        private void button3_Click(object sender, EventArgs e) 
        {
            timer1.Stop();
            for (int i = 1; i < 47 - 1; i++)
            {
                for (int j = 1; j < 47 - 1; j++)
                {
                    pole[i, j].ziva = false;
                }
            }
            panel1.Refresh();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (odpocet == false)
            {
                timer1.Enabled = false;
            }
            else
            {
                timer1.Enabled = true;
            }
            odpocet = !odpocet;
            
        }
    }
}
