namespace Chesti.Console
{
    public static class Python
    {
        public static void print(string? text)
        {
            System.Console.WriteLine(text);
        }
        public static string? input(string? text)
        {
            if (text != null)
            {
                System.Console.Write(text);
            }
            return System.Console.ReadLine();
        }
        public static void clear()
        {
            System.Console.Clear();
        }
        public static void sleep(int time)
        {
            Thread.Sleep(time);
        }
        public static ConsoleKeyInfo readKey()
        {
            return System.Console.ReadKey(true);
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
            if (text == "Chesti.Console")
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
