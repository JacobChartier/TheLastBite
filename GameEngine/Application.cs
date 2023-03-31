using static SDL2.SDL;
using static SDL2.SDL_image;

namespace GameEngine
{
    public class Application
    {

        public static void Setup(IntPtr Window, IntPtr Renderer)
        {
            SDL_WindowFlags windowFlags = SDL_WindowFlags.SDL_WINDOW_SHOWN;
            SDL_RendererFlags rendererFlags = SDL_RendererFlags.SDL_RENDERER_ACCELERATED | SDL_RendererFlags.SDL_RENDERER_PRESENTVSYNC;

            if (SDL_Init(SDL_INIT_VIDEO) < 0)
            {
                Console.WriteLine($"There was an issue starting SDL! \n{SDL_GetError()}");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("SDL initialized successfully!");
            }

            Window = SDL_CreateWindow(
                "The last bite",
                SDL_WINDOWPOS_UNDEFINED, SDL_WINDOWPOS_UNDEFINED,
                1080, 620,
                windowFlags);

            if (Window == IntPtr.Zero)
            {
                Console.WriteLine($"There was an issue creating the window! \n{SDL_GetError()}");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Window created successfully!");
            }

            Renderer = SDL_CreateRenderer(
                Window,
                -1,
                rendererFlags);

            if (Renderer == IntPtr.Zero)
            {
                Console.WriteLine($"There was an issue creating the renderer! \n{SDL_GetError()}");
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Renderer created successfully!");
            }
        }

        public static void HandleEvents()
        {
            while (SDL_PollEvent(out SDL_Event events) == 1)
            {
                switch (events.type)
                {
                    case SDL_EventType.SDL_QUIT:
                        SDL_Quit();
                        Environment.Exit(0);
                        break;

                    default:
                        break;
                }
            }
        }
    }
}