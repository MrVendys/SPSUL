using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {
        //Pripraveni promenych
        Cell[,] cells = new Cell[4, 4];
        Random r = new Random();
        int cellsCount = 0;
        int score;
        public Form1()
        {
            InitializeComponent();
            GameStart();
        }
        //Start hry
        public void GameStart()
        {
            panel1.Controls.Clear();
            CreateCells();
        }
        //Aktualizování score
        public void AddScore(int val)
        {
            score += val;
            labelScore.Text = score.ToString();

        }
        //Vytvoreni hraci plochy a nahodne 2 desticek s hodnotou
        public void CreateCells()
        {
            for (int i = 0; i < 4; i++)
            {
                for (int y = 0; y < 4; y++)
                {
                    Cell c = new Cell();
                    c.setValue(0);
                    panel1.Controls.Add(c);
                    cells[i, y] = c;
                }
            }
            int a = int.Parse(labelScore.Text);
            int b = int.Parse(labelBest.Text);
            if (a > b)
            {
                labelBest.Text = labelScore.Text;
            }
            labelScore.Text = 0.ToString();
            score = 0;
            cellsCount = 0;
            AddCell();
            AddCell();
        }
        //Refrech vsech desticek a pridani jedne nove
        public void ResetCells()
        {
            panel1.Controls.Clear();
            foreach (Cell c in cells)
            {
                panel1.Controls.Add(c);
            }
            
        }
        //Funcke na pridani jedne desticky na nahodne koordinaty
        public void AddCell()
        {
            int x = r.Next(0, 4);
            int y = r.Next(0, 4);
            //Projizdim pole hracich desticek dokud nenajdu nejakou prazdnou (nebo pokud uz neni plne pole)
            while (cells[x,y].value != 0 && cellsCount != 16)
            {
                //Pokud najdu nejakou, ulozim si jeji souradnice
                x = r.Next(0, 4);
                y = r.Next(0, 4);   
            }
            //Kontrola, ze mam misto na pridani desticky
            //Pokud ano, pridam ji na hraci pole s hodnotou bud 2 nebo 4
            if(cellsCount != 16)
            {
                cellsCount++;
                int pr = r.Next(0, 100) < 90 ? 2 : 4;
                cells[x, y].setValue(pr);
                ResetCells();
            }
            //Pokud ne, Konec Hry
            //Otevreni noveho okna s napisem "Konec hry" a tlacitekm na restartovani
            else
            {
                GameOver go = new GameOver();
                go.ShowDialog();
                if(go.result == 1)
                {
                    GameStart();
                }
                else
                {
                    Close();
                }
            }

           
            
        }

        //Funkce resici pohyb desticek
        public void moveCells(string direct)
        {
            //Podle promenne "direct" urcit, jakym smerem se maji vsechny desticky pohnout
            switch (direct)
            {
                case "down":
                    //I kdyz smer je dolu, prochazim pole po ose y (int i) odspodu, aby se spravne spojovali desticky se stejnym cislem
                    //Zacinam predposledni destickou (int i = 2), protoze posledni je u zdi a nema se kam posunout
                    for (int i = 2; i >= 0; i--)
                    {
                        for (int y = 0; y < 4; y++)
                        {
                            shiftCellsVer(i, y, direct);
                        }
                    }
                    break;
                case "up":
                    for (int i = 1; i < 4; i++)
                    {
                        for (int y = 0; y < 4; y++)
                        {
                            shiftCellsVer(i, y, direct);
                        }
                    }
                    break;
                case "left":
                    for (int i = 0; i < 4; i++)
                    {
                        for (int y = 1; y < 4; y++)
                        {
                            shiftCellsHor(i, y, direct);
                        }
                    }
                    break;
                case "right":
                    for (int i = 0; i < 4; i++)
                    {
                        for (int y = 2; y >= 0; y--)
                        {
                            shiftCellsHor(i, y, direct);
                        }
                    }
                    break;
            }
            AddCell();

        }
        //Pohyb desticky [i,y] vertikalne podle "direct"
        public void shiftCellsVer(int i, int y, string direct)
        {
            Cell nextCell = null;
            //Kontrola pozice pri rekurzi
            if (direct == "down")
            {
                if (i == 3)
                    return;
                nextCell = cells[i + 1, y];
            }
            else
            {
                if (i == 0)
                    return;
                nextCell = cells[i - 1, y];
            }

            //Pokud nasledujici desticka ma stejnou hodnotu, spoji se a nahradi jeji misto
            if (cells[i, y].value == nextCell.value)
            {
                SwitchValue(cells[i, y], nextCell);
            }
            //Pokud ma dalsi desticka hodnotu 0, nahradi jeji misto
            //Nasledne rekurze, pokud i nasledujici desticky maji hodnotu 0
            else if(nextCell.value == 0)
            {
                int temp = cells[i, y].value;
                cells[i, y].setValue(nextCell.value);
                nextCell.setValue(temp);
                if(direct == "down")
                {
                    shiftCellsVer(i + 1, y, direct);
                }
                else
                {
                    shiftCellsVer(i - 1, y, direct);
                }
            }

        }
        //Pohyb desticky [i,y] horizontalne podle "direct"
        public void shiftCellsHor(int i, int y, string direct)
        {
            Cell nextCell = null;
            if (direct == "right")
            {
                if (y == 3)
                    return;
                nextCell = cells[i, y + 1];
            }
            else
            {
                if (y == 0)
                    return;
                nextCell = cells[i, y - 1];
            }

            if (cells[i, y].value == nextCell.value)
            {
                SwitchValue(cells[i,y], nextCell);
            }
            else if (nextCell.value == 0)
            {
                int temp = cells[i, y].value;
                cells[i, y].setValue(nextCell.value);
                nextCell.setValue(temp);
                if (direct == "right")
                {
                    shiftCellsHor(i, y + 1, direct);
                    
                }
                else
                {
                    shiftCellsHor(i, y - 1, direct);
                }


            }
        }
        //Funkce na prohazovani hodnoty desticek
        private void SwitchValue(Cell first, Cell next)
        {
            next.setValue(next.value * 2);
            first.setValue(0);
            AddScore(next.value);
            if (next.value != 0)
                cellsCount--;
        }
        //Volani funkce po kliknuti na klavesnici
        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            //Kontrola, jestli hrac stlacil klavesu na pohyb a pripadne volani funkci "moveCells()"
            switch(e.KeyCode)
            {
                case Keys.W: 
                    moveCells("up");
                    ResetCells();
                    break;
                case Keys.S:
                    moveCells("down");
                    ResetCells();
                    break;
                case Keys.D:
                    moveCells("right");
                    ResetCells();
                    break;
                case Keys.A:
                    moveCells("left");
                    ResetCells();
                    break;
            }

        }
        //Kliknuti na tlacitko Reset
        private void resetBtn_Click(object sender, EventArgs e)
        {
            CreateCells();

        }
    }
}
