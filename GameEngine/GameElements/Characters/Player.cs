using GameEngine.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static SDL2.SDL;

namespace GameEngine.GameElements.Characters
{
    public class Player
    {
        public int health { get; private set; }
        public int collectible { get; private set; }
        public int x = 0, y = 0, velX = 0, velY = 0;
        public int width { get; private set; }
        public int height { get; private set; }

        public bool jumping = false;
        public bool falling = true;
        public int jump = 0;
        public int jumpHeight = 10;
        public bool stopJumping = true;

        public bool collider = false;

        public const int VELOCITY = 5;

        public SDL_Rect hitbox, platform = new SDL_Rect { };

        public Player(int health, int x, int y, int width, int height)
        {
            this.health = health;
            this.x = x;
            this.y = y;
            this.width = width;
            this.height = height;
        }

        public void HandleInputs(SDL_Event events)
        {
            if (events.type == SDL_EventType.SDL_KEYDOWN && events.key.repeat == 0)
            {
                switch (events.key.keysym.sym)
                {
                    //case SDL_Keycode.SDLK_w:
                    //    velY -= VELOCITY;
                    //    break;
                    //case SDL_Keycode.SDLK_s:
                    //    velY += VELOCITY;
                    //    break;
                    case SDL_Keycode.SDLK_a:
                        velX -= VELOCITY;
                        break;
                    case SDL_Keycode.SDLK_d:
                        velX += VELOCITY;
                        break;

                    case SDL_Keycode.SDLK_SPACE:
                        Jump();
                        break;
                }
            }
            else if (events.type == SDL_EventType.SDL_KEYUP && events.key.repeat == 0)
            {
                switch (events.key.keysym.sym)
                {
                    //case SDL_Keycode.SDLK_w:
                    //    velY += VELOCITY;
                    //    break;
                    //case SDL_Keycode.SDLK_s:
                    //    velY -= VELOCITY;
                    //break;
                    case SDL_Keycode.SDLK_a:
                        velX += VELOCITY;
                        break;
                    case SDL_Keycode.SDLK_d:
                        velX -= VELOCITY;
                        break;

                        //case SDL_Keycode.SDLK_SPACE:
                        //    Jump();
                        //    break;
                }
            }
        }

        public void Update()
        {
            SDL_Rect hitbox = new SDL_Rect { x = x, y = y, w = width, h = height };
            SDL_Rect player1 = new SDL_Rect { x = x + 5, y = y + 5, w = width - 10, h = height - 10 };

            SDL_SetRenderDrawColor(Application.Renderer, 255, 0, 0, 255);
            SDL_RenderDrawRect(Application.Renderer, ref hitbox);
            SDL_RenderDrawRect(Application.Renderer, ref player1);
        }

        public void Move()
        {
            x += velX;

            if ((x < 0) || (x + width > Application.WINDOW_WIDTH) || collider)
            {
                x -= velX;
            }

            y += velY;

            if ((y < 0) || (y + height > Application.WINDOW_HEIGHT) || collider)
            {
                y -= velY;
            }

            if (!collider)
            {
                y += velY;
            }
        }

        public bool CheckCollision(SDL_Rect rect)
        {
            int playerLeft = x, rectLeft = rect.x;
            int playerRight = x + width, rectRight = rect.x + rect.w;
            int playerTop = y, rectTop = rect.y;
            int playerBottom = y + height, rectBottom = rect.y + rect.h;

            platform.x = rect.x;
            platform.y = rect.y;
            platform.w = rect.w;
            platform.h = rect.h;

            if (playerBottom <= rectTop)
            {
                return true;
            }

            if (playerTop >= rectBottom)
            {
                return true;
            }

            if (playerRight <= rectLeft)
            {
                return true;
            }

            if (playerLeft >= rectRight)
            {
                return true;
            }

            return false;
        }

        public void Jump()
        {
            while (jumping)
            {
                if (jump <= jumpHeight && stopJumping)
                {
                    Log.Message($"{jump}");
                    jump++;
                    velY -= VELOCITY;
                }
                else if (jump >= jumpHeight && stopJumping)
                {
                    stopJumping = false;
                    jump--;
                    velY += VELOCITY;
                }
            }
        }
    }
}
