using chesti.Model;
using static chesti.Utils.Python;
using static chesti.Utils.Methods;

namespace chesti.Menus
{
    public static class Shop
    {
        static ConsoleKeyInfo shopInput;

        public static void ShopMenu(Player player)
        {
            while (true)
            {
                clear(); page("Shop"); print(" C for Chest \n S for Skills \n K for keys \n J for scrolls");
                shopInput = readKey();

                if (shopInput.Key == ConsoleKey.Escape)
                {
                    break;
                }
                if (shopInput.Key == ConsoleKey.C)
                {
                    OpenChest(player);
                }
                if (shopInput.Key == ConsoleKey.S)
                {
                    GiveSkill(player);
                }
                if (shopInput.Key == ConsoleKey.K)
                {
                    KeyMenu(player);
                }
                if (shopInput.Key == ConsoleKey.J)
                {
                    ScrollMenu(player);
                }
            } 
        }

        public static void ChestMenu(Player player)
        {

        } // end of ChestMenu
        public static void SkillMenu(Player player)
        {

        } // end of SkillMenu
        public static void KeyMenu(Player player)
        {
            while (true)
            {
                clear(); page("Scroll Shop", $"Gold:{player.GoldCount}");
                print($" Esc for back \n 1. 10 coins = 3 keys \n 2. 20 coins = 8 keys \n 3. 50 coins = 26 keys");
                shopInput = readKey();

                if (shopInput.Key == ConsoleKey.Escape)
                {
                    break;
                }
                if (shopInput.Key == ConsoleKey.D1) 
                {
                    BuyKeys(player, 10, 3);
                }
                if (shopInput.Key == ConsoleKey.D2)
                {
                    BuyKeys(player, 20, 8);
                }
                if (shopInput.Key == ConsoleKey.D3)
                {
                    BuyKeys(player, 50, 26);
                }
            }
        } // end of KeyMenu

        public static void ScrollMenu(Player player)
        {
            while (true)
            {
                clear(); page("Scroll Shop", $"Gold:{ player.GoldCount}");
                print($" Esc for back \n 1. 30 coins = 1 Scroll \n 2. 100 coins = 5 Scrolls");
                shopInput = readKey();

                if (shopInput.Key == ConsoleKey.Escape)
                {
                    break;
                }

                if (shopInput.Key == ConsoleKey.D1)
                {
                    BuyScrolls(player, 30, 1);
                }

                if (shopInput.Key == ConsoleKey.D2)
                {
                    BuyScrolls(player, 100, 5);
                }
            }
        } // end of KeyMenu

        public static void BuyKeys(Player player, int price, int amount)
        {
            if (player.GoldCount >= price)
            {
                player.GoldCount -= price;
                player.KeyCount += amount;
                popUp($"\n Keys:{player.KeyCount}\n Gold:{player.GoldCount}");
            }
            else
            {
                popUp("You dont have enough gold");
            }
        } // end of BuyKeys

        public static void BuyScrolls(Player player, int price, int amount)
        {
            if (player.GoldCount >= price)
            {
                player.GoldCount -= price;
                player.ScrollCount += amount;
                popUp($"\n Scrolls:{player.ScrollCount}\n Gold:{player.GoldCount}");
            }
            else
            {
                popUp("You dont have enough gold");

            }
        } // end of BuyKeys

        public static void OpenChest(Player player, int odds = 12)
        {
            Rarity chosen = Rarity.Standard;
            int count = 0;
            int roll = 0;
            bool counting = false;

            if (player.KeyCount <= 0)
            {
                popUp("You dont have any keys");
                player.KeyCount = 0;
                return;
            }

            while (true)
            {
                if (chosen == Rarity.Elite)
                {
                    break;
                }

                roll = randInt(1, odds);
                if (roll >= odds)
                {
                    chosen++;
                }
                else { break; }
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
        } // end of OpenChest

        public static void GiveSkill(Player player)
        {
            if (player.ScrollCount <= 0)
            {
                popUp("You dont have any scrolls");
                player.ScrollCount = 0;
                return;
            }

            player.ScrollCount--;
            int SkillCount = Catalogue.Skills.Count();
            int roll = randInt(0, SkillCount - 1);
            Skill skill = Catalogue.Skills[roll];
            while (true)
            {
                clear(); print($"Skill aquired {skill.Name}");
                ListSkills(player);
                print("D to drop");
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
