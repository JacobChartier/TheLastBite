using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SDL2.SDL;

namespace GameEngine.UserInterface
{
    internal class CheckBox
    {
        public int x { get; set; }
        public int y { get; set; }
        public int width { get; set; }
        public int height { get; private set; }
        public int margin { get; private set; }
        public bool state { get; set; }

        public SDL_Color borderColor { get; set; }
        public SDL_Color backColor { get; set; }
        public SDL_Color hoverColor { get; set; }
        public SDL_Color selectedColor { get; set; }

        public SDL_Rect borderRegion, innerRegion, selectedRegion;

        public CheckBox(int x, int y, int size, bool state, SDL_Color borderColor, SDL_Color backColor, SDL_Color hoverColor, SDL_Color selectedColor, int margin = 3)
        {
            this.x = x;
            this.y = y;
            this.width = size;
            this.height = size;
            this.state = state;
            this.margin = margin;

            this.borderColor = borderColor;
            this.backColor = backColor;
            this.hoverColor = hoverColor;
            this.selectedColor = selectedColor;

            borderColor = new SDL_Color() { r = borderColor.r, g = borderColor.g, b = borderColor.b, a = borderColor.a };
            backColor = new SDL_Color() { r = backColor.r, g = backColor.g, b = backColor.b, a = backColor.a };
            hoverColor = new SDL_Color() { r = hoverColor.r, g = hoverColor.g, b = hoverColor.b, a = hoverColor.a };
            selectedColor = new SDL_Color() { r = selectedColor.r, g = selectedColor.g, b = selectedColor.b, a = selectedColor.a };

            borderRegion = new SDL_Rect() { x = x, y = y, w = width, h = height };
            innerRegion = new SDL_Rect() { x = x + margin, y = y + margin, w = width - (2 * margin), h = height - (2 * margin) };
            selectedRegion = new SDL_Rect() { x = x + (3 * margin), y = y + (3 * margin), w = width - (6 * margin), h = height - (6 * margin) };

            MouseHoverAnimation(hoverColor);
        }

        public void CreateBox(SDL_Color borderColor, SDL_Color backColor, SDL_Color selectedColor)
        {
            if (state)
            {
                SDL_SetRenderDrawColor(Application.Renderer, borderColor.r, borderColor.g, borderColor.b, borderColor.a);
                SDL_RenderFillRect(Application.Renderer, ref borderRegion);

                SDL_SetRenderDrawColor(Application.Renderer, backColor.r, backColor.g, backColor.b, backColor.a);
                SDL_RenderFillRect(Application.Renderer, ref innerRegion);

                SDL_SetRenderDrawColor(Application.Renderer, selectedColor.r, selectedColor.g, selectedColor.b, selectedColor.a);
                SDL_RenderFillRect(Application.Renderer, ref selectedRegion);
            }
            else
            {
                SDL_SetRenderDrawColor(Application.Renderer, borderColor.r, borderColor.g, borderColor.b, borderColor.a);
                SDL_RenderFillRect(Application.Renderer, ref borderRegion);

                SDL_SetRenderDrawColor(Application.Renderer, backColor.r, backColor.g, backColor.b, backColor.a);
                SDL_RenderFillRect(Application.Renderer, ref innerRegion);
            }
        }

        public bool MouseHover()
        {
            if (Inputs.MouseMotionX > borderRegion.x && Inputs.MouseMotionX < (borderRegion.x + borderRegion.w) &&        // Check if the mouse is in the region on the X axis.
                Inputs.MouseMotionY > borderRegion.y && Inputs.MouseMotionY < (borderRegion.y + borderRegion.h))          // Check if the mouse is in the region on the Y axis.
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

        private void MouseHoverAnimation(SDL_Color hoverColor)
        {
            if (MouseHover())
            {
                CreateBox(hoverColor, backColor, selectedColor);
            }
            else
            {
                CreateBox(borderColor, backColor, selectedColor);
            }
        }
    }
}
