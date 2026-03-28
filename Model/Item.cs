using static chesti.Utils.Python;

namespace chesti.Model
{
    public class Item
    {
        public string Name { get; set; }
        public double Durability { get; set; }
        public int Weight { get; set; }
        public Group Group { get; set; }
        public Rarity Rarity { get; set; }
        public  Element Element { get; set; }

        public Item(string name, double durability, int weight, Group group, Rarity rarity, Element element)
        {
            Name = name;
            Durability = durability;
            Weight = Math.Clamp(weight, 5, 17);
            Group = group;
            Rarity = rarity;
            Element = element;
        }
        public Item Copy()
        {
            return new Item(Name, Durability+randInt(-10,10), Weight, Group, Rarity, Element);
        }
    }
}