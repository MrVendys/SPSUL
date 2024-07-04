using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tekken
{
    public class Fighter : ICloneable
    {
        public event Action HpChanged;
        
        private string name;
        public string Name => name;
        private string imgPath;
        public string ImgPath
        {
            get { return imgPath; }
        }

        private int damage;
        public int Damage => damage;
        private int chanceToDoubleAttack;
        public int ChanceToDoubleAttack => chanceToDoubleAttack;
        private int health;
        public int Health => health;
        private int critChance;
        public int CritChance => critChance;
        private int dodgeChance;
        public int DodgeChance => dodgeChance;

        public string OtherData
        {
            get { return string.Format("({0}/{1}/{2})",chanceToDoubleAttack,critChance,dodgeChance); }
        }

        public Fighter(string name, string imgPath, int damage, int health, int chanceToDoubleAttack, int critChance, int dodgeChance)
        {
            this.name = name;
            this.imgPath = imgPath;
            this.damage = damage;
            this.health = health;
            this.chanceToDoubleAttack = chanceToDoubleAttack;
            this.critChance = critChance;
            this.dodgeChance = dodgeChance;
        }

        public void DealDamage(int dmg)
        {
            health -= dmg;
            if (health < 0)
                health = 0;
            if (HpChanged != null)
                HpChanged();
        }

        public object Clone()
        {
            return new Fighter(name, imgPath, damage, health, chanceToDoubleAttack, critChance, dodgeChance);
        }
    }
}
