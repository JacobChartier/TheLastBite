using static SDL2.SDL;
using static SDL2.SDL_ttf;

namespace GameEngine.UserInterface
{
    internal class Button
    {
        public string text { get; set; }
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; private set; }
        public int margin { get; private set; }

        private IntPtr texture { get; set; }
        public IntPtr font { get; set; }

        public SDL_Color foreColor { get; set; }
        public SDL_Color hoverColor { get; set; }
        public SDL_Color backColor { get; set; }

        public SDL_Rect region;

        public Button(string text, int x, int y, IntPtr font, SDL_Color foreColor, SDL_Color hoverColor, SDL_Color backColor, int margin = 10)
        {
            this.text = text;
            this.x = x;
            this.y = y;
            this.margin = margin;
            this.font = font;

            this.foreColor = foreColor;
            this.hoverColor = hoverColor;
            this.backColor = backColor;

            foreColor = new SDL_Color() { r = foreColor.r, g = foreColor.g, b = foreColor.b, a = foreColor.a };
            hoverColor = new SDL_Color() { r = hoverColor.r, g = hoverColor.g, b = hoverColor.b, a = hoverColor.a };
            backColor = new SDL_Color() { r = backColor.r, g = backColor.g, b = backColor.b, a = backColor.a };

            region = new SDL_Rect() { x = x, y = y, w = width, h = height };

            this.texture = CreateTexture(foreColor);

            Blit(this.texture, x, y);

            region = new SDL_Rect() { x = (x - (margin/2) - 2), y = (y - (margin / 2) - 2), w = (width + margin), h = (height + margin) };

            SDL_SetRenderDrawColor(Application.Renderer, backColor.r, backColor.g, backColor.b, backColor.a);
            SDL_RenderFillRect(Application.Renderer, ref region);

            MouseHoverAnimation(foreColor, hoverColor);
            Clicked();

            Blit(this.texture, x, y);
        }

        private IntPtr CreateTexture(SDL_Color foreColor)
        {
            return SDL_CreateTextureFromSurface(Application.Renderer, TTF_RenderUTF8_Blended(font, text, foreColor));
        }

        private void Blit(IntPtr texture, int x, int y)
        {
            region.x = x;
            region.y = y;

            SDL_QueryTexture(texture, out uint format, out int access, out int w, out int h);

            width = w;
            height = h;
            
            region.w = w;
            region.h = h;

            SDL_RenderCopy(Application.Renderer, texture, IntPtr.Zero, ref region);
        }

        public bool MouseHover()
        {
            if (Inputs.MouseMotionX > region.x && Inputs.MouseMotionX < (region.x + region.w) &&        // Check if the mouse is in the region on the X axis.
                Inputs.MouseMotionY > region.y && Inputs.MouseMotionY < (region.y + region.h))          // Check if the mouse is in the region on the Y axis.
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Clicked()
        {
            if (Inputs.MouseLeftButtonClicked && MouseHover())
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private void MouseHoverAnimation(SDL_Color foreColor, SDL_Color hoverColor)
        {
            if (MouseHover())
            {
                this.texture = CreateTexture(hoverColor);
            }
            else
            {
                this.texture = CreateTexture(foreColor);
            }
        }
    }
}
