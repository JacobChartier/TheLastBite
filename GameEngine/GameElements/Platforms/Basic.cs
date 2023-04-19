using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SDL2.SDL;

namespace GameEngine.GameElements.Platforms
{
    internal class Basic
    {
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; set; }

        public SDL_Rect hitbox;

        public Basic(int x, int y, int width, int height)
        {
            hitbox = new SDL_Rect { x = x, y = y, w = width, h = height };
        }
    
        public void Show()
        {
            SDL_SetRenderDrawColor(Application.Renderer, 0, 255, 0, 255);
            SDL_RenderFillRect(Application.Renderer, ref hitbox);
        }
    }
}
