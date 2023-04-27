
namespace GameEngine
{
    public class Log
    {
        static string NORMAL = Console.IsOutputRedirected ? "" : "\x1b[39m";
        static string RED = Console.IsOutputRedirected ? "" : "\x1b[91m";
        static string GREEN = Console.IsOutputRedirected ? "" : "\x1b[92m";
        static string YELLOW = Console.IsOutputRedirected ? "" : "\x1b[93m";
        static string BLUE = Console.IsOutputRedirected ? "" : "\x1b[94m";
        static string MAGENTA = Console.IsOutputRedirected ? "" : "\x1b[95m";
        static string CYAN = Console.IsOutputRedirected ? "" : "\x1b[96m";
        static string GREY = Console.IsOutputRedirected ? "" : "\x1b[97m";

        public static void Message(string message)
        {
            Console.WriteLine($"{message}");
        }

        public static void Warning(string message, string errorProvider)
        {
            Console.WriteLine($"{YELLOW}{message}\n > {errorProvider}{NORMAL}");
        }

        public static void Error(string message, string errorProvider)
        {
            Console.WriteLine($"{RED}{message}\n > {errorProvider}{NORMAL}");
        }
    }
}
