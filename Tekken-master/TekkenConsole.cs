using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tekken
{
    public class TekkenConsole
    {
        FlowLayoutPanel panel;
        Label labelTemplate;

        public TekkenConsole(FlowLayoutPanel panel)
        {
            this.panel = panel;
            this.labelTemplate = (Label)panel.Controls[0];
            this.panel.Controls.Remove(labelTemplate);
        }

        public void AddLine(string line)
        {
            Label l = new Label();
            l.Font = labelTemplate.Font;
            l.AutoSize = labelTemplate.AutoSize;
            l.Width = labelTemplate.Width;
            l.Height = labelTemplate.Height;
            l.Text = line;
            this.panel.Controls.Add(l);

            if(this.panel.Controls.Count > 5)
            {
                this.panel.Controls.RemoveAt(0);
            }
        }

        public void Clear()
        {
            this.panel.Controls.Clear();
        }
    }
}
