using System.Runtime.CompilerServices;
using static chesti.Utils.Python;
namespace chesti.Model
{
    public class Chest
    {
        public required string Name { get; set; }
        public required Rarity Rarity { get; set; }

        public void OpenChest(Player player, Item[] equipment)
        {
            Rarity chosen = Rarity.Standard;
            int count = 0;
            bool counting = false;

            if (player.KeyCount == 0)
            {
                clear();
                print("You dont have any keys");
                sleep(100);
                readKey();
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
                    foreach (Item item in equipment)
                    {
                        if (item.Rarity == chosen)
                        {
                            if (counting)
                            {
                                if (roll == 0)
                                {
                                    player.Inventory.Add(item);
                                    player.KeyCount--;
                                    clear();
                                    print("You got a");
                                    sleep(450);
                                    print($"{item.Name}, {item.Rarity}");
                                    sleep(100);
                                    readKey();
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
        }

    }
}
