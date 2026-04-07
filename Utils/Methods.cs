using chesti.Model;
using System.ComponentModel.DataAnnotations;
using static chesti.Utils.Python;

namespace chesti.Utils
{
    public static class Methods
    {
        public static void ListSkills(Player player, bool select = false)
        {
            for (int i = 0; i < player.Skills.Length; i++)
            {
                Skill? playerSkill = player.Skills[i];
                if (playerSkill != null)
                {
                    print($"{i + 1}. {playerSkill.Name}, {playerSkill.Damage} power, {playerSkill.Speed} speed");
                }
                else
                {
                    print($"{i + 1}. ");
                }
            }

        } // end of ListSkills

        public static Skill SelectSkill(Player player)
        {
            Skill? skill;
            while (true)
            {
                clear();
                ListSkills(player);
                ConsoleKeyInfo key = readKey();
                if (key.Key >= ConsoleKey.D1 && key.Key <= ConsoleKey.D3)
                {
                    int index = (key.Key - ConsoleKey.D0) - 1;
                    skill = player.Skills[index];
                    if (skill != null)
                    {
                        return skill;
                    }
                }
            }
        } // end of SelectSkill

        public static void SelectItem(Player player, int ipp = 9) 
        {
            ConsoleKeyInfo input;
            int page = 1;
            int inpage = -1;
            int startpos = 0;
            int count = player.Inventory.Count;
            int maxpage = (int)Math.Ceiling(count / Convert.ToDouble(ipp));

            while (true)
            {
                if (count % ipp == 0)
                {
                    inpage = ipp - 1;
                }
                else
                {
                    inpage = count % ipp;
                }

                inpage = page == maxpage ? inpage : ipp;
                clear();
                startpos = (page - 1) * ipp;
                print($"Page {page} of {maxpage}");

                for (int i = startpos; i < startpos + inpage; i++)
                {
                    print($"{(i + 1) - ((page - 1) * 9)}. {player.Inventory[i]}");
                }
                input = Console.ReadKey();
                if (input.Key == ConsoleKey.RightArrow)
                {
                    if (page < maxpage)
                    {
                        page++;
                    }
                    else
                    {
                        page = 1;
                    }
                }
                else if (input.Key == ConsoleKey.LeftArrow)
                {
                    if (page > 1)
                    {
                        page--;
                    }
                    else
                    {
                        page = maxpage;
                    }
                }
                else if (input.Key >= ConsoleKey.D1 && input.Key <= ConsoleKey.D9)
                {
                    int index = (page - 1) * ipp + (input.Key - ConsoleKey.D0 - 1);
                    if (index < count)
                    {
                        player.SetSelected(index);
                        popUp($"Selected Item: {player.Selected}");
                        break;
                    }
                }
            }
        } // end of SelectItem
        public static Player NPC(Player npc)
        {
            if (npc.Inventory.Count == 0)
            {
                npc.Inventory.Add(Catalogue.Items[0].Copy());
            }
            int r = randInt(1, 3);
            if (r == 1)
            {
                npc.Inventory[0] = Catalogue.Items[2].Copy();
                npc.SetSelected(0);
                npc.Skills = [Catalogue.Skills[1], Catalogue.Skills[2], Catalogue.Skills[0]];
            }
            if (r == 2)
            {
                npc.Inventory[0] = Catalogue.Items[5].Copy();
                npc.SetSelected(0);
                npc.Skills = [Catalogue.Skills[5], Catalogue.Skills[2], Catalogue.Skills[4]];
            }
            if (r == 3)
            {
                npc.Inventory[0] = Catalogue.Items[7].Copy();
                npc.SetSelected(0);
                npc.Skills = [Catalogue.Skills[5], Catalogue.Skills[3], Catalogue.Skills[6]];
            }
            return npc;
        } // end of NPC
    }
}
