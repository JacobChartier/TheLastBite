using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SDL2.SDL;

namespace GameEngine.UserInterface.UI
{
    public struct Rectangle
    {
        public int x, y, width, height;
    }

    public struct Color
    {
        public byte red, green, blue, alpha;
    }

    public enum Align
    {
        CENTERED,
        LEFT
    }

    public enum Direction
    {
        Left, Right, Top, Bottom
    }
    public abstract class UI
    {
        public Rectangle rectangle;
        public SDL_Rect region;
        public Color color;

        public UI(int x, int y, int width, int height, Color color)
        {
            rectangle.x = x;
            rectangle.y = y;
            rectangle.width = width;
            rectangle.height = height;

            this.color.red = color.red;
            this.color.green = color.green;
            this.color.blue = color.blue;
            this.color.alpha = color.alpha;

            region.x = x;
            region.y = y;
            region.w = width;
            region.h = height;
        }

        public UI(Align x, Align y, int width, int height, Color color)
        {
            switch (x)
            {
                case Align.CENTERED:
                    rectangle.x = (int)((Application.WINDOW_WIDTH / 2) - (width / 2));
                    break;

                case Align.LEFT:
                    rectangle.x = (int)((Application.WINDOW_WIDTH / 5) * 100);
                    break;
            }

            switch (y)
            {
                case Align.CENTERED:
                    rectangle.y = ((Application.WINDOW_HEIGHT / 2) - (height / 2)); 
                    break;
            }

            rectangle.width = width;
            rectangle.height = height;

            this.color.red = color.red;
            this.color.green = color.green;
            this.color.blue = color.blue;
            this.color.alpha = color.alpha;

            region.x = rectangle.x;
            region.y = rectangle.y;
            region.w = width;
            region.h = height;
        }

        private SDL_Rect ConvertRectToSDL(Rectangle rectangle)
        {
            SDL_Rect sdlRectangle;

            sdlRectangle.x = rectangle.x;
            sdlRectangle.y = rectangle.y;
            sdlRectangle.w = rectangle.width;
            sdlRectangle.h = rectangle.height;

            return sdlRectangle;
        }

        public virtual void DrawRectangle(Rectangle rectangle, Color color)
        {
            SDL_Rect sdlRectangle = ConvertRectToSDL(rectangle);

            SDL_SetRenderDrawColor(Application.Renderer, color.red, color.green, color.blue, color.alpha);
            SDL_RenderFillRect(Application.Renderer, ref sdlRectangle);
        }

        public abstract void Show();
    }
}
