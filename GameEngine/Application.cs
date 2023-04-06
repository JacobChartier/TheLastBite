using static SDL2.SDL;
using static SDL2.SDL_image;
using static SDL2.SDL_ttf;

namespace GameEngine
{
    public class Application
    {
        public static IntPtr Window, Renderer;

        static public IntPtr Icon = IntPtr.Zero;

        static public IntPtr
            Font_LatoRegular = IntPtr.Zero,
            Font_3Dventure = IntPtr.Zero, 
            Font_TheImpostor = IntPtr.Zero, 
            Font_TheImpostorSmall = IntPtr.Zero,
            Font_TheImpostorSub = IntPtr.Zero,
            Font_TheImpostorTitle = IntPtr.Zero,
            Font_KongText = IntPtr.Zero,
            Font_KongTextSub = IntPtr.Zero;

        static public IntPtr 
            Image_RocketThruster = IntPtr.Zero;

        public const int WINDOW_WIDTH = 1080, WINDOW_HEIGHT = 620;

        public static void Setup()
        {
            SDL_WindowFlags windowFlags = SDL_WindowFlags.SDL_WINDOW_SHOWN;
            SDL_RendererFlags rendererFlags = SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC;
            IMG_InitFlags imageFlags = IMG_InitFlags.IMG_INIT_PNG | IMG_InitFlags.IMG_INIT_JPG;

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

            Image_RocketThruster = IMG_LoadTexture(Renderer, "assets\\graphics\\Objects\\Thruster.png");

            if (Image_RocketThruster == IntPtr.Zero)
            {
                Log.Warning("Failed to load Thruster.png!", SDL_GetError());
            }
            else
            {
                Log.Message("Thruster.png loaded successfully!");
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

            Font_LatoRegular = TTF_OpenFont("assets\\fonts\\Lato-Regular.ttf", 10);

            if(Font_LatoRegular == IntPtr.Zero)
            {
                Log.Warning("Failed to load Lato-Regular.ttf!", SDL_GetError());
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
        }
    }
}