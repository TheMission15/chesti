using chesti.Model;
using static chesti.Utils.Python;
using static chesti.Utils.Upgrades;

namespace chesti.Utils
{
    public static class Training
    {
        public static ConsoleKeyInfo trainingInput;
        public static void TrainingMenu(Player player)
        {
            while (true)
            {
                clear();
                print("     Training Camp     \n");
                if (player.Selected == null)
                {
                    print("\n\n Esc for back \n S for selecting item");
                }
                else
                {
                    print("\n\n Esc for back \n S for selecting item \n B for random ");
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
                }
                if (trainingInput.Key == ConsoleKey.B && player.Selected != null)
                {
                    if (player.Skills[0] == null)
                    {
                        popUp("You need to get a skill");
                    }
                    

                }
            }
        }
    }
}
