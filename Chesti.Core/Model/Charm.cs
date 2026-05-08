using static Chesti.Core.Methods;
namespace Chesti.Core.Model
{
    public class Charm
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public int Speed { get; set; }
        public Group Group { get; set; }
        public Element Element { get; set; }
        public Residue Stats { get; set; }
        public Charm(Skill reference)
        {
            Name = reference.Name; Power = reference.Power; Speed = reference.Speed; Element = reference.Element;
            Stats = new();
            Group = ChooseGroup(reference);
        }
        public override string ToString()
        {
            return $"{Name}, {Power} power, {Speed} speed";
        }
    }
}
