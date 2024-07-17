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
    public partial class WaveMatch : Form, IMinigame
    {
        int countdownValue = 3;
        int points = 0;
        int value = 1000;
        Pen targetPen;
        Pen myPen;

        double currentFreq;
        double currentAmp;

        public WaveMatch()
        {
            InitializeComponent();
            targetPen = new Pen(Color.Red, 4);
            myPen = new Pen(Color.Green, 4);
        }

        public event Action<int> GameEnded;

        public void StartGame()
        {
            countdownTimer.Start();
        }
        //Generovani nahodne frekvence
        private void GenerateSinus()
        {
            Random r = new Random();
            currentFreq = r.Next(freqScroll.Minimum, freqScroll.Maximum);
            Console.WriteLine("Maximum: " + freqScroll.Maximum);
            Console.WriteLine("Target: " + currentFreq);
            currentAmp = r.Next(ampScroll.Minimum, ampScroll.Maximum);
            panel1.Refresh();
        }

        private void EndGame()
        {
            gameTimer.Stop();
            if (GameEnded != null)
                GameEnded(points);
            this.Close();
        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            countdownValue--;
            countdownLbl.Text = countdownValue.ToString();
            if (countdownValue == 0)
            {
                countdownTimer.Stop();
                gameTimer.Start();
                GenerateSinus();
                countdownLbl.Hide();
            }
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            value--;

            if(value > 0)
            {
                progressBar1.Value = value;
            } else
            {
                EndGame();
            }
        }
        //Vypocet souradnice y pro vykreslovani 
        private int GetY(double x, double amp, double freq)
        {
            return (int)(amp * Math.Sin(freq * x));
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (!gameTimer.Enabled)
                return;

            double amp = ampScroll.Value;
            double freq = freqScroll.Value;

            DrawSin(e.Graphics, currentAmp, currentFreq, targetPen);
            DrawSin(e.Graphics, amp, freq, myPen);
        }
        //Vykresleni frekvence
        private void DrawSin(Graphics g, double amp, double freq, Pen p)
        {
            int max = panel1.Width - 50;
            int add = panel1.Height / 2;
            Point p1 = new Point(0, add + GetY(0 / 10, amp*2, freq));
            for (int i = 1; i < max; i += 8)
            {
                Point p2 = new Point(i, add + GetY(i / 10.0, amp*2, ConvertToRadians(freq)));
                g.DrawLine(p, p1, p2);

                p1 = p2;
            }
        }
        //Prevadeni stupnu na radiany
        public double ConvertToRadians(double angle)
        {
            return (Math.PI / 180) * angle;
        }

        private void CheckMatch()
        {

            //Kontrola, jeslti freknvece zaokrouhlene sedi predepsane frekvenci
            if (Math.Abs(ampScroll.Value - currentAmp) < 3 && Math.Abs(freqScroll.Value - currentFreq) < 3)
            {
                points++;
                if(points < 8)
                {
                    value = 1000 - (points * 8);
                    GenerateSinus();
                } else
                {
                    EndGame();
                }
            }
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            panel1.Refresh();
            CheckMatch();
        }

        private void freqScroll_Scroll(object sender, EventArgs e)
        {
            panel1.Refresh();
            CheckMatch();
        }

        private void WaveMatch_FormClosing(object sender, FormClosingEventArgs e)
        {
            gameTimer.Stop();
            countdownTimer.Stop();
        }
    }
}
