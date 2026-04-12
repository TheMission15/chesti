using static Chesti.Core.Methods;

namespace Chesti.Core.Model
{
    public class SkillStats
    {
        public int Experience { get; set; }
        public int Level { get; set; }
        public int Max { get; set; }
        public int Range { get; set; }
        public int CritChance { get; set; }
        public int Essence { get; set; }
        public SkillStats()
        {
            Max = 50;
            Range = 30;
            CritChance = 1;
            Experience = 0;
            Level = 0;
            Essence = 0;
        }
        public void Upgrade()
        {
            Experience += 15;
            if (Experience > 125 * (Level + 1))
            {
                Level++;
                if (Level <= 30)
                {
                    if (Level % 10 == 0)
                    {
                        Essence += randInt(8, 15);
                    }
                    int stat = randInt(1, 3);
                    Stat();
                }
                if (Level > 30)
                {
                    if (Level % 10 == 0)
                    {
                        Essence += randInt(3, 6);
                    }

                }
            }
        }
        public void Stat()
        {
            int stat = randInt(1, 3);
            switch (stat)
            {
                case 1:
                    Max++;
                    break;
                case 2:
                    Range--;
                    break;
                case 3:
                    CritChance += 2;
                    break;
            }
        }
    }
}
