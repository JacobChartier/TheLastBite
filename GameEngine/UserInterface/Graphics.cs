using GameEngine.GameElements;
using GameEngine.GameElements.Characters;
using GameEngine.GameElements.Platforms;
using System.Runtime.CompilerServices;
using static SDL2.SDL;
using static SDL2.SDL_ttf;
using static GameEngine.UserInterface.UI.Credit;
using GameEngine.UserInterface.UI;

namespace GameEngine.UserInterface
{
    public class Graphics
    {
        public static SDL_Color backgroundColor = new SDL_Color { r = 5, g = 5, b = 5, a = 255 };
        public static SDL_Color transparent = new SDL_Color { r = 0, g = 0, b = 0, a = 0 };
        public static SDL_Color error = new SDL_Color { r = 255, g = 0, b = 0, a = 0 };

        public static SDL_Color chk_selected = new SDL_Color { r = 74, g = 243, b = 255, a = 255};

        public static SDL_Color btn_hover = new SDL_Color { r = 255, g = 255, b = 255, a = 255 };
        public static SDL_Color btn_white = new SDL_Color { r = 200, g = 200, b = 200, a = 255 };
        public static SDL_Color buttonBackground = new SDL_Color { r = 15, g = 15, b = 15, a = 255 };

        public static SDL_Color white = new SDL_Color { r = 255, g = 255, b = 255, a = 255 };

        public enum GameState
        {
            Menu,
            Settings,
            Loading,
            Credit,
            Pause,
            Game
        }

        public static GameState state;

        public static bool debugMode = true;

        public static GameManager manager = new GameManager();
        public static Credit credit = new Credit();

        public static void Render(IntPtr Renderer)
        {
            SDL_GetWindowSize(Application.Window, out Application.WINDOW_WIDTH, out Application.WINDOW_HEIGHT);

            SDL_SetRenderDrawBlendMode(Application.Renderer, SDL_BlendMode.SDL_BLENDMODE_BLEND);

            switch (state)
            {
                case GameState.Menu:
                    Menu.UI();
                    break;

                case GameState.Game:
                    Scene.Show();

                    if (debugMode)
                    {
                        //DebugUI();
                    }
                    break;

                case GameState.Settings:
                    Settings.UI();
                    break;

                case GameState.Credit:
                    Credit.UI();
                    break;

                case GameState.Loading:
                    //LoadingUI();
                    break;

                case GameState.Pause:
                    //PauseUI();
                    break;

                default:
                    Menu.UI();
                    break;
            }

            SDL_RenderPresent(Renderer);
        }

        public static void SetWindowBackColor(SDL_Color color)
        {
            SDL_SetRenderDrawColor(Application.Renderer, color.r, color.g, color.b, color.a);

            SDL_RenderClear(Application.Renderer);
        }

        private static void GameUI()
        {
            SDL_Color backgroundColor = new SDL_Color { r = 20, g = 20, b = 250, a = 255 };
            SDL_Color foreColor = new SDL_Color { r = 255, g = 255, b = 255, a = 255 };
            SDL_Color backColor = new SDL_Color { r = 10, g = 10, b = 10, a = 200 };

            Platform platform = new Platform();
            SetWindowBackColor(backgroundColor);

            platform.Basic(25, Application.WINDOW_HEIGHT - 50, Application.WINDOW_WIDTH - 50, Application.WINDOW_HEIGHT / 3);
            Label label_Timer = new Label("Time left", 35, 35, Application.Font_TheImpostorSmall, foreColor, backColor);
            Label label_varTimer = new Label("10:00", 35, 70, Application.Font_TheImpostorSmall, foreColor, transparent);

            Label label_Collected = new Label("Item collected", Application.WINDOW_WIDTH - 215, 35, Application.Font_TheImpostorSmall, foreColor, backColor);
            Label label_varCollected = new Label($"0 of 3", Application.WINDOW_WIDTH - 109, 70, Application.Font_TheImpostorSmall, foreColor, transparent);


            manager.player.Update();
        }
    }
}

