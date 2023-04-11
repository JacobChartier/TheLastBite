using GameEngine.GameElements.Characters;
using static SDL2.SDL;

namespace GameEngine.GameElements.Platforms
{
    internal class Platform
    {
        public int PosX { get; set; }
        public int PosY { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public SDL_Rect platform;

        public void Basic(int PosX, int PosY, int width, int height)
        {
            platform = new SDL_Rect() { x = PosX, y = PosY, w = width, h = height };

            SDL_SetRenderDrawColor(Application.Renderer, 0, 255, 0, 255);
            SDL_RenderFillRect(Application.Renderer, ref platform);
        }
    }
}
