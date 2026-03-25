using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace chesti
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
            System.Threading.Thread.Sleep(time);
        }
        public static ConsoleKeyInfo readKey()
        {
            return Console.ReadKey();
        }
    }
}
