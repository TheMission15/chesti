using System;
using static chesti.Utils.Python;

namespace chesti.Model
{
    public class Fighter
    {
        public double Durability {  get; set; }
        public int RoundsWon { get; set; }
        public int Wait {  get; set; }
        public int Damage { get; set; }
        public bool Select { get; set; }
        public Item Tool { get; set; }
        public Skill? SkillUsed {  get; set; }

        public Fighter(double durability, Item tool)
        {
            Durability = (tool.Durability < durability) ? tool.Durability : durability;
            RoundsWon = 0;
            Wait = 0;
            Damage = 0;
            Select = true;
            Tool = tool;
        }
        public void calculateDamage(int odds = 7)
        {

            if (SkillUsed != null)
            {
                int random = randInt(1, odds);
                if (random != odds) { random = randInt(2, 5); }

                else
                {
                    Damage = Convert.ToInt32(Tool.Weight * SkillUsed.Damage);
                    return;
                }

                Damage = Convert.ToInt32(Tool.Weight * SkillUsed.Damage * (random / 10.0));
            }

        }
        public void calculateTurn(int turn, int r = 3)
        {
            if (SkillUsed != null)
            {
                Wait = Tool.Weight + (SkillUsed.Damage / SkillUsed.Speed);
                while (Wait < 1)
                {
                    Wait++;
                }
            }
            Wait = turn + Wait;
        }
    }
}
