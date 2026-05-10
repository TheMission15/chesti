using static Chesti.Core.Methods;

namespace Chesti.Core.Model
{
    public class Residue
    {
        public int Max { get; set; }
        public int Min { get; set; }
        public int CritChance { get; set; }
        public int Essence { get; set; }
        public int Store { get; set; }
        public Residue()
        {
            Max = 500;
            Min = 200;
            CritChance = 1;
            Essence = 0;
            Store = 0;
        }
        public void Upgrade()
        {
            for (int i = 0; i < Store; i++)
            {
                Essence++;
                if (Essence <= 300)
                {
                    Stat();
                }
                else
                {
                    // uhhh whoops
                }
            }
            Store = 0;
        }
        public void Use()
        {
            Store+= randInt(2, 5);
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
                    Min++;
                    break;
                case 3:
                    CritChance += 1;
                    break;
            }
        }
    }
}
