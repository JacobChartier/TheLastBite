using GameEngine;

namespace TheLastBite
{
    internal class Program
    {
        public static IntPtr Window, Renderer;

        static void Main(string[] args)
        {
            Application.Setup(ref Window, ref Renderer);

            while (true) 
            {
                Application.HandleEvents();
                Graphics.Render(Renderer);
            }
        }
    }
}