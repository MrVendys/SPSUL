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
        Cell[,] cells = new Cell[4, 4];
        Random r = new Random();
        int cellsCount = 0;
        int score;
        public Form1()
        {
            InitializeComponent();
            GameStart();
        }
        public void GameStart()
        {
            panel1.Controls.Clear();
            CreateCells();
        }
        public void AddScore(int val, Cell c)
        {
            score += val;
            labelScore.Text = score.ToString();

        }
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
        public void ResetCells()
        {
            panel1.Controls.Clear();
            foreach (Cell c in cells)
            {
                panel1.Controls.Add(c);
            }
        }
        public void AddCell()
        {
            int x = r.Next(0, 4);
            int y = r.Next(0, 4);
            while (cells[x,y].value != 0 && cellsCount != 16)
            {
                
                x = r.Next(0, 4);
                y = r.Next(0, 4);   
            }

            if(cellsCount != 16)
            {
                cellsCount++;
                int pr = r.Next(0, 100) < 90 ? 2 : 4;
                cells[x, y].setValue(pr);
                ResetCells();
            }
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

        private void flowLayoutPanel1_MouseClick(object sender, MouseEventArgs e)
        {
            int x = r.Next(0, 4);
            int y = r.Next(0, 4);
            if (cells[x, y].value == 0)
            {
                cells[x, y].setValue(2);
                Console.WriteLine(x + " " + y + " " + cells[x, y].value);
                ResetCells();
            }

        }
        public void moveCells(string direct)
        {
            switch (direct)
            {
                case "down":
                    for (int i = 3; i >= 0; i--)
                    {
                        for (int y = 0; y < 4; y++)
                        {
                            shiftCellsVer(i, y, direct);
                        }
                    }
                    break;
                case "up":
                    for (int i = 0; i < 4; i++)
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
                        for (int y = 0; y < 4; y++)
                        {
                            shiftCellsHor(i, y, direct);
                        }
                    }
                    break;
                case "right":
                    for (int i = 0; i < 4; i++)
                    {
                        for (int y = 3; y >= 0; y--)
                        {
                            shiftCellsHor(i, y, direct);
                        }
                    }
                    break;
            }

        }
        public void shiftCellsVer(int i, int y, string direct)
        {
            Cell nextCell = null;
            int zed;
            int a;
            if(direct == "down")
            {
                zed = 3;
                a = 0;
            }
            else
            {
                zed = 0;
                a = 3;
            }

            if (i == zed || cells[i,y].value == a)
            {
                return;
            }
            if (direct == "down")
            {
                nextCell = cells[i + 1, y];
            }
            else
            {
                nextCell = cells[i - 1, y];
            }

            if (cells[i, y].value == nextCell.value)
            {
                nextCell.setValue(nextCell.value * 2);
                cells[i, y].setValue(0);
                AddScore(nextCell.value, nextCell);
                if (nextCell.value != 0)
                    cellsCount--;

            }
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
        public void shiftCellsHor(int i, int y, string direct)
        {
            Cell nextCell = null;
            int zed;
            int a;
            if (direct == "right")
            {
                zed = 3;
                a = 0;
            }
            else
            {
                zed = 0;
                a = 3;
            }

            if (y == zed || cells[i, y].value == a)
            {
                return;
            }
            if (direct == "right")
            {
                nextCell = cells[i, y + 1];
            }
            else
            {
                nextCell = cells[i, y - 1];
            }

            if (cells[i, y].value == nextCell.value)
            {
                nextCell.setValue(nextCell.value * 2);
                cells[i, y].setValue(0);
                AddScore(nextCell.value,nextCell);
                if (nextCell.value != 0)
                    cellsCount--;
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

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            switch(e.KeyCode)
            {
                case Keys.W:
                    moveCells("up");
                    ResetCells();
                    AddCell();
                    break;
                case Keys.S:
                    moveCells("down");
                    ResetCells();
                    AddCell();
                    break;
                case Keys.D:
                    moveCells("right");
                    ResetCells();
                    AddCell();
                    break;
                case Keys.A:
                    moveCells("left");
                    ResetCells();
                    AddCell();
                    break;
            }

        }

        private void resetBtn_Click(object sender, EventArgs e)
        {
            //foreach(Cell c in cells)
            //{
            //    c.setValue(0);
            //}
            //AddCell
            //ResetCells();
            CreateCells();

        }
    }
}
