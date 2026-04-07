using chesti.Model;
using static chesti.Utils.Python;

namespace chesti.Menus
{
    public static class Holdings
    {
        static ConsoleKeyInfo holdingsInput;
        public static void HoldingsMenu(Player player)
        {
            while (true)
            {
                clear(); page("Holdings"); print(" K for wallet \n I for inventory");
                holdingsInput = readKey();

                if (holdingsInput.Key == ConsoleKey.K)
                {
                    popUp($"You have \n\n Keys:{player.KeyCount} \n Gold:{player.GoldCount} \n Scrolls:{player.ScrollCount}");
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
