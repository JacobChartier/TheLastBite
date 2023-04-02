using static SDL2.SDL;
using static SDL2.SDL_image;
using static SDL2.SDL_ttf;

namespace GameEngine
{
    public class Application
    {
        public static IntPtr Window, Renderer;

        static public IntPtr Icon = IntPtr.Zero;                                // Icon pointer
        static public IntPtr Font_LatoRegular = IntPtr.Zero, TextImage = IntPtr.Zero;       // Font pointers

        public static void Setup()
        {
            SDL_WindowFlags windowFlags = SDL_WindowFlags.SDL_WINDOW_SHOWN;
            SDL_RendererFlags rendererFlags = SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC;
            IMG_InitFlags imageFlags = IMG_InitFlags.IMG_INIT_PNG | IMG_InitFlags.IMG_INIT_JPG;

            #region SDL initialization
            if (SDL_Init(SDL_INIT_VIDEO) < 0)
            {
                Log.Error($"There was an issue starting SDL!\n > {SDL_GetError()}");
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
                1080, 620,
                windowFlags);

            if (Window == IntPtr.Zero)
            {
                Log.Error($"There was an issue creating the window!\n > {SDL_GetError()}");
                Environment.Exit(0);
            }
            else
            {
                Log.Message("Window created successfully!");
            }

            Icon = SDL_LoadBMP("assets\\graphics\\Icon.bmp");

            if (Icon == IntPtr.Zero)
            {
                Log.Warning($"Failed to load Icon.bmp!\n > {SDL_GetError()}");
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
                Log.Error($"There was an issue creating the renderer!\n > {SDL_GetError()}");
                Environment.Exit(0);
            }
            else
            {
                Log.Message("Renderer created successfully!");
            }
            #endregion

            #region SDL_image initialization + Images loading
            if(IMG_Init(imageFlags) != (int)imageFlags)
            {
                Log.Error($"There was an issue initializing SDL_image!\t{SDL_GetError()}");
                Environment.Exit(0);
            }
            else
            {
                Log.Message("SDL_image initialized successfully!");
            }
            #endregion

            #region SDL_ttf initialization + Fonts loading
            if(TTF_Init() < 0)
            {
                Log.Error($"There was an issue initializing SDL_ttf!\n > {SDL_GetError()}");
                Environment.Exit(0);
            }
            else
            {
                Log.Message("SDL_ttf initialized successfully!");
            }

            Font_LatoRegular = TTF_OpenFont("assets\\fonts\\Lato-Bold.ttf", 30);

            if(Font_LatoRegular == IntPtr.Zero)
            {
                Log.Warning($"Failed to load Lato-Regular.ttf!\n > {SDL_GetError()}");
            }
            else
            {
                Log.Message("Lato-Regular.ttf loaded successfully!");
            }

            SDL_Color textColor = new SDL_Color { r = 255, g = 255, b = 255, a = 255 };

            TextImage = SDL_CreateTextureFromSurface(Renderer, TTF_RenderUTF8_Blended(Font_LatoRegular, "The Last Bite", textColor));
            #endregion

        }
    }
}