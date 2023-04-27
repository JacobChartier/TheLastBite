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

        static Panel panel_Controls = new Panel(250, 0, 25, 25, color);

        static SDL_Rect[] objects = new SDL_Rect[2];

        public static void Show()
        {
            SetWindowBackColor(backgroundColor);

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
