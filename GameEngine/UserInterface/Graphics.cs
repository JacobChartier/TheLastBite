using GameEngine.GameElements;
using GameEngine.GameElements.Characters;
using System.Runtime.CompilerServices;
using static SDL2.SDL;
using static SDL2.SDL_ttf;

namespace GameEngine.UserInterface
{
    public class Graphics
    {
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

        public static void Render(IntPtr Renderer)
        {
            SDL_SetRenderDrawBlendMode(Application.Renderer, SDL_BlendMode.SDL_BLENDMODE_BLEND);

            switch (state)
            {
                case GameState.Menu:
                    MenuUI();
                    break;

                case GameState.Game:
                    GameUI();

                    if (debugMode)
                    {
                        DebugUI();
                    }
                    break;

                case GameState.Settings:
                    SettingsUI();
                    break;

                case GameState.Credit:
                    CreditUI();
                    break;

                case GameState.Loading:
                    LoadingUI();
                    break;

                case GameState.Pause:
                    PauseUI();
                    break;

                default:
                    MenuUI();
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

            Label label_Name = new Label("PLAYER", manager.player.positionX - 5, manager.player.positionY + manager.player.height + 5, Application.Font_LatoRegular, foreColor, backColor, 2);
            Label label_Pos = new Label($"PosX = {manager.player.positionX}, PosY = {manager.player.positionY}", manager.player.positionX - 5, manager.player.positionY + manager.player.height + 20, Application.Font_LatoRegular, foreColor, backColor, 2);
            Label label_Vel = new Label($"Health = {manager.player.health}", manager.player.positionX - 5, manager.player.positionY + manager.player.height + 35, Application.Font_LatoRegular, foreColor, backColor, 2);
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
                state = GameState.Loading;
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
            SDL_Color transparent = new SDL_Color { r = 255, g = 255, b = 255, a = 0 };

            SetWindowBackColor(backgroundColor);

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

        private static void CreditUI()
        {
            SDL_Color backgroundColor = new SDL_Color { r = 20, g = 20, b = 20, a = 255 };
            SDL_Color foreColor = new SDL_Color { r = 200, g = 200, b = 200, a = 255 };
            SDL_Color hoverColor = new SDL_Color { r = 255, g = 255, b = 255, a = 255 };
            SDL_Color backColor = new SDL_Color { r = 10, g = 10, b = 10, a = 200 };
            SDL_Color labelbackColor = new SDL_Color { r = 10, g = 10, b = 10, a = 255 };
            SDL_Color transparent = new SDL_Color { r = 255, g = 255, b = 255, a = 0 };
            SDL_Color gold = new SDL_Color { r = 212, g = 175, b = 55, a = 255 };

            SetWindowBackColor(backgroundColor);

            Label label_Title = new Label("The last bite", 50, 50, Application.Font_TheImpostorTitle, hoverColor, transparent);

            Label label_MadeBy = new Label("Made by:", 50, 150, Application.Font_TheImpostorSub, gold, labelbackColor);

            Label label_QH = new Label("Quoc Huy Ly", 100, 200, Application.Font_KongText, hoverColor, labelbackColor);
            Label label_Sub_QH = new Label("???", label_QH.width + 125, label_QH.y + 6, Application.Font_KongTextSub, foreColor, transparent);

            Label label_JM = new Label("Jaime Meza Uribe", 100, 250, Application.Font_KongText, hoverColor, labelbackColor);
            Label label_Sub_JM = new Label("???", label_JM.width + 125, label_JM.y + 6, Application.Font_KongTextSub, foreColor, transparent);

            Label label_JC = new Label("Jacob Chartier", 100, 300, Application.Font_KongText, hoverColor, labelbackColor);
            Label label_Sub_JC = new Label("???", label_JC.width + 125, label_JC.y + 6, Application.Font_KongTextSub, foreColor, transparent);

            Button button_Back = new Button("Go back", 50, (Application.WINDOW_HEIGHT - 50), Application.Font_TheImpostor, foreColor, hoverColor, backColor, 15);
            if (button_Back.Clicked())
            {
                Inputs.MouseLeftButtonClicked = false;
                state = GameState.Menu;
            }
        }

        private static void LoadingUI()
        {
            SDL_Color backgroundColor = new SDL_Color { r = 20, g = 20, b = 20, a = 255 };
            SDL_Color foreColor = new SDL_Color { r = 255, g = 255, b = 255, a = 255 };
            SDL_Color transparent = new SDL_Color { r = 255, g = 255, b = 255, a = 0 };

            SetWindowBackColor(backgroundColor);

            Label label_Loading = new Label("Loading...", 50, (Application.WINDOW_HEIGHT - 100), Application.Font_TheImpostor, foreColor, transparent);

            state = GameState.Game;
        }

        private static void PauseUI()
        {
            SDL_Color backgroundColor = new SDL_Color { r = 20, g = 20, b = 20, a = 255 };
            SDL_Color foreColor = new SDL_Color { r = 255, g = 255, b = 255, a = 255 };
            SDL_Color hoverColor = new SDL_Color { r = 255, g = 255, b = 255, a = 255 };
            SDL_Color backColor = new SDL_Color { r = 10, g = 10, b = 10, a = 200 };
            SDL_Color transparent = new SDL_Color { r = 255, g = 255, b = 255, a = 0 };

            SetWindowBackColor(backgroundColor);

            Label label_Pause = new Label("PAUSE", 50, 50, Application.Font_KongTextSub, foreColor, transparent, 25);

            Button button_Resume = new Button("Resume", 50, (Application.WINDOW_HEIGHT - 50), Application.Font_TheImpostor, foreColor, hoverColor, backColor);

        }
    }
}
