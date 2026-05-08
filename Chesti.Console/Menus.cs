using Chesti.Core.Model;
using static Chesti.Console.Methods;
using static Chesti.Console.Python;
using static Chesti.Core.DataManager;
using static Chesti.Core.Model.Catalogue;

namespace Chesti.Console
{
    public static class Menus
    {
        public static void Menu()
        {
            Player player = JoinGame(); //PlayerSaves("mission");//
            LoadItems();
            ConsoleKeyInfo menuInput;
            while (true)
            {
                clear(); page("Chesti.Console", $"Hello {player.Name}, W. Wallet"); print(" T. Training \n F. Food Stand \n S. Smith \n C. Charms \n //station & cloths");

                menuInput = readKey();

                //game loop
                if (menuInput.Key == ConsoleKey.Escape) // leave
                {
                    break;
                }
                if (menuInput.Key == ConsoleKey.T) // --- Training ---
                {
                    //TrainingMenu(player);
                    popUp("uhhh, dont wanna fix this yet so\n\nTRAINING MENU");
                }
                if (menuInput.Key == ConsoleKey.F) // --- Food Stand ---
                {
                    popUp("yum yum, did u hear that this feature isnt out yet");
                }
                if (menuInput.Key == ConsoleKey.S)  // --- Smithing ---
                {
                    SmithingMenu(player);
                }
                if (menuInput.Key == ConsoleKey.C) // --- Charm Maker ---
                {
                    CharmsMenu(player);
                }
                if (menuInput.Key == ConsoleKey.W) // --- Wallet ---
                {
                    popUp(player.Wallet.ToString());
                }
            }
            clear();
            SavePlayer(player);
            popUp("Cya");
        }
        public static void CharmsMenu(Player player)
        {
            ConsoleKeyInfo menuInput;
            while (true)
            {
                clear(); page("Shop", $"Scales: {player.Wallet.Scales[0]}");
                print(" C. Charm");
                menuInput = readKey();
                if (menuInput.Key == ConsoleKey.Escape) { break; }
                if (menuInput.Key == ConsoleKey.C) { GiveCharm(player); }
            }
        }
        public static void SmithingMenu(Player player)
        {
            ConsoleKeyInfo menuInput;
            while (true)
            {
                clear(); page("Shop", $"Scales: {player.Wallet.Scales[0]}");
                print(" T. New Tool");
                menuInput = readKey();
                if (menuInput.Key == ConsoleKey.Escape) { break; }
                if (menuInput.Key == ConsoleKey.T) { OpenChest(player); }
            }
        }
        public static void TrainingMenu(Player player)
        {
            //ConsoleKeyInfo menuInput;
            //if (player.Selected != null && player.Selected.Durability <= 0){ player.DeleteItem(); }
            //var book = Write(player);
            //while (true)
            //{
            //    var unlock = BattleLock(player);
            //    clear(); page("Training"); print(unlock.Message);
            //    menuInput = readKey();

            //    if (menuInput.Key == ConsoleKey.Escape){ break; }
            //    if (menuInput.Key == ConsoleKey.S){ ViewItems(book, player, true); }
            //    if (menuInput.Key == ConsoleKey.B && player.Selected != null){ VerifyBattle(player, unlock.Result); }
            //}
        }
    }
}
