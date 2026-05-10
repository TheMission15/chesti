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
                    TrainingMenu(player);
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
                print(" C. Charm \n S. Select Charm \n E. Extract Charm");
                menuInput = readKey();
                if (menuInput.Key == ConsoleKey.Escape) { break; }
                if (menuInput.Key == ConsoleKey.C) { GiveCharm(player); }
                if (menuInput.Key == ConsoleKey.S) { popUp("ChooseCharm()"); }
                if (menuInput.Key == ConsoleKey.E) { popUp("Extracting ALLL Charms"); }
            }
        }
        public static void SmithingMenu(Player player)
        {
            ConsoleKeyInfo menuInput;
            while (true)
            {
                var book = Write(player);
                clear(); page("Shop", $"Scales: {player.Wallet.Scales[0]}");
                print(" C. New Tool \n S. Select Tool \n E. Exterminate Tool");
                menuInput = readKey();
                if (menuInput.Key == ConsoleKey.Escape) { break; }
                if (menuInput.Key == ConsoleKey.C) { OpenChest(player); }
                if (menuInput.Key == ConsoleKey.S) { ViewItems(book, player, true); ; }
                if (menuInput.Key == ConsoleKey.E) { popUp("Welp there goes ur tool"); }
            }
        }
        public static void TrainingMenu(Player player)
        {
            popUp("uhhh, dont wanna fix this yet so\n\nTRAINING MENU");

            ConsoleKeyInfo menuInput;
            if (player.SelectedTool != -1 && player.Tools[player.SelectedTool].Durability <= 0){ player.DeleteItem(); }
            var book = Write(player);
            while (true)
            {
                var unlock = BattleLock(player);
                clear(); page("Training"); print(unlock.Message);
                menuInput = readKey();

                if (menuInput.Key == ConsoleKey.Escape){ break; }
                if (menuInput.Key == ConsoleKey.S) { popUp("Soz not yet"); }
                if (menuInput.Key == ConsoleKey.F) { popUp("They are currently away"); }
                //    if (menuInput.Key == ConsoleKey.B && player.Selected != null){ VerifyBattle(player, unlock.Result); }
            }
        }
    }
}
