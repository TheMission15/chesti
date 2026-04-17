using static Chesti.Core.Methods;
namespace Chesti.Core.Model
{
    public class Item
    {
        public string Name { get; set; }
        public double Durability { get; set; }
        public int Weight { get; set; }
        public Group?[]? Group { get; set; }
        public Rarity Rarity { get; set; }
        public  Element Element { get; set; }

        public Item(string name, int weight, Rarity rarity, Group?[]? group, Element element = Element.Neutral)
        {
            Name = name;
            Rarity = rarity;
            int length = RoundLength(Rarity);
            int dura = AverageDura(Rarity);
            Durability = randInt((int)(dura * 0.75), dura + length);
            Weight = weight;
            Group = group;

            Element = element;
        }
        public Item Copy(Element element = Element.Neutral)
        {
            return new Item(Name, Weight, Rarity, Group, element);
        }
        public override string ToString()
        {
            return $"{Name} {Weight}KG, {Durability} Drt";
        }
    }
}