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
    public partial class MathCalc : Form, IMinigame
    {
        int countdownValue = 3;
        int points = 0;
        int value = 100;
        bool a = true;
        int vysl;

        public MathCalc()
        {
            InitializeComponent();
        }

        public event Action<int> GameEnded;

        public void StartGame()
        {
            countdownTimer.Start();
            GenerateNumber();
        }

        private void EndGame()
        {
            gameTimer.Stop();
            if (GameEnded != null)
                GameEnded(points);
            this.Close();
        }

        private void GenerateNumber()
        {
            Random r = new Random();
            int check = 0;
            int cislo1 = r.Next(0, 10);
            int cislo2 = r.Next(1, 10);

            if (a)
            {
                label1.Text = cislo1.ToString();
                vysl = cislo1;
                a = false;
            }
            int ch = r.Next(1, 5); 
            if (check == ch)
            {
                ch = r.Next(1, 5);
            }
            if (check == ch)
            {
                ch = r.Next(1, 5);
            }
            switch (ch)
            {
                case 1:
                    label1.Text += " + " + cislo2.ToString();
                    vysl = vysl + cislo2;
                    break;
                case 2:
                    label1.Text += " - " + cislo2.ToString();
                    vysl = vysl - cislo2;
                    break;
                case 3:
                    label1.Text += " * " + cislo2.ToString();
                    vysl = vysl * cislo2;
                    break;
                case 4:
                    label1.Text += " / " + cislo2.ToString();
                    vysl = vysl / cislo2;
                    break;

            }
            check = ch;
            fillButtons();
  
        }
        private void fillButtons()
        {
            Random r = new Random();
            int check = 0;
            int btn = r.Next(1, 4);
            if(check == btn)
            {
                btn = r.Next(1, 4);
            }
            if (check == btn)
            {
                btn = r.Next(1, 4);
            }
            if (btn == 1)
            
            {
                button1.Text = vysl.ToString();
                button2.Text = (r.Next(vysl-10, vysl+10)).ToString();
                button3.Text = (r.Next(vysl-10, vysl+10)).ToString();
            }
            if (btn == 2)
            {
                button2.Text = vysl.ToString();
                button1.Text = (r.Next(vysl-10, vysl+10)).ToString();
                button3.Text = (r.Next(vysl-10, vysl+10)).ToString();
            }
            if(btn == 3)
            {
                button3.Text = vysl.ToString();
                button1.Text = (r.Next(vysl-10, vysl+10)).ToString();
                button2.Text = (r.Next(vysl-10, vysl+10)).ToString();
            }
            check = btn;

        }

        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            countdownValue--;
            countdownLbl.Text = countdownValue.ToString();
            if (countdownValue == 0)
            {
                countdownTimer.Stop();
                gameTimer.Start();

                countdownLbl.Hide();
                label1.Visible = true;
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = true;
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

        private void MathCalc_FormClosing(object sender, FormClosingEventArgs e)
        {
            gameTimer.Stop();
            countdownTimer.Stop();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if (int.Parse(button1.Text) != vysl)
            {
                EndGame();
            }
            else
            {
                points++;
                if (points < 8)
                {
                    value = 100 - (points * 7);
                    GenerateNumber();
                }
                else
                {
                    EndGame();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (int.Parse(button2.Text) != vysl)
            {
                EndGame();
            }
            else
            {
                points++;
                if (points < 8)
                {
                    value = 100 - (points * 7);
                    GenerateNumber();
                }
                else
                {
                    EndGame();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (int.Parse(button3.Text) != vysl)
            {
                EndGame();
            }
            else
            {
                points++;
                if (points < 8)
                {
                    value = 100 - (points * 7);
                    GenerateNumber();
                }
                else
                {
                    EndGame();
                }
            }
        }
    }
}
