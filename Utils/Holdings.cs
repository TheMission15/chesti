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
                print("    MENU    \n K for Wallet \n I for inventory \n B for back");
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
                        print($"{item.Name}, {item.Rarity}");
                    }
                    sleep(100);
                    readKey();
                }
                if (holdingsInput.Key == ConsoleKey.B)
                {
                    break;
                }
            }
        }
    }
}
