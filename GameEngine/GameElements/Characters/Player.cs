using GameEngine.UserInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static SDL2.SDL;

namespace GameEngine.GameElements.Characters
{
    public struct playerBase
    {
        public int x;
        public int y;
    }

    public sealed class Player : Entity
    {

        public int collectible { get; private set; }
        public int width { get; private set; }
        public int height { get; private set; }

        public bool collider = false;
        public bool isJumping = false;
        

        public const int VELOCITY = 5;
        public const int GRAVITY = 3;

        public SDL_Rect hitbox, platform = new SDL_Rect { };

        public Player(string name, int health, Vector2D position, int width, int height) : base(name, health, position)
        {
            base.name = name;
            base.health = health;
            base.position.x = position.x;
            base.position.y = position.y;
            this.width = width;
            this.height = height;

            acceleration.x = 2;
            acceleration.y = 35;
        }

        public void HandleInputs(SDL_Event events)
        {
            if (events.type == SDL_EventType.SDL_KEYDOWN && events.key.repeat == 0)
            {
                switch (events.key.keysym.sym)
                {
                    case SDL_Keycode.SDLK_a:
                        MoveX(-acceleration.x);
                        break;
                    case SDL_Keycode.SDLK_d:
                        MoveX(acceleration.x);
                        break;

                    case SDL_Keycode.SDLK_SPACE:
                        MoveY(-acceleration.y);
                        break;
                }
            }
            else if (events.type == SDL_EventType.SDL_KEYUP && events.key.repeat == 0)
            {
                switch (events.key.keysym.sym)
                {
                    case SDL_Keycode.SDLK_a:
                        MoveX(acceleration.x);
                        break;
                    case SDL_Keycode.SDLK_d:
                        MoveX(-acceleration.x);
                        break;
                }
            }
        }

        public void Update()
        {
            Move();

            SDL_Rect hitbox = new SDL_Rect { x = (int)position.x, y = (int)position.y, w = width, h = height };
            SDL_Rect player1 = new SDL_Rect { x = (int)position.x + 5, y = (int)position.y + 5, w = width - 10, h = height - 10 };

            SDL_SetRenderDrawColor(Application.Renderer, 255, 0, 0, 255);
            SDL_RenderDrawRect(Application.Renderer, ref hitbox);
            SDL_RenderDrawRect(Application.Renderer, ref player1);
        }

        public void Move()
        {
            position.x += velocity.x;
            position.y += velocity.y * gfx.deltaTime;

            velocity.y = velocity.y + GRAVITY * gfx.deltaTime;

            if (/*(position.y < 0) || */(position.y + height >= Application.WINDOW_HEIGHT) /*|| collider*/)
            {
                position.y = Application.WINDOW_HEIGHT - height;
                velocity.y = 0;
            }
        }

        public bool CheckCollision(SDL_Rect rect)
        {
            int playerLeft = (int)position.x, rectLeft = rect.x;
            int playerRight = (int)position.x + width, rectRight = rect.x + rect.w;
            int playerTop = (int)position.y, rectTop = rect.y;
            int playerBottom = (int)position.y + height, rectBottom = rect.y + rect.h;

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
    }
}
