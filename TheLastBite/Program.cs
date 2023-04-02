using GameEngine;

namespace TheLastBite
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Application.Setup();

            Events.KeyPressedEvent += Events.OnKeyPressed;

            while (true) 
            {
                Events.Handler();
                Graphics.Render(Application.Renderer);
            }
        }
    }
}