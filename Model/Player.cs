using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chesti.Model
{
    public class Player
    {
        public string Name { get; set; }
        public int KeyCount { get; set; }
        public int GoldCount { get; set; }
        public Item? Selected { get; set; }
        public Skill?[] Skills { get; set; }
        public List<Item> Inventory { get; set; }

        public Player(string name, int keyCount, int goldCount)
        {
            Name = name;KeyCount = keyCount;GoldCount = goldCount;
            Skills = new Skill?[3];
            Inventory = new List<Item>() {};
        }
    }
}
