namespace Chesti.Core.Model
{
    public class Skill
    {
        public string Name { get; set; }
        public int Damage { get; set; }
        public int Speed { get; set; }
        public Group Group { get; set; }
        public Element Element { get; set; }
        public SkillStats Stats { get; set; }

        public Skill(string name, int damage, int speed)
        {
            Name = name;
            Damage = damage;
            Speed = speed;
            Group = 0;
            Element = 0;
            Stats = new SkillStats();

        }
        public override string ToString()
        {
            return $"{Name}, {Damage} power, {Speed} speed";
        }
        public Skill Copy()
        {
            return new Skill(Name, Damage, Speed);
        }
    }
}
