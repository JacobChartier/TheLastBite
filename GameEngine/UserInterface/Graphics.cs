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

        private static void DebugUI()
        {
            SDL_Color foreColor = new SDL_Color() { r = 255, g = 255, b = 255, a = 255 };
            SDL_Color backColor = new SDL_Color() { r = 10, g = 10, b = 10, a = 100 };

            Label label_Name = new Label("PLAYER", manager.player.x - 5, manager.player.y + manager.player.height + 5, Application.Font_RobotoRegular, foreColor, backColor, 2);
            Label label_Pos = new Label($"PosX = {manager.player.x}, PosY = {manager.player.y}", manager.player.x - 5, manager.player.y + manager.player.height + 20, Application.Font_RobotoRegular, foreColor, backColor, 2);
            Label label_Vel = new Label($"Health = {manager.player.health}", manager.player.x - 5, manager.player.y + manager.player.height + 35, Application.Font_RobotoRegular, foreColor, backColor, 2);
        }

        private static void MenuUI()
        {
            SDL_Color backgroundColor = new SDL_Color { r = 20, g = 20, b = 20, a = 255 };
            SDL_Color foreColor = new SDL_Color { r = 200, g = 200, b = 200, a = 255 };
            SDL_Color hoverColor = new SDL_Color { r = 255, g = 255, b = 255, a = 255 };
            SDL_Color backColor = new SDL_Color { r = 10, g = 10, b = 10, a = 200 };
            SDL_Color transparent = new SDL_Color { r = 255, g = 255, b = 255, a = 0 };

            SetWindowBackColor(backgroundColor);

            Label label_Title = new Label("The last bite", 50, 50, Application.Font_TheImpostorTitle, hoverColor, transparent);
            Label label_SubTitle = new Label("Main menu", 50, 120, Application.Font_3Dventure, foreColor, transparent);

            Button button_Start = new Button("Start", 50, (Application.WINDOW_HEIGHT - 150), Application.Font_TheImpostor, foreColor, hoverColor, backColor, 15);
            if (button_Start.Clicked())
            {
                Inputs.MouseLeftButtonClicked = false;
                state = GameState.Game;
            }

            Button button_Settings = new Button("Settings", 50, (Application.WINDOW_HEIGHT - 100), Application.Font_TheImpostor, foreColor, hoverColor, backColor, 15);
            if (button_Settings.Clicked())
            {
                Inputs.MouseLeftButtonClicked = false;
                state = GameState.Settings;
            }

            Button button_Credit = new Button("Credit", 50, (Application.WINDOW_HEIGHT - 50), Application.Font_TheImpostor, foreColor, hoverColor, backColor, 15);
            if (button_Credit.Clicked())
            {
                Inputs.MouseLeftButtonClicked = false;
                state = GameState.Credit;
            }
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

        private static void SettingsUI()
        {
            SDL_Color backgroundColor = new SDL_Color { r = 20, g = 20, b = 20, a = 255 };
            SDL_Color transparent = new SDL_Color { r = 255, g = 255, b = 255, a = 0 };

            SDL_Color foreColor = new SDL_Color { r = 200, g = 200, b = 200, a = 255 };
            SDL_Color hoverColor = new SDL_Color { r = 255, g = 255, b = 255, a = 255 };

            SDL_Color backColor = new SDL_Color { r = 10, g = 10, b = 10, a = 200 };
            SDL_Color selectedColor = new SDL_Color { r = 255, g = 10, b = 10, a = 255 };


            SetWindowBackColor(backgroundColor);

            Label label_Title = new Label("The last bite", 50, 50, Application.Font_TheImpostorTitle, hoverColor, transparent);
            Label label_SubTitle = new Label("Settings", 50, 120, Application.Font_3Dventure, foreColor, transparent);

            Label label_DebugMode = new Label("Debug mode", 50, 255, Application.Font_TheImpostorSmall, foreColor, transparent);
            CheckBox checkbox_DebugMode = new CheckBox(250, 250, 25, debugMode, foreColor, backgroundColor, hoverColor, selectedColor);
            if (checkbox_DebugMode.Clicked())
            {
                Inputs.MouseLeftButtonClicked = false;
                debugMode = !debugMode;
            }
            if (checkbox_DebugMode.state == true)
            {

            }

            Button button_Back = new Button("Go back", 50, (Application.WINDOW_HEIGHT - 50), Application.Font_TheImpostor, foreColor, hoverColor, backColor, 15);
            if (button_Back.Clicked())
            {
                Inputs.MouseLeftButtonClicked = false;
                state = GameState.Menu;
            }
        }
    }
}

