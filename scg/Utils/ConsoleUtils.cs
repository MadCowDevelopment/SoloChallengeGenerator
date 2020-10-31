using System;
using System.Text;

namespace scg.Utils
{
    public static class ConsoleUtils
    {
        public static string ReadPassword()
        {
            var pwd = new StringBuilder();
            while (true)
            {
                var i = Console.ReadKey(true);
                if (i.Key == ConsoleKey.Enter)
                {
                    break;
                }
                
                if (i.Key == ConsoleKey.Backspace)
                {
                    if (pwd.Length > 0)
                    {
                        pwd.Remove(pwd.Length - 1, 1);
                        Console.Write("\b \b");
                    }
                }
                else if (i.KeyChar != '\u0000') // KeyChar == '\u0000' if the key pressed does not correspond to a printable character, e.g. F1, Pause-Break, etc
                {
                    pwd.Append(i.KeyChar);
                    Console.Write("*");
                }
            }

            Console.WriteLine();
            return pwd.ToString();
        }
        
        public static double ReadValidDouble(double? initial, string message)
        {
            var result = initial;
            while (result == null)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out var tmp))
                {
                    result = tmp;
                }
            }

            return result.Value;
        }

        public static int ReadValidInt(int? initial, string message)
        {
            var result = initial;
            while (result == null)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out var tmp))
                {
                    result = tmp;
                }
            }

            return result.Value;
        }

        public static string ReadValidString(string initial, string message)
        {
            var result = initial;
            while (string.IsNullOrEmpty(result))
            {
                Console.Write(message);
                result = Console.ReadLine();
            }

            return result;
        }
    }
}