using static Chesti.Core.Methods;
namespace Chesti.Core.Model
{
    public class Fighter
    {
        public double Durability {  get; set; }
        public int RoundsWon { get; set; }
        public bool RoundWinner { get; set; }
        public bool IsNPC { get; set; }
        //public RewardLevel Tier {  get; set; }
        public int Wait {  get; set; }
        public int Damage { get; set; }
        public bool Select { get; set; }
        public Item Tool { get; set; }
        public Skill? SkillUsed {  get; set; }

        public Fighter(double durability, Item tool, bool isNPC)
        {
            Durability = (tool.Durability < durability) ? tool.Durability : durability;
            RoundsWon = 0;
            RoundWinner = false;
            Wait = 0;
            Damage = 0;
            Select = true;
            Tool = tool;
            IsNPC = isNPC;
        }
        public void Win() { RoundWinner = true; RoundsWon++; } // end of Win()

        public void Reset(double durability, Item tool)
        {
            Tool = tool;
            Durability = (Tool.Durability < durability) ? Tool.Durability : durability;
            RoundWinner = false;
            Select = true;
            SkillUsed = null;
        } // basically just a second Fighter()
        public void CalculateDamage()
        {

            if (SkillUsed != null)
            {
                int random = randInt(1, 1000);
                if (random <= SkillUsed.Stats.CritChance)
                {
                    Damage = Convert.ToInt32(Tool.Weight * SkillUsed.Damage);
                    return;
                }
                else
                {
                    random = randInt(SkillUsed.Stats.Max - SkillUsed.Stats.Range, SkillUsed.Stats.Max);
                }


                Damage = (int)(Tool.Weight * SkillUsed.Damage * (random / 100.0));
            }
        } // end of CalculateDamage()
        public void CalculateTurn(int turn)
        {
            if (SkillUsed != null)
            {
                Wait = Tool.Weight + (SkillUsed.Damage / SkillUsed.Speed);
                if (Wait < 0)
                {
                    Wait = 0;
                }
            }
            Wait = turn + Wait;
        } // end of CalculateTurn()
        public bool PassTurn(int turn, Player player, Player opponent, Fighter defender, ConsoleKey k, bool valid)
        {
            bool result = false;
            if (valid) { return true; }
            if (Select)
            {
                result = IsNPC == false ? SelectSkill(player, k) : SelectSkill(player);
                if (SkillUsed != null) { CalculateTurn(turn); CalculateDamage(); }
                Select = !result;
                return result;
            }
            if (turn == Wait)
            {
                opponent.dealDamage(Damage);
                defender.Durability -= Damage;
                SkillUsed = null;
                return Select = true;
            }
            else { return true; }
        } // end of PassTurn()
        public bool SelectSkill(Player player, ConsoleKey key)
        {
            if (key >= ConsoleKey.D1 && key <= ConsoleKey.D3)
            {
                int index = (key - ConsoleKey.D0) - 1;
                SkillUsed = player.Skills[index];

                if (SkillUsed != null)
                {
                    return true;
                }
            }
            return false;
        } // end of SelectSkill(key)
        public bool SelectSkill(Player player)
        {
            int index = randInt(0, 2);
            SkillUsed = player.Skills[index];

            if (SkillUsed != null)
            {
                return true;
            }
            return false;
        } // end of SelectSkill()
    }
}
