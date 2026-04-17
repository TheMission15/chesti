using Chesti.Core.Model;
using Chesti.Core.Result;
namespace Chesti.Core
{
    public static class Methods
    {
        public static string ListSkills(Player player)
        {
            string result = String.Empty;
            int i = 0;
            foreach (Skill? skill in player.Skills)
            {
                i++;
                if (skill != null)
                {
                    result += $"{i}. {skill}\n";
                }
                else
                {
                    result += $"{i}. \n";
                }
            } return result;
        } // end of ListSkills
        public static AcquireSkillResult AcquireSkill(Player player)
        {
            AcquireSkillResult result = new(false, "", Catalogue.RandomSkill(), false);
            if (player.Wallet.ScrollCount <= 0)
            {
                result.Message = "You dont have any scrolls";
                player.Wallet.ScrollCount = 0;
            }
            else
            {
                result.Result = true;
                player.Wallet.ScrollCount--;
                result.Message += $"Skill aquired {result.Skill}\n";
                result.Message += ListSkills(player);
                if (player.Skills.All(x => x != null))
                {
                    result.Droppable = true;
                    result.Message += "D to drop\n";
                }
            }
            return result;
        }
        public static Player NPC(Player npc)
        {
            if (npc.Inventory.Count == 0)
            {
                npc.Inventory.Add(Catalogue.Items[0][0].Copy());
            }
            int r = randInt(1, 3);
            if (r == 1)
            {
                npc.Inventory[0] = Catalogue.Items[0][2].Copy();
                npc.SetSelected(0);
                npc.Skills = [Catalogue.Skills[1], Catalogue.Skills[2], Catalogue.Skills[0]];
            }
            if (r == 2)
            {
                npc.Inventory[0] = Catalogue.Items[0][5].Copy();
                npc.SetSelected(0);
                npc.Skills = [Catalogue.Skills[5], Catalogue.Skills[2], Catalogue.Skills[4]];
            }
            if (r == 3)
            {
                npc.Inventory[0] = Catalogue.Items[0][7].Copy();
                npc.SetSelected(0);
                npc.Skills = [Catalogue.Skills[5], Catalogue.Skills[3], Catalogue.Skills[6]];
            }
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
    }
}
