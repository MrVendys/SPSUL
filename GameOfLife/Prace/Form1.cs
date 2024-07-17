using System;
using System.Windows.Forms;

namespace Prace
{
    public partial class Form1 : Form
    {
        //Promenne
        //pole je to, ktere se vykresluje
        //pole2 je sekundarni, ktere slouzi pri vypoctu sousedu
        Bunka[,] pole;
        Bunka[,] pole2;
        bool odpocet = false;
        public Form1()
        {
            InitializeComponent();
            GenerujBunky();
        }
        //Naplneni poli bunkami
        public void GenerujBunky()
        {
            pole = new Bunka[47, 47];
            pole2 = new Bunka[47, 47];
            for (int i = 0; i < 47; i++)
            {
                for (int j = 0; j < 47; j++)
                {
                    pole[i, j] = new Bunka(false, 10);
                    pole2[i, j] = new Bunka(false, 10);
                }
            }
        }
        //Vykreslovani bunek na panel podle vlastni funkce ve tride "Bunka.cs"
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
        //Reseni konfigurace bunek uzivatelem
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = e.X / 10;
            int y = e.Y / 10;
            pole[x, y].ziva = !pole[x, y].ziva;
            panel1.Refresh();
        }
        //Generace bunek na panel
        private void vygenerujBtn_Click(object sender, EventArgs e)
        {
            //Resetovani vsech bunek (na mrtve -> bile)
            for (int i = 0; i < 47; i++)
            {
                for (int j = 0; j < 47; j++)
                {
                    pole[i, j].ziva = false;
                }
            }
            //Podle inputu spočítání kolik bude zivych bunek
            Random r = new Random();
            double a = (double)Cislo.Value;
            double b = (a / 100) * ((pole.GetLength(1) - 1) * (pole.GetLength(0) - 1));

            //Oziveni bunek, pokud se narazi jiz na zivou, zkusi znovu
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
        //Start hry, zapnuti timeru
        private void startBtn_Click(object sender, EventArgs e)
        {
            timer1.Start();
            panel1.Refresh();
        }
        //Kazdy tick timeru (1s) se prepocita, kolik ma bunka soousedu a podle pravidel bud zustane ziva, ozivi se, nebo umre a obnovi se panel
        private void timer1_Tick(object sender, EventArgs e)
        {
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
        //Funkce na vypocitani poctu sousedu
        public int GetPocetSousedu(int x, int y)
        {
            int pocet = 0;
            //Ctverec kolem bunky
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
        //Pozastavi timer a bunky prestanou umirat, ozivovat se
        private void pauseBtn_Click(object sender, EventArgs e)
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

        //Nastavi vsechny bunky na mrtve -> Reset hry
        private void stopBtn_Click(object sender, EventArgs e)
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
    }
}
