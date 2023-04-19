using static SDL2.SDL;

namespace GameEngine.UserInterface
{
    internal class Slider
    {
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int value { get; set; }

        public SDL_Color barColor { get; set; }
        public SDL_Color sliderColor { get; set; }

        public SDL_Rect barRegion { get; private set; }
        public SDL_Rect sliderRegion { get; private set; }

        public Slider(int x, int y, int width, int height, SDL_Color barColor, SDL_Color sliderColor, int value) 
        { 
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
                
            this.barColor = barColor;
            this.sliderColor = sliderColor;

            this.value = value;

            barRegion = new SDL_Rect { x = x, y = y, w = width, h = 4 };
            sliderRegion = new SDL_Rect { x = x, y = y, w = 5, h = 10 };
        }

        public void Show()
        {
            SDL_SetRenderDrawColor(Application.Renderer, barColor.r, barColor.g, barColor.b, barColor.a);
            //SDL_RenderDrawRect(Application.Renderer, ref barRegion);
        }
    }
}
