using chesti.Model;
using static chesti.Utils.Python;

namespace chesti.Utils
{
    public static class Shop
    {
        static ConsoleKeyInfo shopInput;
        public static void BuyKeys(Player player, int price, int amount)
        {
            clear();
            if (player.GoldCount >= price)
            {
                player.GoldCount -= price;
                player.KeyCount += amount;
                Console.WriteLine($"You got {amount} keys\n\n Keys:{player.KeyCount}\n Gold:{player.GoldCount}");
                sleep(100);
                readKey();
            }
            else
            {
                Console.WriteLine("You dont have enough gold");
                sleep(100);
                readKey();
            }
        }
        public static void ShopMenu(Player player)
        {
            while (true)
            {
                clear();
                print($"    Welcome Shop    \n Gold:{player.GoldCount} \n Esc for back \n 1. 10 coins = 3 keys \n 2. 20 coins = 8 keys");
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
            }
        }
    }
}
