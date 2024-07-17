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
    public partial class Pong : Form, IMinigame
    {
        int points;
        int countDownValue = 3;
        int speed_left = 5;
        int speed_top = 5;
        public Pong()
        {
            InitializeComponent();
        }
        public event Action<int> GameEnded;

        public void StartGame()
        {
            Cursor.Hide();
            countDownTimer.Start(); 
        }
        private void EndGame()
        {
            Cursor.Show();
            gameTimer.Stop();
            if (GameEnded != null)
                GameEnded(points);
            this.Close();
        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            racket.Left = Cursor.Position.X - (racket.Width / 2) - 125;
            ball.Left += speed_left;
            ball.Top += speed_top;
            check();

        }
        //Kontrola, jestli micek tefil hracovu palku a vypocet odrazu
        private void check()
        {
            if (ball.Bottom >= racket.Top && ball.Bottom <= racket.Bottom && ball.Left >= racket.Left && ball.Right <= racket.Right)
            {
                speed_top += 1;
                speed_left += 1;
                speed_top = -speed_top;
         
            }
            if (ball.Right <= panel1.Right)
                speed_left = -speed_left;

            if (ball.Left >= panel1.Left)
                speed_left = -speed_left;

            if (ball.Top <= panel1.Top)
                speed_top = -speed_top;

            if (ball.Bottom >= panel1.Bottom)
            {
                EndGame();
                Cursor.Show();
            }
        }

        private void countDownTimer_Tick(object sender, EventArgs e)
        {
            countDownValue--;
            countDownLbl.Text = countDownValue.ToString();
            if(countDownValue == 0)
            {
                countDownLbl.Visible = false;
                ball.Visible = true;
                racket.Visible = true;
                label1.Visible = true;
                label2.Visible = true;
                gameTimer.Start();
                pointTimer.Start();
            }
        }
        private void Pong_FormClosing(object sender, FormClosingEventArgs e)
        {
            gameTimer.Stop();
            countDownTimer.Stop();
            pointTimer.Stop();
        }

        private void pointTimer_Tick(object sender, EventArgs e)
        {
            points++;
            label2.Text = points.ToString();
            if (points >= 8)
            {
                EndGame();
            }

        }
    }
}
