using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tekken
{
    public partial class FighterModel : UserControl
    {

        Fighter fighter;

        public Fighter Fighter
        {
            get { return fighter; }
        }


        public FighterModel(Fighter f)
        {
            InitializeComponent();
            fighter = f;
        }

       
    }
}
