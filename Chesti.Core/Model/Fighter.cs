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
        public Tool Tool { get; set; }
        public Charm? SkillUsed {  get; set; }

        public Fighter(double durability, Tool tool, bool isNPC)
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

        public void Reset(double durability, Tool tool)
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
                int random = randInt(SkillUsed.Build.CritChance, 1000);
                double synergy = 1;
                if (!Tool.Group.Contains(Group.Freestyle))
                {
                    if (Tool.Group.Contains(SkillUsed.Group))
                    {
                        synergy += 0.18;
                    }
                    else
                    {
                        synergy -= 0.18;
                    }
                    //if (Tool.Group.Contains(Group.Speed))
                    //{
                    //    synergy += 0.08;
                    //}
                }
                else if (SkillUsed.Group == 0)
                    synergy += 0.1;
                if (random <= SkillUsed.Build.CritChance)
                {
                    Damage = (int)Math.Round(SkillUsed.Power * (Tool.Weight + SkillUsed.Speed)*1.0, MidpointRounding.AwayFromZero);
                }
                else
                {
                    random = randInt(SkillUsed.Build.Min + (SkillUsed.Build.Max / 2), SkillUsed.Build.Max);
                    Damage = (int)Math.Round(SkillUsed.Power * (Tool.Weight + SkillUsed.Speed) * 0.68 * (random / 1000.0) * synergy, MidpointRounding.AwayFromZero);
                }

            }
        } // end of CalculateDamage()
        public void CalculateTurn(int turn)
        {
            if (SkillUsed != null)
            {
                Wait = (int)Math.Round(1.5+((SkillUsed.Power + Tool.Weight) / SkillUsed.Speed * 4.5), MidpointRounding.AwayFromZero);
            }
            int r = randInt(0, 100);
            int bonus = (r<25) ? -1 : (r>80) ? 1 : 0;
            Wait = turn + Wait + bonus;
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
                SkillUsed = player.Charms[player.ActiveCharms[index]];

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
            SkillUsed = player.Charms[player.ActiveCharms[index]];

            if (SkillUsed != null)
            {
                return true;
            }
            return false;
        } // end of SelectSkill()
    }
}
