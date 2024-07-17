using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PrikazoveVykreslovani
{
    public partial class Form1 : Form
    {
        //List skupin obrazcu a list skupin obrazcu, ktery je uz nakresleny
        List<Group> groups = new List<Group>();
        List<Group> drawGroups = new List<Group>();
        Group selectedGroup = null;
        Operation operation = Operation.None;
        public Form1() {
            InitializeComponent();
        }
        //Sprava kliknuti na "Skupina -> Přidat"
        private void přidatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Otevře nové windows form okno "GroupManager"
            GroupManager gm = new GroupManager();
            gm.FormClosing += GroupManagerClosing;
            gm.ShowDialog();
        }
        //Reseni pri zavirani GroupManager okna
        private void GroupManagerClosing(object sender, FormClosingEventArgs e)
        {
            //Ulozeni jmena a obrazcu, ktere uzivatel nakreslil v GroupManager
            var name = ((GroupManager)sender).GroupName;
            var shapes = ((GroupManager)sender).Shapes;

            if (string.IsNullOrEmpty(name) || shapes.Count == 0)
            {
                return;
            }
            else
            {
                Group g = new Group() { name = name, shapes = shapes };
                groups.Add(g);
                UpdateGroups();
            }
        }
        //Vyobrazeni skupin obrazcu vpravo v hlavnim okne Form1
        public void UpdateGroups()
        {
            foreach(Group g in groups)
            {
                GroupView gv = new GroupView();
                gv.setGroup(g);
                gv.groupClicked += GroupClicked;
                flowLayoutPanel1.Controls.Add(gv);
            }
            canvas1.Refresh();
        }
        //Reseni kliknuti na skupinu za ucelem ji vykreslit
        private void GroupClicked(Group obj)
        {
            Group g = new Group(obj);
            

            drawGroups.Add(g);
            g.size = new Size(obj.size.Height, obj.size.Width);
            g.position = new Point(50,50);
            canvas1.Refresh();
            
        }

        //Vykreslovani obrazcu ve skupine
        private void canvas1_Paint(object sender, PaintEventArgs e)
        {
            drawGroups.ForEach(x => x.DrawGroup(e.Graphics));
        }
        //Reseni, zda bylo kliknuto na vykreslenou skupinu a pridani operace
        private void canvas1_MouseDown(object sender, MouseEventArgs e)
        {
            if(selectedGroup != null)
            {
                operation = selectedGroup.GetOperation(e.Location);   
            }
        }
        //Reseni konce operace
        private void canvas1_MouseUp(object sender, MouseEventArgs e)
        {
            operation = Operation.None;
        }
        private void canvas1_MouseLeave(object sender, EventArgs e)
        {
            operation = Operation.None;
        }
        //Reseni operaci na skupine obrazcu
        private void canvas1_MouseMove(object sender, MouseEventArgs e)
        {
            Group tempSelected = null;

            //Projeti vsech vykreslenych skupin, na jakou uzivatel kliknul
            foreach(Group g in drawGroups)
            {
                if (g.ContainsPoint(e.Location))
                {
                    tempSelected = g;
                    break;
                }
            }
            if(tempSelected == null)
            {
                if(selectedGroup != null)
                {
                    selectedGroup.Selected = false;
                }
            }
            else
            {
                if(selectedGroup != null)
                {
                    selectedGroup.Selected = false;
                }
                selectedGroup = tempSelected;
                tempSelected.Selected = true;
            }
            //Kontrola null hodnot
            if(selectedGroup != null && operation != Operation.None)
            {
                //Vybrani operace "Replace" nebo "Resize"
                if(operation == Operation.Replace)
                {
                    selectedGroup.GroupReplace(e.Location);
                }
                else
                {
                    Point p = selectedGroup.position;
                    Size s = new Size(e.X - p.X, e.Y - p.Y);
                    selectedGroup.GroupResize(s);
                    
                }
            }
            canvas1.Refresh();
        }

        
        //Ulozeni canvasu v hlavnim okne Form1 do pocitace v .json formatu
        private void uložitToolStripMenuItem_Click(object sender, EventArgs e)
        {


            string vystup = JsonConvert.SerializeObject(groups);
            SaveFileDialog fd = new SaveFileDialog();
            fd.AddExtension = true;
            fd.DefaultExt = ".json";
            fd.Filter = "JSON | .json";
            DialogResult dr = fd.ShowDialog();
            if(dr == DialogResult.OK)
            {
                var stream = File.Create(fd.FileName);
                byte[] arr = Encoding.ASCII.GetBytes(vystup);
                stream.Write(arr, 0, arr.Length);
                stream.Close();
            }

        }
        //Nacteni souboru formatu .json do canvasu
        private void načístToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog od = new OpenFileDialog();
            DialogResult dr = od.ShowDialog();
            if (dr == DialogResult.OK)
            {
                string text = File.ReadAllText(od.FileName);
                List<Group> nactene = JsonConvert.DeserializeObject<List<Group>>(text);
            }
        }


    }
    //Mozne operace se skupinou obrazcu
    public enum Operation
    {
        None,
        Replace,
        Resize
    };
}
