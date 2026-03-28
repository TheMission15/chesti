using static chesti.Utils.Python;
using chesti.Model;

namespace chesti.Utils
{
    public static class Upgrades
    {
        public static ConsoleKeyInfo upgradeInput;
        public static void UpgradeMenu(Player player)
        {

            while (true)
            {
                clear();
                print("     Upgrade Menu     \n\n Esc for back \n C for Chest \n S for Skills");
                upgradeInput = readKey();
                if (upgradeInput.Key == ConsoleKey.Escape)
                {
                    break;
                }
                if (upgradeInput.Key == ConsoleKey.C)
                {
                    OpenChest(player);
                }
                if (upgradeInput.Key == ConsoleKey.S)
                {
                    GiveSkill(player);
                }
            }
        }

        public static void OpenChest(Player player)
        {
            Rarity chosen = Rarity.Standard;
            int count = 0;
            bool counting = false;

            if (player.KeyCount == 0)
            {
                popUp("You dont have any keys");
            }
            else if (player.KeyCount < 0)
            {
                player.KeyCount = 0;
            }
            else
            {
                int roll = randInt(1, 10);
                if (roll >= 10)
                {
                    chosen = Rarity.New;
                }

                for (int i = 0; i <= 1; i++)
                {
                    foreach (Item item in Catalogue.Items)
                    {
                        if (item.Rarity == chosen)
                        {
                            if (counting)
                            {
                                if (roll == 0)
                                {
                                    player.Inventory.Add(item.Copy());
                                    player.KeyCount--;
                                    clear();
                                    print("You got a");
                                    sleep(450);
                                    popUp($"{item.Name}, {item.Durability}, {item.Rarity}", true);
                                    break;
                                }
                                roll--;
                            }
                            else
                            {
                                count++;
                            }
                        }
                    }
                    roll = randInt(1, count);
                    counting = true;
                }
            }
        } // end of OpenChest

        public static void GiveSkill(Player player)
        {
            clear();
            int SkillCount = Catalogue.Skills.Count();
            int roll = randInt(0, SkillCount - 1);
            Skill skill = Catalogue.Skills[roll];
            print($"Skill aquired {skill.Name}");
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
            print("D to drop");
            while (true)
            {
                ConsoleKeyInfo key = readKey();
                if (key.Key == ConsoleKey.D1 || key.Key == ConsoleKey.D2 || key.Key == ConsoleKey.D3)
                {
                    int dif = key.Key - ConsoleKey.D0;
                    player.Skills[dif - 1] = skill;
                    break;
                }
                else if (key.Key == ConsoleKey.D)
                {
                    break;
                }
            }
        } // end of GiveSkill
    }
}
