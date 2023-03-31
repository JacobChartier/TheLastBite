using static SDL2.SDL;

namespace GameEngine
{
    public class Graphics
    {
        public static void Render(IntPtr Renderer)
        {
            SDL_SetRenderDrawColor(
                Renderer,
                20, 20, 20, 255);

            SDL_RenderClear(Renderer);
            SDL_RenderPresent(Renderer);
        }
    }
}
