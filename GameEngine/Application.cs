using System.Transactions;
using static SDL2.SDL;
using static SDL2.SDL_image;
using static SDL2.SDL_ttf;
using static SDL2.SDL_mixer;
using System.Net.NetworkInformation;
using GameEngine.GameElements.Platforms;

namespace GameEngine
{
    public class Application
    {
        public static bool ApplicationState = false;

        public static IntPtr Window, Renderer;

        static public IntPtr Icon = IntPtr.Zero;

        static public IntPtr
            Font_RobotoRegular = IntPtr.Zero,
            Font_RobotoBlack = IntPtr.Zero,
            Font_RobotoBlackSub = IntPtr.Zero,
            Font_LatoRegular = IntPtr.Zero,
            Font_3Dventure = IntPtr.Zero, 
            Font_TheImpostor = IntPtr.Zero, 
            Font_TheImpostorSmall = IntPtr.Zero,
            Font_TheImpostorSub = IntPtr.Zero,
            Font_TheImpostorTitle = IntPtr.Zero,
            Font_KongText = IntPtr.Zero,
            Font_KongTextSub = IntPtr.Zero,
            Font_RobotoDebug = IntPtr.Zero;

        static public IntPtr 
            Image_QJJStudios = IntPtr.Zero,
            Image_Background = IntPtr.Zero,
            Image_RocketThruster = IntPtr.Zero;

        static public IntPtr
            Music_Menu = IntPtr.Zero,
            Music_Click = IntPtr.Zero;

        static public int WINDOW_WIDTH = 1920, WINDOW_HEIGHT = 1080;

