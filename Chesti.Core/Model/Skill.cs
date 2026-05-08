namespace Chesti.Core.Model
{
    public class Skill
    {
        public string Name { get; set; }
        public int Power { get; set; }
        public int Speed { get; set; }
        public Group Main { get; set; }
        public List<Group> Secondary {  get; set; } 
        public Element Element { get; set; }
        public Skill(string name, int power, int speed, Group main, List<Group> secondary, Element element)
        {
            Name = name;
            Power = power;
            Speed = speed;
            Main = main;
            Secondary = secondary;
            Element = element;
        }
    }
}
