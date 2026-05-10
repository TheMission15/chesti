namespace Chesti.Core.Model
{
    public class Item
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public List<Group> Group { get; set; }
        public Rarity Rarity { get; set; }
        public Item(string name, int weight, Rarity rarity, List<Group> group)
        {
            Name = name;
            Rarity = rarity;
            Weight = weight;
            Group = group;
        }
    }
}