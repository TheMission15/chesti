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
        public Move Base {  get; set; }
        public List<Item> Inventory { get; set; }

        public Player(string name, int keys, int gold)
        {
            Name = name;
            KeyCount = keys;
            GoldCount = gold;
            Inventory = new List<Item>();
        }
    }
}
