using GameEngine.GameElements;
using GameEngine.GameElements.Characters;
using GameEngine.GameElements.Platforms;
using System.Security.AccessControl;
using static GameEngine.UserInterface.Graphics;

using static SDL2.SDL;

namespace GameEngine.UserInterface.UI
{
    internal class Scene
    {
        static GameManager manager = Graphics.manager;

        static Color color = new Color() { red = 32, green = 232, blue = 243, alpha = 255};

        static Basic platform = new Basic(Application.WINDOW_WIDTH - 100, 50, 50, 50);
        static Basic platform1 = new Basic(50, 50, 50, 50);

        static Button button_Pause = new Button(" I I ", 50, 50, Application.Font_RobotoBlackSub, btn_white, btn_hover, buttonBackground);

        static Panel panel_Controls = new Panel(250, 0, 25, 25, color);

        static SDL_Rect[] objects = new SDL_Rect[2];

        public static void Show()
        {
            SetWindowBackColor(backgroundColor);

            button_Pause.Show();
            if (button_Pause.Clicked())
            {
                Inputs.MouseLeftButtonClicked = false;
                Graphics.state = GameState.Pause;
            }

            manager.player.Update();

            for (int i = 0; i < objects.Length; i++)
            {
                if (!manager.player.CheckCollision(objects[i]))
                {
                    manager.player.collider = true;
                }
                else
                {
                    manager.player.collider = false;
                }
            }
        }
    }
}
