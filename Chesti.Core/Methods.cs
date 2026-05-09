using Chesti.Core.Model;
using Chesti.Core.Result;
namespace Chesti.Core
{
    public static class Methods
    {
        public static string ListCharms(Player player)
        {
            string result = String.Empty;
            int i = 0;
            foreach (int charm in player.ActiveCharms)
            {
                i++;
                if (charm != -1)
                {
                    result += $"{i}. {player.Charms[charm]}\n";
                }
                else
                {
                    result += $"{i}. \n";
                }
            } return result;
        } // end of ListSkills
        public static AcquireCharmResult AcquireCharm(Player player)
        {
            AcquireCharmResult result = new(false, "", Catalogue.RandomSkill(), false);
            
            result.Result = true;
            result.Message += $"Skill aquired {result.Charm}\n";
            result.Message += ListCharms(player);
            if (player.ActiveCharms.All(x => x != -1))
            {
                result.Droppable = true;
                result.Message += "D to not equip\n";
            }
            
            return result;
        }
        public static Player NPC(Player npc)
        {
            npc.Tools = [new(Catalogue.RandomItem(), Element.Neutral)];
            npc.SelectedTool = 0;
            npc.Charms = [new(Catalogue.RandomSkill()), new(Catalogue.RandomSkill()), new(Catalogue.RandomSkill())];
            npc.ActiveCharms = [0, 1, 2];
            return npc;
        } // end of NPC
        public static int randInt(int min, int max)
        {
            Random r = new();
            return r.Next(min, max + 1);
        }
        public static int RoundLength(Rarity r)
        {
            if (r <= Rarity.Elite)
            {
                int n = ((int)r + 1);
                return (150 * n * n + 250);
            }
            return -1;
        }
        public static int Range(Rarity r)
        {
            if (r <= Rarity.Elite)
            {
                int avg = RoundLength(0);
                int range = avg / 2;
                while (r > Rarity.Standard)
                {
                    range += 100;
                }
                return range;
            }
            return -1;
        }
        public static int AverageDura(Rarity r)
        {
            int dura = 4*RoundLength(0);
            for (int i = 1; i <= (int)r; i++)
            {
                dura = (dura * 2) + (200 * i);
            }
            return dura;
        }
        public static Group ChooseGroup(Skill skill)
        {
            int count = skill.Secondary.Count;
            int r = randInt(1, 2);
            if (r == 2 && count > 0)
            {
                r = randInt(0, count - 1);
                return skill.Secondary[r];
            }
            else
            {
                return skill.Main;
            }
        }
    }
}
