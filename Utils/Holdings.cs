using chesti.Model;
using static chesti.Utils.Python;

namespace chesti.Utils
{
    public static class Holdings
    {
        static ConsoleKeyInfo holdingsInput;
        public static void HoldingsMenu(Player player)
        {
            while (true)
            {
                clear();
                print("    MENU    \n Esc for back \n K for Wallet \n I for inventory");
                holdingsInput = readKey();


                if (holdingsInput.Key == ConsoleKey.K)
                {
                    clear();
                    print($"You have \n\n Keys:{player.KeyCount} \n Gold:{player.GoldCount}");
                    sleep(100);
                    readKey();
                }
                if (holdingsInput.Key == ConsoleKey.I)
                {
                    clear();
                    print("Inventory:");
                    foreach (Item item in player.Inventory)
                    {
                        print($"{item.Name}, {item.Durability}, {item.Rarity}");
                    }
                    sleep(100);
                    readKey();
                }
                if (holdingsInput.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
