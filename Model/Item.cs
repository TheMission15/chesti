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
            Weight = weight;
            Group = group;
            Rarity = rarity;
            Element = element;
        }
        public Item Copy(int r = 32)
        {
            return new Item(Name, Durability+randInt(-r,r), Weight, Group, Rarity, Element);
        }
        public override string ToString()
        {
            return $"{Name} {Weight}KG, {Durability} Drt";
        }
    }
}