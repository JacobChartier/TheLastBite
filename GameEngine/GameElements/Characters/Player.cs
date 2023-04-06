using GameEngine.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SDL2.SDL;

namespace GameEngine.GameElements.Characters
{
    public class Player
    {
        public int health { get; private set; }
        public int collectible { get; private set; }
        public int positionX = 0, positionY = 0, velocityX = 0, velocityY = 0;
        public int width { get; private set; } 
        public int height { get; private set; }
        public int speed = 5;

        public const int VELOCITY = 5;

        public Player(int health, int positionX, int positionY, int width, int height)
        {
            this.health = health;
            this.positionX = positionX;
            this.positionY = positionY;
            this.width = width;
            this.height = height;
        }

        public void HandleInputs(SDL_Event events)
        {
            if (events.type == SDL_EventType.SDL_KEYDOWN && events.key.repeat == 0)
            {
                switch (events.key.keysym.sym)
                {
                    case SDL_Keycode.SDLK_w:
                        velocityY -= VELOCITY;
                        break;
                    case SDL_Keycode.SDLK_s:
                        velocityY += VELOCITY;
                        break;
                    case SDL_Keycode.SDLK_a:
                        velocityX -= VELOCITY;
                        break;
                    case SDL_Keycode.SDLK_d:
                        velocityX += VELOCITY;
                        break;
                }
            }

            else if (events.type == SDL_EventType.SDL_KEYUP && events.key.repeat == 0)
            {
                switch (events.key.keysym.sym)
                {
                    case SDL_Keycode.SDLK_w:
                        velocityY += VELOCITY;
                        break;
                    case SDL_Keycode.SDLK_s:
                        velocityY -= VELOCITY;
                        break;
                    case SDL_Keycode.SDLK_a:
                        velocityX += VELOCITY;
                        break;
                    case SDL_Keycode.SDLK_d:
                        velocityX -= VELOCITY;
                        break;
                }
            }
        }

        private void Move()
        {
            positionX += velocityX;

            if ((positionX < 0) || (positionX + width > Application.WINDOW_WIDTH))
            {
                positionX -= velocityX;
            }

            positionY += velocityY;

            if ((positionY < 0) || (positionY + height > Application.WINDOW_HEIGHT))
            {
                positionY -= velocityY;
            }
        }

        public void Update()
        {
            Move();

            SDL_Rect player = new SDL_Rect { x = positionX, y = positionY, w = width, h = height };

            SDL_SetRenderDrawColor(Application.Renderer, 255, 0, 0, 255);
            SDL_RenderDrawRect(Application.Renderer, ref player);
        }
    }
}
