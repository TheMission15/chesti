namespace Chesti.Core.Model
{
    public class Skill
    {
        public string Name { get; set; }
        public Rarity Rarity { get; set; }
        public int Power { get; set; }
        public int Speed { get; set; }
        public List<Group> Groups {  get; set; } 
        public Element Element { get; set; }
        public Skill(string name,Rarity rarity, int power, int speed, List<Group> groups, Element element)
        {
            Name = name;
            Rarity = rarity;
            Power = power;
            Speed = speed;
            Groups = groups;
            Element = element;
        }
    }
}
