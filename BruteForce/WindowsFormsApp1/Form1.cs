using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        char[] list;
        Thread t1;
        char[] pass;
        int id = 0;
        int timer = 0;
        ulong pocet = 0;
        int vel = 0;
        public Form1()
        {
            InitializeComponent();
            DoWork();
        }
        public void DoWork()
        {
            
        }
       
        public void Hackuj(int index, char[]text)
        {
                for (int i = 0; i < list.Length; i++)
                {

                text[index] = list[i];
                id++;
                if (id >= 0)
                {

                    Invoke(new Action(() => { aktualni.Text = new String(text); }));
                    Invoke(new Action(() => { vyzk.Text = id.ToString(); }));
                    Invoke(new Action(() => { progressBar1.Value += (int)((ulong)progressBar1.Maximum/pocet); }));
                    
                }

                if (new String(text) == new String(pass))
                {
                    Konec();
                    return;
                }
                if (index < text.Length - 1)
                    {
                        Hackuj(index + 1,text);
                    }
                }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(vyzk.Text != "")
            {
                Konec();
                progressBar1.Value = 0;
                id = 0;
               
                vyzk.Text = "";
                počet.Text = "";
                aktualni.Text = "";
                button2.Enabled = true;
            }
            
            list = textBox2.Text.ToCharArray();
            vel = int.Parse(textBox1.Text);
            pass = new char[vel];
            Random r = new Random();
            heslo.Text = "";

            for (int i = 0; i < vel; i++)
            {
                   int ra = r.Next(0, list.Length);
                   pass[i] = list[ra];
                   heslo.Text += list[ra];
            }   
        }
        
        private void button2_Click(object sender, EventArgs e)
        {
            char[]text = new char[vel];
            pocet = (ulong)Math.Pow(list.Length, vel);
            počet.Text = pocet.ToString();
            id -= vel;
            timer1.Start();
            t1 = new Thread(() => { Hackuj(0,text); });
            t1.Start();
            button2.Enabled = false;

        }
        public void Konec()
        {
            Invoke(new Action(() => { progressBar1.Value = progressBar1.Maximum; }));
            timer1.Stop();
            time.Text = "0";
            timer = 0;
            t1.Abort();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Konec();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            timer++;
            time.Text = timer.ToString();
        }
    }
}
