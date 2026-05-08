namespace Chesti.Core.Model
{
    public class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public Group[] Group { get; set; }
        public Rarity Rarity { get; set; }
        public Item(string name, int weight, Rarity rarity, Group[] group, Element element = Element.Neutral)
        {
            Name = name;
            Rarity = rarity;
            Weight = weight;
            Group = group;
        }
    }
}