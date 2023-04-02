using static SDL2.SDL;

namespace GameEngine
{
    public class Graphics
    {
        public static SDL_Rect rect1 = new SDL_Rect()
        {
            x = 50,
            y = 50,
            w = 50,
            h = 50
        };

        public static void Render(IntPtr Renderer)
        {
            SDL_SetRenderDrawColor(
                Renderer,
                20, 20, 20, 255);
            SDL_RenderClear(Renderer);

            SDL_SetRenderDrawColor(
                Renderer,
                255, 0, 0, 255);
            SDL_RenderDrawRect(Renderer, ref rect1);

            FontBlit(Application.TextImage, 10, 10);
            FontBlit(Application.TextImage, 300, 300);
            FontBlit(Application.TextImage, 300, 300);

            SDL_RenderPresent(Renderer);
        }

        public static void FontBlit(IntPtr texture, int x, int y)
        {
            SDL_Rect destination;

            destination.x = x;
            destination.y = y;

            SDL_QueryTexture(texture, out uint format, out int access, out int width, out int height);

            destination.w = width;
            destination.h = height;

            SDL_RenderCopy(Application.Renderer, texture, IntPtr.Zero, ref destination);
        }
    }
}
