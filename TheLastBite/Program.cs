using GameEngine;
using GameEngine.GameElements.Characters;
using GameEngine.UserInterface;
using System.Reflection.Metadata.Ecma335;

namespace TheLastBite
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Application app = new Application();
            Graphics gfx = new Graphics();
            try
            {
                app.Setup();

                Inputs.KeyPressedEvent += Inputs.OnKeyPressed;

                Inputs.MouseButtonDownEvent += Inputs.OnMouseButtonPressed;
                Inputs.MouseButtonUpEvent += Inputs.OnMouseButtonReleased;

                while (Application.ApplicationState)
                {
                    Inputs.Handler();
                    app.Update();
                    gfx.Render(Application.Renderer);
                }
            }
            catch (Exception exception)
            {
                Log.Error("Error occured in Main(string[] args) function!", exception.Message);
            }
        }
    }
}