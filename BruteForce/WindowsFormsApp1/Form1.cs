using System;
using System.Collections.Generic;
using System.Threading;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        //Promenne
        char[] alphabet;
        Thread t1;
        char[] password;
        int counter = 0;
        int timer = 0;
        ulong totalCombinations = 0;
        int alphRange = 0;
        public Form1()
        {
            InitializeComponent();
        }
        //Funkce na "hackovani"
        public void Hackuj(int index, char[]text)
        {       
                //Postupne naplneni pole "text" pismeny tak, aby byla delka stejna jako u hesla pomoci rekurze
                for (int i = 0; i < alphabet.Length; i++)
                {

                text[index] = alphabet[i];
                counter++;
                //Aktualizovani labelu ve Form1 (Invoke protoze komunikuji 2 vlakna)
                if (counter >= 0)
                {

                    Invoke(new Action(() => { vyzkText.Text = counter.ToString(); }));
                    Invoke(new Action(() => { aktText.Text = new String(text); }));
                    Invoke(new Action(() => { progressBar1.Value += (int)((ulong)progressBar1.Maximum/ totalCombinations); }));
                    
                }
                //Podminka pokud se zkusebni text a heslo shoduji
                //Pokud ne, zavola se rekurze a prida se dalsi pismeno
                if (new String(text) == new String(password))
                {
                    Konec();
                    return;
                }
                //Jiz zminena rekurze. Dokud "text" nema stejnou delku jako heslo, tak se pridavaji pismenka
                //Jakmile dosahne stejne delky, zacnou se postupne od konce menit pismenka a porovnavat s heslem
                if (index < text.Length - 1)
                    {
                        Hackuj(index + 1,text);
                    }
                }
            
        }

        //Generovani hesla a resetovani aplikace
        private void button1_Click(object sender, EventArgs e)
        {
            //Vyresetovani okna
            if(vyzkText.Text != "")
            {
                Konec();
                progressBar1.Value = 0;
                counter = 0;
               
                vyzkText.Text = "";
                celkText.Text = "";
                aktText.Text = "";
                button2.Enabled = true;
            }
            //Naplneni promenych
            alphabet = textBox2.Text.ToCharArray();
            alphRange = int.Parse(textBox1.Text);
            password = new char[alphRange];
            Random r = new Random();

            for (int i = 0; i < alphRange; i++)
            {
                   int random = r.Next(0, alphabet.Length);
                   password[i] = alphabet[random];
            }   
            passText.Text = new string(password);
        }
        
        //Naplneni promenych, spusteni timeru a vytvoreni vlakna pro volani funkce "Hackuj()"
        private void button2_Click(object sender, EventArgs e)
        {
            char[]text = new char[alphRange];
            totalCombinations = (ulong)Math.Pow(alphabet.Length, alphRange);
            celkText.Text = totalCombinations.ToString();
            counter -= alphRange;
            timer1.Start();
            t1 = new Thread(() => { Hackuj(0,text); });
            t1.Start();
            button2.Enabled = false;

        }
        //Zastaveni aplikace
        //Bud zavrenim aplikace, uhadnuti hesla nebo restartem aplikace
        public void Konec()
        {
            Invoke(new Action(() => { progressBar1.Value = progressBar1.Maximum; }));
            timer1.Stop();
            time.Text = "0";
            timer = 0;
            if (t1 != null)
                t1.Abort();
        }

        private void Form1_FormClosed(object sender, FormClosedEventArgs e)
        {
            Konec();
        }
        //Funkce, ktera se stara o timer
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer++;
            time.Text = timer.ToString();
        }
    }
}
