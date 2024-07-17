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
    public partial class Targets : Form, IMinigame
    {
        int countdownValue = 3;
        int value = 100;
        int points = 0;

        Rectangle currentTarget = new Rectangle();

        private int CountdownValue
        {
            set
            {
                countdownValue = value;
                label1.Text = countdownValue.ToString();
            }
        }

        public Targets()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
        }

        public event Action<int> GameEnded;

        public void StartGame()
        {
            countdown.Start();
        }
        //Generovani terce na nahodne pozici
        private void GenerateRectangle()
        {
            Random r = new Random();
            currentTarget = new Rectangle(
                r.Next(0, panel1.Width - 100),
                r.Next(0, panel1.Height - 100),
                100,
                100
                );
        }

        private void countdown_Tick(object sender, EventArgs e)
        {
            CountdownValue = countdownValue - 1;
            if(countdownValue == 0) 
            {
                countdown.Stop();
                panel1.Controls.Remove(label1);
                gameTimer.Start();
                GenerateRectangle();
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            value--;
            if (value > 0)
            {
                progressBar1.Value = value;
                currentTarget.Width = value;
                currentTarget.Height = value;
            } else
            {
                EndGame();
            }
            panel1.Refresh();
        }

        private void EndGame()
        {
            gameTimer.Stop();
            if (GameEnded != null)
                GameEnded(points);
            this.Close();
        }
        //Kontrola, ze hrac kliknul na terc
        private void panel1_MouseClick(object sender, MouseEventArgs e)
        {
            Point a1 = e.Location;
            Point a2 = currentTarget.Location;

            double dist = a1.Distance(a2);
            if(dist > value / 2)
            {
                EndGame();
            } else
            { 
                points++;
                if (points < 8)
                {
                    value = 100 - (points * 7);
                    GenerateRectangle();
                } else
                {
                    EndGame();
                }
            }
        }
        //Vykreslovani terce
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Rectangle drawRect = currentTarget;
            drawRect.X -= currentTarget.Width / 2;
            drawRect.Y -= currentTarget.Height / 2;

            e.Graphics.FillEllipse(Brushes.DarkGreen, drawRect);
        }

        private void Targets_FormClosing(object sender, FormClosingEventArgs e)
        {
            gameTimer.Stop();
            countdown.Stop();
        }
    }
}
