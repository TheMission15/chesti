using Chesti.Core.Model;
using static Chesti.Console.Methods;
using static Chesti.Console.Python;
using static Chesti.Core.DataManager;

namespace Chesti.Console
{
    public static class Menus
    {
        public static ConsoleKeyInfo menuInput;
        public static void Menu()
        {
            Player player = JoinGame(); //PlayerSaves("mission");//
            while (true)
            {
                clear(); page("Chesti.Console", $"Hello {player.Name}"); print(" S for shop \n F for inventory \n T for training ");

                menuInput = readKey();

                //game loop
                if (menuInput.Key == ConsoleKey.Escape) // leave
                {
                    break;
                }

                if (menuInput.Key == ConsoleKey.S)  // shop
                {
                    ShopMenu(player);
                }

                if (menuInput.Key == ConsoleKey.F) // holdings
                {
                    InventoryMenu(player);
                }

                if (menuInput.Key == ConsoleKey.T) // training
                {
                    TrainingMenu(player);
                }
                if (menuInput.Key == ConsoleKey.C)
                {
                    Test(player);
                }
            }
            clear();
            SavePlayer(player);
            print("Cya");
        }
        public static void InventoryMenu(Player player)
        {
            var book = Write(player);
            while (true)
            {
                clear(); page("Holdings"); print(" K for Back Pocket \n I for Items");
                menuInput = readKey();

                if (menuInput.Key == ConsoleKey.K) { Wallet(player); }
                if (menuInput.Key == ConsoleKey.I) { ViewItems(book, player); }
                if (menuInput.Key == ConsoleKey.Escape) { break; }
            }
        }
        public static void ShopMenu(Player player)
        {
            while (true)
            {
                clear(); page("Shop", $"Keys: {player.Wallet.KeyCount}, Scrolls: {player.Wallet.ScrollCount}");
                print(" C for Chest \n S for Skills \n K for keys \n J for scrolls");
                menuInput = readKey();

                if (menuInput.Key == ConsoleKey.Escape) { break; }
                if (menuInput.Key == ConsoleKey.C) { OpenChest(player); }
                if (menuInput.Key == ConsoleKey.S) { GiveSkill(player); }
                if (menuInput.Key == ConsoleKey.K) { KeyMenu(player); }
                if (menuInput.Key == ConsoleKey.J) { ScrollMenu(player); }
            }
        }
        public static void TrainingMenu(Player player)
        {
            if (player.Selected != null && player.Selected.Durability <= 0){ player.DeleteItem(); }
            var book = Write(player);
            while (true)
            {
                var unlock = BattleLock(player);
                clear(); page("Training"); print(unlock.Message);
                menuInput = readKey();

                if (menuInput.Key == ConsoleKey.Escape){ break; }
                if (menuInput.Key == ConsoleKey.S){ ViewItems(book, player, true); }
                if (menuInput.Key == ConsoleKey.B && player.Selected != null){ VerifyBattle(player, unlock.Result); }
            }
        }
        public static void KeyMenu(Player player)
        {
            var keys = ShopType.Keys;
            while (true)
            {
                clear(); page("Scroll Shop", $"Gold:{player.Wallet.GoldCount}");
                print($" Esc for back \n 1. 10 coins = 3 keys \n 2. 20 coins = 8 keys \n 3. 50 coins = 26 keys");
                menuInput = readKey();

                if (menuInput.Key == ConsoleKey.Escape) { break; }
                if (menuInput.Key == ConsoleKey.D1) { BuyItem(player, 10, 3, keys); }
                if (menuInput.Key == ConsoleKey.D2) { BuyItem(player, 20, 8, keys); }
                if (menuInput.Key == ConsoleKey.D3) { BuyItem(player, 50, 26, keys); }
            }
        } // end of KeyMenu
        public static void ScrollMenu(Player player)
        {
            var scrolls = ShopType.Scrolls;
            while (true)
            {
                clear(); page("Scroll Shop", $"Gold:{player.Wallet.GoldCount}");
                print($" Esc for back \n 1. 30 coins = 1 Scroll \n 2. 100 coins = 5 Scrolls");
                menuInput = readKey();

                if (menuInput.Key == ConsoleKey.Escape) { break; }
                if (menuInput.Key == ConsoleKey.D1) { BuyItem(player, 30, 1, scrolls); }
                if (menuInput.Key == ConsoleKey.D2) { BuyItem(player, 100, 5, scrolls); }
            }
        } // end of KeyMenu
    }
}
