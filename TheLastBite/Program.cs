using GameEngine;
using SDL2;

namespace TheLastBite
{
    internal class Program
    {
        public static IntPtr Window, Renderer;

        static void Main(string[] args)
        {
            Application.Setup(Window, Renderer);

            while (true) 
            {
                Application.HandleEvents();
            }
        }
    }
}