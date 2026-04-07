using chesti.Model;
using static chesti.Utils.Python;
using static chesti.Utils.Methods;
using static chesti.Utils.Battle;
using static chesti.Utils.DataManager;

namespace chesti.Menus
{
    public static class Training
    {
        public static ConsoleKeyInfo trainingInput;
        public static bool itemLock;
        public static bool skillLock;
        public static Player player2 = PlayerSaves("npc");
        public static void TrainingMenu(Player player)
        {
            if (player.Selected != null && player.Selected.Durability <= 0)
            {
                player.DeleteItem();
            }
            while (true)
            {
                clear(); page("Training");
                if (player.Selected == null || player.SelectedIndex == null)
                {


                    print(" Esc for back \n S for selecting item");
                }
                else
                {
                    print(" Esc for back \n S for selecting item \n B for random ");
                }
                trainingInput = readKey();

                if (trainingInput.Key == ConsoleKey.Escape)
                {
                    break;
                }
                if (trainingInput.Key == ConsoleKey.S)
                {
                    if (player.Inventory.Count == 0)
                    {
                        popUp("You have no items");
                    }
                    else
                    {
                        SelectItem(player);
                    }
                }
                if (trainingInput.Key == ConsoleKey.B && player.Selected != null)
                {
                    skillLock = false;
                    if (player.Skills.All(x => x == null)) { skillLock = true; }

                    if (skillLock)
                    {
                        popUp("You need at least one skill and some durability on ur tool");
                    }
                    else
                    {
                        player2 = NPC(player2);
                        Fight(player, player2);
                    }
                }
            }
        }
    }
}
