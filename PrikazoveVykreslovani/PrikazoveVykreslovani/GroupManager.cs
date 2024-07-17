using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrikazoveVykreslovani
{

    
    public partial class GroupManager : Form
    {
        //List vsech nakreslenych obrazcu, aby se s nimi nemuselo pracovat pres "Command" 
        List<Shape> shapes = new List<Shape>();
        //List nakreslenych obrazcu v podobe User Control "Command"
        List<Command> commands = new List<Command>();
        Command currentlyDraggedCommand;

        public List<Shape> Shapes => shapes;
        public string GroupName => textBox1.Text;
        public GroupManager() {
            InitializeComponent();
            UpdateCommands();
        }
        
        //Vytvoreni Windows Forms "Command Form" pro kresleni obrazce
        private void AddButton_Click(object sender, EventArgs e) {
            CommandForm cmd = new CommandForm();
            //Poslani i ostatnich obrazcu na zobrazeni, protoze uzivatel kresli "na jeden papir"
            cmd.SetOtherShapes(shapes);
            cmd.FormClosing += OnCommandClosing;
            cmd.ShowDialog();
        }
        //Funkce na zachytavani zavreni "Command Form" a ulozeni nakresleneho obrazce
        private void OnCommandClosing(object sender, FormClosingEventArgs e) {
            var shp = ((CommandForm) sender).Shape;
            if (shp != null) {
                shapes.Add(shp);
                panel1.Refresh();
            }

            UpdateCommands();
        }
        //Pridani noveho User Controll "Command" do panelu napravo tohoto okna
        private void UpdateCommands() {
            panel2.Controls.Clear();
            commands.Clear();
            for (int i = 0; i < shapes.Count; i++) {
                Shape shp = (Shape) shapes[i];
                Command c = new Command();
                c.SetShape(shp);
                c.Smazat += OnSmazat;
                c.Location = new Point(0, i * c.Height);
                c.DragStart += OnDragStart;
                c.DragEnded += OnDragEnded;
                c.MovedDragged += OnMovedDragged;
                commands.Add(c);
                panel2.Controls.Add(c);
            }
            panel2.Refresh();
        }
        //Drag & Drop jednotlivych Commandu
        private void OnMovedDragged(Command obj) {
            if(currentlyDraggedCommand != null)
                RepositionCommands();
        }

        private void RepositionCommands() {
            commands = commands.OrderBy(x => x.Location.Y).ToList();
            for(int i = 0; i < commands.Count; i++) {
                if(commands[i] != currentlyDraggedCommand)
                    commands[i].Location = new Point(0,i*commands[i].Height);
            }
            
        }

        private void OnDragEnded(Command obj) {
            shapes = commands.Select(x => x.Shape).ToList();
            panel1.Refresh();
            currentlyDraggedCommand = null;
            RepositionCommands();
        }

        private void OnDragStart(Command obj) {
            currentlyDraggedCommand = obj;
        }
        //Presunuti Commandu pravym tlacitekm musto Drag & Drop
        private void OnPosunNiz(Command c) {
            int index = shapes.IndexOf(c.Shape);
            if (index - 1 >=  0) {
                shapes.RemoveAt(index);
                index--;
                shapes.Insert(index, c.Shape);
            }
            UpdateCommands();
            panel1.Refresh();
        }

        private void OnPosunVys(Command c) {
            int index = shapes.IndexOf(c.Shape);

            if (index + 1 < shapes.Count) {
                shapes.RemoveAt(index);
                shapes.Insert(index, c.Shape);
            }
            UpdateCommands();
            panel1.Refresh();
        }
        //Smazani Commandu po kliknuti a vybrani pravym tlacitkem
        private void OnSmazat(Command c) {
            shapes.Remove(c.Shape);
            UpdateCommands();
            panel1.Refresh();
        }
        //Vykreslovani vsech obrazcu
        private void Panel1_Paint(object sender, PaintEventArgs e) {
            shapes.ForEach(shp => shp.Draw(e.Graphics));
        }
        //Zavreni tohoto okna s osetrenim chyb
        private void okButton_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            if (string.IsNullOrEmpty(name))
            {
               var res = MessageBox.Show("Chybí vám název skupiny! Chcete pokračovat? Skupina se neuloží!", " Upozornení", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if(res == DialogResult.Yes)
                {
                    if(shapes.Count == 0)
                    {
                       res = MessageBox.Show("Chybí vám obrazce! Chcete pokračovat? Skupina se neuloží!", " Upozornení", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if(res == DialogResult.Yes)
                        {
                            Close();
                        }
                    } else {
                    }   
                }
                else
                {
                    
                }

            } else {
                Close();
            }

            
        }
    }
}
