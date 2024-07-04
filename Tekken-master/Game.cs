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
    public partial class Game : Form
    {
        TekkenConsole console;

        Fighter fighter = null;
        Fighter opponent = null;

        Fighter fighterModel;
        Fighter opponentModel;

        Random r = new Random();

        List<Type> minigames = new List<Type>()
        {
            typeof(Targets),
            typeof(Letters),
            typeof(WaveMatch),
            typeof(MathCalc),
            typeof(Circle),
            typeof(Pong)
    
        };

        public Game(Fighter fighter,Fighter opponent)
        {
            this.fighterModel = fighter;
            this.opponentModel = opponent;

            this.fighter = (Fighter)fighterModel.Clone();
            this.opponent = (Fighter)opponentModel.Clone();

            this.fighter.HpChanged += OnHpChanged;
            this.opponent.HpChanged += OnHpChanged;

            InitializeComponent();
            console = new TekkenConsole(flowLayoutPanel1);
        }

        private void OnHpChanged()
        {
            this.fighterpgbr.Value = this.fighter.Health;
            this.opponentpgbr.Value = this.opponent.Health;

            this.label1.Text = this.fighter.Health.ToString();
            this.label2.Text = this.opponent.Health.ToString();

            CheckVictory();
        }

        private void CheckVictory()
        {
            Fighter winner = null;
            if (fighter.Health == 0)
                winner = opponent;
            if (opponent.Health == 0)
                winner = fighter;

            if(winner != null)
            {
                WinnerForm wf = new WinnerForm(winner);
                wf.ShowDialog();
                if(wf.result == 1 || wf.result == 0)
                {
                    fighter = (Fighter)fighterModel.Clone();
                    opponent = (Fighter)opponentModel.Clone();

                    this.fighter.HpChanged += OnHpChanged;
                    this.opponent.HpChanged += OnHpChanged;

                    OnHpChanged();
                    console.Clear();
                } else
                {
                    Close();
                }
            }
        }

        private void Game_Load(object sender, EventArgs e)
        {
            this.fighterpctbx.BackgroundImage = Image.FromFile(fighter.ImgPath);
            this.opponentpctbx.BackgroundImage = Image.FromFile(opponent.ImgPath);
            this.fighterpgbr.Maximum = this.fighter.Health;
            this.opponentpgbr.Maximum = this.opponent.Health;

            OnHpChanged();
        }

        private void fightbtn_Click(object sender, EventArgs e)
        {
            Fighter attacker = r.Next(10) <= 5 ? fighter : opponent;
            Fighter defender = attacker == fighter ? opponent : fighter;
            Fight(attacker,defender);
        }

        private void Fight(Fighter attacker,Fighter defender)
        {
            if (attacker == fighter)
                StartMiniGame(attacker, defender);
            else
                DealRandomDamage(attacker,defender);
        }

        private void DealRandomDamage(Fighter attacker, Fighter defender)
        {
            //Bot calc random damage multiplier
            DealDamage(attacker, defender, r.Next(0, 4));
        }
        //Add some dodge and crit stat into hit chance and then deal damage
        private void DealDamage(Fighter attacker, Fighter defender,int points)
        {
            int dodge = r.Next(101);

            if (dodge < defender.DodgeChance)
            {
                console.AddLine(defender.Name + " dodged! That little rat!");
            } else
            {
                double dmg = attacker.Damage;
                bool crit = r.Next(101) < attacker.CritChance;
                if (crit)
                    dmg *= 1.5;

                dmg *= points;

                console.AddLine(attacker.Name + " inflicted " + defender.Name + " " + ((int)dmg) + " damage" +
                    (crit ? " with critical strike!" : "."));


                defender.DealDamage((int)dmg);
            }
        }

        private void StartMiniGame(Fighter attacker, Fighter defender)
        {

            IMinigame mg = (IMinigame)Activator.CreateInstance(
               minigames[r.Next(minigames.Count)]
                ) ;
            Form f = mg as Form;
            if(f != null) 
            {
                mg.GameEnded += (points) =>
                {
                    DealDamage(attacker,defender,points);
                };
                mg.StartGame();
                f.ShowDialog();
            }
        }
    }
}
