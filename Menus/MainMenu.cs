using chesti.Model;
using static chesti.Utils.Python;
using static chesti.Menus.Shop;
using static chesti.Menus.Holdings;
using static chesti.Menus.Training;
using static chesti.Utils.DataManager;

namespace chesti.Menus
{
    public static class MainMenu
    {
        public static ConsoleKeyInfo menuInput;
        public static int adminLock = 0;
        public static string? username;
        public static void Menu()
        {
            while (username == null)
            {
                clear();
                username = input("Username: ");
            }
            Player player = PlayerSaves(username);
            while (true)
            {
                clear(); page("Chesti"); print(" S for shop \n F for inventory \n T for training ");

                menuInput = readKey();

                //adim
                if (menuInput.Key == ConsoleKey.D0 || adminLock > 0)
                {
                    adminLock++;
                    if (menuInput.Key == ConsoleKey.D8 || adminLock > 1)
                    {
                        adminLock++;
                        if (menuInput.Key == ConsoleKey.D1 || adminLock > 2)
                        {
                            adminLock++;
                            if (menuInput.Key == ConsoleKey.D7)
                            {
                                clear();
                                print("Welcome to admin panel");
                                print($"Selected Item {player.Selected}");
                                readKey();
                            }
                        }
                    }
                }
                else
                {
                    adminLock = 0;
                }

                //game loop

                if (menuInput.Key == ConsoleKey.S)  // shop
                {
                    ShopMenu(player);
                }

                if (menuInput.Key == ConsoleKey.F) // holdings
                {
                    HoldingsMenu(player);
                }

                if (menuInput.Key == ConsoleKey.T) // training
                {
                    TrainingMenu(player);
                }

                if (menuInput.Key == ConsoleKey.Escape) // leave
                {
                    break;
                }
            }
            clear();
            SavePlayer(player);
            print("Cya");
        }
    }
}
