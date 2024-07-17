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
    public partial class Letters : Form, IMinigame
    {
        int countdownValue = 3;
        int points = 0;
        int value = 100;

        string currentLetter;

        public Letters()
        {
            InitializeComponent();
        }

        public event Action<int> GameEnded;

        public void StartGame()
        {
            countdownTimer.Start();
            GenerateLetter();
        }
        //Kontrola, jestli hrac zmacknul spravnou klavesu podle ukazatele
        private void Letters_KeyDown(object sender, KeyEventArgs e)
        {
            string letter = ((char)e.KeyValue).ToString();
            if(letter.ToUpper() == currentLetter.ToUpper())
            {
                points++;
                if(points < 8)
                {
                    value = 100 - (points*10);
                    GenerateLetter();
                } else
                {
                    EndGame();
                }
            } else
            {
                EndGame();
            }
        }

        private void EndGame()
        {
            gameTimer.Stop();
            if (GameEnded != null)
                GameEnded(points);
            this.Close();
        }
        //Vygemerpvamo nahoneho pismene
        private void GenerateLetter()
        {
            Random r = new Random();
            currentLetter = ((char)r.Next(65,91)).ToString();
            letterLbl.Text = currentLetter;
        }
        //Timer
        private void countdownTimer_Tick(object sender, EventArgs e)
        {
            countdownValue--;
            countdownLbl.Text = countdownValue.ToString();
            if (countdownValue == 0)
            {
                countdownTimer.Stop();
                gameTimer.Start();

                countdownLbl.Hide();
                letterLbl.Show();
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

        private void Letters_FormClosing(object sender, FormClosingEventArgs e)
        {
            gameTimer.Stop();
            countdownTimer.Stop();
        }
    }
}
