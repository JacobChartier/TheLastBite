using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    internal class Log
    {
        static string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
        static string RED = Console.IsOutputRedirected ? "" : "\x1b[91m";
        static string GREEN = Console.IsOutputRedirected ? "" : "\x1b[92m";
        static string YELLOW = Console.IsOutputRedirected ? "" : "\x1b[93m";
        static string BLUE = Console.IsOutputRedirected ? "" : "\x1b[94m";
        static string MAGENTA = Console.IsOutputRedirected ? "" : "\x1b[95m";
        static string CYAN = Console.IsOutputRedirected ? "" : "\x1b[96m";
        static string GREY = Console.IsOutputRedirected ? "" : "\x1b[97m";

        internal static void Message(string message)
        {
            Console.WriteLine($"{message}");
        }

        internal static void Warning(string message)
        {
            Console.WriteLine($"{YELLOW}{message}{NORMAL}");
        }

        internal static void Error(string message)
        {
            Console.WriteLine($"{RED}{message}{NORMAL}");
        }
    }
}
