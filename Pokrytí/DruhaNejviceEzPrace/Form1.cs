using System;
using System.Drawing;
using System.Windows.Forms;

namespace DruhaNejviceEzPrace
{
    public partial class Form1 : Form
    {
        bool isMouseDown;
        bool background;
        string blue;
        string red;
        Point p;
        Circle c;
        public Form1()
        {
            InitializeComponent();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            panel1.BackColor = Color.White;
            isMouseDown = true;
            background = false;
            c = new Circle();
            c.start = e.Location;
            c.end = e.Location;
            panel1.Refresh();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            p.X = panel1.Height;
            p.Y = c.start.Y;
            if (GetDistance(p) < c.size)
            {
                c.size = GetDistance(p);
            }
            p.X = c.start.X;
            p.Y = panel1.Width;
            if (GetDistance(p) < c.size)
            {
                c.size = GetDistance(p);
            }
            p.X = 0;
            p.Y = c.start.Y;
            if (GetDistance(p) < c.size)
            {
                c.size = GetDistance(p);
            }
            p.X = c.start.X;
            p.Y = 0;
            if (GetDistance(p) < c.size)
            {
                c.size = GetDistance(p);
            }
            isMouseDown = false;
            background = true;
            Refresh();
            Calculate();
        }

        

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isMouseDown)
            {
                c.end = e.Location;
                c.size = GetDistance(e.Location);
                panel1.Refresh();
            }
        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            if (c != null)
            {
                c.Draw(e.Graphics);

            }
            if (background == true)
            {
                panel1.BackColor = Color.Red;
            }
        }
        public void Calculate()
        {
            double circleS = Math.PI * (Math.Pow(c.size,2));
            blue = circleS.ToString("#.000") + " px2";

            double panelS = panel1.Width * panel1.Height - circleS;
            red = panelS.ToString("#.000") + " px2";
      
            double procCircle = (100.0 / Math.Pow(panel1.Width,2)) * (int)circleS;
            Console.WriteLine(procCircle);
            double procPanel = 100 - procCircle;
            blue += " (" + procCircle.ToString("#.000") + "%)";
            red += " (" + procPanel.ToString("#.000") + "%)";
            labelBlue.Text = blue;
            labelRed.Text = red;

           
        }
        public int GetDistance(Point p)
        {
            return (int)(Math.Sqrt(Math.Pow((c.start.X - p.X), 2) + Math.Pow((c.start.Y - p.Y), 2)));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
