using chesti.Model;
using static chesti.Utils.Python;

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
                print("     Training Camp     \n\n Esc for back \n B for random ");
                trainingInput = readKey();

                if (trainingInput.Key == ConsoleKey.Escape)
                {
                    break;
                }
            }
        }
    }
}
