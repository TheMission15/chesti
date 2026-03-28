using chesti.Model;
using static chesti.Utils.Python;
using static chesti.Utils.Shop;
using static chesti.Utils.Holdings;
using static chesti.Utils.Upgrades;
using static chesti.Utils.Training;

namespace chesti.Utils
{
    public static class MainMenu
    {
        public static Player mission = new Player("Mission", 10, 50);
        public static ConsoleKeyInfo menuInput;
        public static int adminLock = 0;

        public static void Menu()
        {
            while (true)
            {
                clear(); print("Esc for leave \n E for upgrades \n F for menu \n S for shop \n T for training ");

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
                                sleep(100);
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
                if (menuInput.Key == ConsoleKey.E)  // open chests
                {
                    UpgradeMenu(mission);
                }

                if (menuInput.Key == ConsoleKey.S)  // shop
                {
                    ShopMenu(mission);
                }

                if (menuInput.Key == ConsoleKey.F) // holdings
                {
                    HoldingsMenu(mission);
                }

                if (menuInput.Key == ConsoleKey.T) // training
                {
                    TrainingMenu(mission);
                }

                if (menuInput.Key == ConsoleKey.Escape) // leave
                {
                    break;
                }
            }
            clear();
            print("Cya");
        }
    }
}
