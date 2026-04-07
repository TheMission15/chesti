using chesti.Model;

namespace chesti.Utils
{
    public static class Python
    {
        public static void print(string? text)
        {
            Console.WriteLine(text);
        }
        public static string? input(string? text)
        {
            if (text != null)
            {
                Console.Write(text);
            }
            return Console.ReadLine();
        }
        public static void clear()
        {
            Console.Clear();
        }
        public static void sleep(int time)
        {
            Thread.Sleep(time);
        }
        public static ConsoleKeyInfo readKey()
        {
            return Console.ReadKey(true);
        }
        public static int randInt(int min, int max)
        {
            Random r = new Random();
            return r.Next(min, max + 1);
        }
        public static void popUp(string text, bool clearOff = false, int sleeper = 100)
        {
            if (clearOff == false)
            {
                clear();
            }
            print(text);
            sleep(sleeper);
            readKey();
        }
        public static void page(string text, string extra = "")
        {
            if (text == "Chesti")
            {
                print($"Esc to LEAVE          {text}          {extra}\n\n");
            }
            else
            {
                print($"Esc to go back          {text}          {extra}\n\n");
            }
        }
    }
}
