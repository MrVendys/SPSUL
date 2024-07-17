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
    public partial class Circle : Form, IMinigame
    {
        int countdownValue = 3;
        int points = 0;
        int o = 90;
        int uhel = 0;
        Random r = new Random();
        int pozice;
        Point point;
      
        public Circle()
        {
            InitializeComponent();
            //Nahodna pozice zeleneho pole
            pozice = r.Next(0, 361);
        }
        public event Action<int> GameEnded;

        public void StartGame()
        {
            countdownTimer.Start();
        }

        private void EndGame()
        {
            this.Close();
            countdownTimer.Stop();
            if (GameEnded != null)
            GameEnded(points);
            
        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            countdownValue--;
            label1.Text = countdownValue.ToString();
            if (countdownValue == 0)
            {
                countdownTimer.Stop();
                gameTimer.Start();

                label1.Hide();
            }
        }
        //Vykresleni kruhu se zelenou casti
        private void vykresli(Graphics g)
        {
            Pen p1 = new Pen(Color.Black, 20);
            g.DrawEllipse(p1, 100, 100, 250, 250);
            Pen p2 = new Pen(Color.Red, 18);
            g.DrawEllipse(p2, 102, 102, 246, 246);
            Pen p3 = new Pen(Color.Green, 18);
            genGreen(g, p3);

            Point point1 = new Point(225, 225);
            Point point2 = new Point((int)(225 + Math.Cos(uhel) * 125), (int)(225 + Math.Sin(uhel) * 125));
            point = point2;
            g.DrawLine(Pens.Black, point1, point2);
        }

       

        private void genGreen(Graphics g, Pen p3)
        {
            g.DrawArc(p3, 102, 102, 246, 246,pozice, o);
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            uhel++;
            panel1.Refresh();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            vykresli(e.Graphics);
 
        }

        private void Circle_MouseClick(object sender, MouseEventArgs e)
        {
         

        }
        //Kontrola jestli hrac kliknul na zelene pole
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            if (point.X <= pozice + o)
            {
                points++;
                if (points < 8)
                {
                    o -= 7;
                    pozice = r.Next(0, 361);
                    panel1.Refresh();
                }
                else
                {
                    EndGame();
                }
            }
            else
            {
                EndGame();
            }
        }

        private void Circle_FormClosing(object sender, FormClosingEventArgs e)
        {
            gameTimer.Stop();
            countdownTimer.Stop();
        }
    }
}