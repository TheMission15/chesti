using Chesti.Core.Model;
using Chesti.Core.Result;
namespace Chesti.Core
{
    public static class Methods
    {
        public static string ListCharms(Player player)
        {
            string result = "";
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
        
        public static Player NPC(Player npc)
        {
            ToolChest(npc, 1);
            npc.SelectedTool = npc.Tools.Count -1;
            for (int i = 0; i< 3; i++) { CharmChest(npc, 1); }
            int c = npc.Charms.Count;
            npc.ActiveCharms = [c - 1, c - 2, c - 3];
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
            int r = randInt(0, skill.Groups.Count - 1);
            return skill.Groups[r];
        }

        //
        //      --- Chests ---
        //

        public static StringResult CharmChest(Player player, int odds)
        {
            Catalogue.LoadSkills();
            int r;
            Rarity rarity = 0;
            if (player.Wallet.Scales <= 0)
            {
                return new(false, "Out of Scales");
            }
            while (true)
            {
                r = randInt(1, 100);

                if (r > odds || rarity >= Rarity.Elite)
                {
                    break;
                }
                else if (r <= odds)
                {
                    rarity++;
                }
            }
            int count = Catalogue.Skills[(int)rarity].Count;
            if (count > 0)
            {
                r = randInt(0, count-1);
                player.Charms.Add(new(Catalogue.Skills[(int)rarity][r]));
                DataManager.SavePlayer(player);
                Charm charm = player.Charms[^1];
                return new(true, $"{charm}");
            }
            return new(false, "error");
        }

        public static StringResult Extraction(Player player, int i, int amount)
        {
            if (player.Wallet.Fragments>=amount && i < player.Charms.Count)
            {
                player.Wallet.Fragments -= amount;
                player.Wallet.Scales += (amount*player.Charms[i].Build.Essence)/50;
                for (int k=0; k<3;  k++)
                {
                    if (player.ActiveCharms[k] == i)
                    {
                        player.ActiveCharms[k] = -1;
                    }
                }
                player.Charms.RemoveAt(i);
            }
            return new(false, "error");
        }


        public static StringResult ToolChest(Player player, int odds)
        {
            Catalogue.LoadItems();
            int count = Catalogue.Items.Count;
            int r;
            Rarity rarity = 0;
            if (player.Wallet.Scales <= 0)
            {
                return new(false, "Out of Scales");
            }
            while (true)
            { 
                r = randInt(1, 100);

                if (r > odds || rarity >= Rarity.Elite)
                {
                    break;
                }
                else if (r <= odds)
                {
                    rarity++;
                }
            }
            if (count > 0)
            {
                r = randInt(0, count);
                player.Tools.Add(new(Catalogue.Items[count], rarity));
                player.Wallet.Scales--;
                DataManager.SavePlayer(player);
                return new(true, $"New Tool! \n {player.Tools[^1]}, {rarity}");
            }
            return new(false, "Error");
        }
        public static StringResult SellTool(Player player, int i)
        {
            int fragments;
            int scales;
            player.Wallet.Fragments += fragments = (int)Math.Pow(player.Tools[i].Durability / 2, 0.5);
            player.Wallet.Scales += scales = (int)Math.Pow(player.Tools[i].Durability / 2, 0.4);
            var result = new StringResult(true, $"Sold {player.Tools[i]} for {fragments} fragments and {scales} scales");
            player.Tools.RemoveAt(i);
            return result;
        }
    }
}
