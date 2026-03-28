using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chesti.Model
{
    public class Skill
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Speed { get; set; }

        public Skill(string name, int damage, int speed)
        {
            Name = name;
            Damage = damage;
            Speed = speed;
        }

        public Skill Copy()
        {
            return new Skill(Name, Damage, Speed);
        }
    }
}
