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
            Graphics gfx = new Graphics();

            try
            {
                Application.Setup();

                Inputs.KeyPressedEvent += Inputs.OnKeyPressed;
//              Inputs.KeyReleasedEvent += Inputs.OnKeyReleased;
                
                Inputs.MouseButtonDownEvent += Inputs.OnMouseButtonPressed;
                Inputs.MouseButtonUpEvent += Inputs.OnMouseButtonReleased;

                while (Application.ApplicationState)
                {
                    Inputs.Handler();
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
