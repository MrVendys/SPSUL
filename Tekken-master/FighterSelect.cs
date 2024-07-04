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
    public partial class FighterSelect : Form
    {
        Fighter fighter = null;
        Fighter opponent = null;
        List<Fighter> fighters = new List<Fighter>()
            {
                Fighters.Adam,
                Fighters.Alex,
                Fighters.Arny,
                Fighters.Bao,
                Fighters.Dan,
                Fighters.Formic,
                Fighters.Jara,
                Fighters.Jirka,
                Fighters.Kleinik,
                Fighters.Lavi,
                Fighters.Lukas,
                Fighters.Marek,
                Fighters.Mates,
                Fighters.Max,
                Fighters.Pavel,
                Fighters.Petr,
                Fighters.Radek,
                Fighters.Robin,
                Fighters.Stepan,
                Fighters.Vaclav,
                Fighters.Vrata,
                Fighters.Zbynek,


            };
        Point healthBatPosition;
        public FighterSelect()
        {
            InitializeComponent();
        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void FighterSelect_Load(object sender, EventArgs e)
        {
            

            foreach(Fighter f in fighters)
            {
                FighterModel pb = new FighterModel(f);
                pb.BackgroundImage = Image.FromFile(f.ImgPath);
                pb.BackgroundImageLayout = ImageLayout.Zoom;
                pb.BackColor = Color.Red;
                pb.Size = new Size(70, 70);
                pb.Click += FighterClick;
                flowLayoutPanel1.Controls.Add(pb);
            }
        }

        private void FighterClick(object sender, EventArgs e)
        {
           /* if(opponent != null)
            {
                return;
            }
            */
            button1.Enabled = true;
            FighterModel fm = (FighterModel)sender;
            pictureBox1.BackgroundImage = fm.BackgroundImage;
            Fighter f = fm.Fighter;
            this.fighter = f;
            label1.Text = f.Name; //286
            pictureBox3.Width = (int)(f.Health / 500.0 * 286);
            pictureBox5.Width = (int)(f.Damage / 101.0 * 286);
            label3.Text = f.OtherData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            
            for (; ; )
            {
                int index = r.Next(fighters.Count);
                if(fighters[index] != fighter)
                {
                    opponent = fighters[index];
                    break;
                }
            }
            button1.Enabled = false;
            pictureBox2.BackgroundImage = Image.FromFile(opponent.ImgPath);
            label2.Text = opponent.Name; //286
            healthBatPosition = pictureBox4.Location;
            healthBatPosition.X += pictureBox4.Width;
            pictureBox6.Width = (int)(opponent.Damage / 101.0 * 286);
            pictureBox4.Width = (int)(opponent.Health / 500.0 * 286);
            label4.Text = opponent.OtherData;
            timer1.Start();



        }

        private void pictureBox4_SizeChanged(object sender, EventArgs e)
        {
            pictureBox4.Location = new Point(
                healthBatPosition.X - pictureBox4.Width,
                healthBatPosition.Y
                );
            pictureBox6.Location = new Point(
                healthBatPosition.X - pictureBox6.Width,
                pictureBox6.Location.Y
                );
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Game g = new Game(fighter, opponent);
            g.Show();
            this.Hide();
            g.FormClosed += (s, evt) =>
            {
                this.Show();
                this.fighter = null;
                this.pictureBox1.Image = null;
            };
        }
    }
}
