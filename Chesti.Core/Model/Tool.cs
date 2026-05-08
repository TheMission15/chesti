using static Chesti.Core.Methods;

namespace Chesti.Core.Model
{
    public class Tool
    {
        public string Name { get; set; }
        public int Weight { get; set; }
        public Group[] Group { get; set; }
        public double Durability { get; set; }
        public Element Element { get; set; }

        public Tool(Item reference, Element element)
        {
            Name = reference.Name; Weight = reference.Weight; Group = reference.Group;
            Durability = randInt((int)(AverageDura(reference.Rarity) * 0.75), AverageDura(reference.Rarity) + RoundLength(reference.Rarity));
            Element = element;
        }
        public override string ToString()
        {
            return $"{Name} {Weight}KG, {Durability} Drt";
        }
    }
}
