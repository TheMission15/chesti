using static Chesti.Core.Methods;

namespace Chesti.Core.Model
{
    public class Tool
    {
        public string Name { get; set; } = "";
        Rarity Rarity { get; set; }
        public int Weight { get; set; } 
        public List<Group> Group { get; set; } = [];
        public double Durability { get; set; }
        public Element Element { get; set; }

        public Tool() { }

        public Tool(Item reference, Rarity rarity)
        {
            Name = reference.Name; Weight = reference.Weight;
            Rarity = rarity;
            if (Rarity == Rarity.Standard) { Group.Add(0); }
            else if (Rarity == Rarity.New) { Group.Add(reference.Groups[0]); }
            else { Group.AddRange(reference.Groups); }
            Durability = randInt((int)(AverageDura(Rarity) * 0.75), AverageDura(Rarity) + RoundLength(Rarity));
            if (Rarity >= (Rarity)2) { Element = (Element)randInt(0, 6); }
        }
        public override string ToString()
        {
            return $"{Name} {Weight}KG, {Durability} Drt";
        }
    }
}