        public static void Setup()
        {
            SDL_WindowFlags windowFlags = SDL_WindowFlags.SDL_WINDOW_SHOWN | SDL_WindowFlags.SDL_WINDOW_RESIZABLE;
            SDL_RendererFlags rendererFlags = SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC;
            IMG_InitFlags imageFlags = IMG_InitFlags.IMG_INIT_PNG | IMG_InitFlags.IMG_INIT_JPG;
            MIX_InitFlags mixerFlags = MIX_InitFlags.MIX_INIT_MP3;

            ApplicationState = true;

            #region SDL initialization
            if (SDL_Init(SDL_INIT_VIDEO) < 0)
            {
                Log.Error("There was an issue starting SDL!", SDL_GetError());
                Environment.Exit(0);
            }
            else
            {
                Log.Message("SDL2 initialized successfully!");
            }
            #endregion

            #region Window creation + Icon loading
            Window = SDL_CreateWindow(
                "The last bite",
                SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED,
                WINDOW_WIDTH, WINDOW_HEIGHT,
                windowFlags);

            if (Window == IntPtr.Zero)
            {
                Log.Error("There was an issue creating the window!", SDL_GetError());
                Environment.Exit(0);
            }
            else
            {
                Log.Message("Window created successfully!");
            }

            Icon = SDL_LoadBMP("assets\\graphics\\Icon.bmp");

            if (Icon == IntPtr.Zero)
            {
                Log.Warning("Failed to load Icon.bmp!", SDL_GetError());
            }
            else
            {
                Log.Message($"Icon.bmp loaded successfully!");
            }

            SDL_SetWindowIcon(Window, Icon);
            #endregion

            #region Renderer creation
            Renderer = SDL_CreateRenderer(
                Window,
                -1,
                rendererFlags);

            if (Renderer == IntPtr.Zero)
            {
                Log.Error("There was an issue creating the renderer!", SDL_GetError());
                Environment.Exit(0);
            }
            else
            {
                Log.Message("Renderer created successfully!");
            }

            #endregion

            #region SDL_image initialization + Images loading
            if (IMG_Init(imageFlags) != (int)imageFlags)
            {
                Log.Error("There was an issue initializing SDL_image!", SDL_GetError());
                Environment.Exit(0);
            }
            else
            {
                Log.Message("SDL_image initialized successfully!");
            }

            Image_QJJStudios = IMG_LoadTexture(Renderer, "assets\\graphics\\branding\\QJJ_Studios.png");

            if(Image_QJJStudios == IntPtr.Zero)
            {
                Log.Warning("Failed to load QJJ_Studios.png!", SDL_GetError());
            }
            else
            {
                Log.Message("QJJ_Studios.png loaded successfully!");
            }

            Image_RocketThruster = IMG_LoadTexture(Renderer, "assets\\graphics\\objects\\Thruster.png");

            if (Image_RocketThruster == IntPtr.Zero)
            {
                Log.Warning("Failed to load Thruster.png!", SDL_GetError());
            }
            else
            {
                Log.Message("Thruster.png loaded successfully!");
            }

            Image_Background = IMG_LoadTexture(Renderer, "assets\\graphics\\Background2.png");

            if (Image_Background == IntPtr.Zero)
            {
                Log.Warning("Failed to load Background2.png!", SDL_GetError());
            }
            else
            {
                Log.Message("Background2.png loaded successfully!");
            }
            #endregion

            #region SDL_ttf initialization + Fonts loading
            if(TTF_Init() < 0)
            {
                Log.Error("There was an issue initializing SDL_ttf!", SDL_GetError());
                Environment.Exit(0);
            }
            else
            {
                Log.Message("SDL_ttf initialized successfully!");
            }

            Font_RobotoRegular = TTF_OpenFont("assets\\Fonts\\Roboto-Regular.ttf", 20);
            Font_RobotoBlack = TTF_OpenFont("assets\\Fonts\\Roboto-Black.ttf", 35);
            Font_RobotoBlackSub = TTF_OpenFont("assets\\Fonts\\Roboto-Black.ttf", 20);
            Font_RobotoDebug = TTF_OpenFont("assets\\Fonts\\Roboto-Black.ttf", 10);

            Font_LatoRegular = TTF_OpenFont("assets\\fonts\\Lato-Regular.ttf", 10);

            if(Font_LatoRegular == IntPtr.Zero)
            {
                Log.Warning("Failed to load Lato-Regular.ttf!", TTF_GetError());
            }
            else
            {
                Log.Message("Lato-Regular.ttf loaded successfully!");
            }

            Font_3Dventure = TTF_OpenFont("assets\\fonts\\3Dventure.ttf", 50);

            if (Font_3Dventure == IntPtr.Zero)
            {
                Log.Warning("Failed to load 3Dventure.ttf!", SDL_GetError());
            }
            else
            {
                Log.Message("3Dventure.ttf loaded successfully!");
            }

            Font_TheImpostor = TTF_OpenFont("assets\\fonts\\TheImpostor.ttf", 20);
            Font_TheImpostorSmall = TTF_OpenFont("assets\\fonts\\TheImpostor.ttf", 15);
            Font_TheImpostorSub = TTF_OpenFont("assets\\fonts\\TheImpostor.ttf", 25);
            Font_TheImpostorTitle = TTF_OpenFont("assets\\fonts\\TheImpostor.ttf", 50);

            if (Font_TheImpostor == IntPtr.Zero)
            {
                Log.Warning("Failed to load TheImpostor.ttf!", SDL_GetError());
            }
            else
            {
                Log.Message("TheImpostor.ttf loaded successfully!");
            }

            Font_KongText = TTF_OpenFont("assets\\fonts\\KongText.ttf", 25);
            Font_KongTextSub = TTF_OpenFont("assets\\fonts\\KongText.ttf", 15);

            if (Font_KongText == IntPtr.Zero)
            {
                Log.Warning("Failed to load KongText.ttf!", SDL_GetError());
            }
            else
            {
                Log.Message("KongText.ttf loaded successfully!");
            }
            #endregion

            #region SDL_mixer initialization + Sounds loading
            Mix_OpenAudio(22050, MIX_DEFAULT_FORMAT, 0, 640);

            if (Mix_Init(mixerFlags) < 0)
            {
                Log.Error("There was an issue initializing SDL_mixer!", SDL_GetError());
                Environment.Exit(0);
            }
            else
            {
                Log.Message("SDL_mixer initialized successfully!");
            }

            Music_Menu = Mix_LoadMUS("assets\\audio\\Menu.mp3");

            if(Music_Menu == IntPtr.Zero)
            {
                Log.Warning("Failed to load Menu.mp3!", Mix_GetError());
            }
            else
            {
                Log.Message("Menu.mp3 loaded successfully!");
            }

            Music_Click = Mix_LoadMUS("assets\\audio\\Click.mp3");

            if(Music_Click == IntPtr.Zero)
            {
                Log.Warning("Failed to load Click.mp3!", Mix_GetError());
            }
            else
            {
                Log.Message("Click.mp3 loaded successfully!");
            }

            //Audio.play(Application.Music_Menu);
            #endregion


            if(SDL_Init(SDL_INIT_TIMER) < 0)
            {
                Log.Error("There was an issue starting SDL_timer!", SDL_GetError());
                Environment.Exit(0);
            }
            else
            {
                Log.Message("SDL_timer initialized successfully!");
            }
        }

        public static void Close()
        {
            ApplicationState = false;

            SDL_DestroyWindow(Window);
            SDL_DestroyRenderer(Renderer);

            SDL_DestroyTexture(Icon);
            SDL_DestroyTexture(Image_QJJStudios);
            SDL_DestroyTexture(Image_Background);
            SDL_DestroyTexture(Image_RocketThruster);

            TTF_CloseFont(Font_RobotoRegular);
            TTF_CloseFont(Font_RobotoBlack);
            TTF_CloseFont(Font_RobotoBlackSub);
            TTF_CloseFont(Font_LatoRegular);
            TTF_CloseFont(Font_3Dventure);
            TTF_CloseFont(Font_TheImpostor);
            TTF_CloseFont(Font_TheImpostorSmall);
            TTF_CloseFont(Font_TheImpostorSub);
            TTF_CloseFont(Font_TheImpostorTitle);
            TTF_CloseFont(Font_KongText);
            TTF_CloseFont(Font_KongTextSub);

            SDL_Quit();

            Log.Message("Application is closed");
        }
    }
}