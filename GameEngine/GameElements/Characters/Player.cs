using GameEngine.UserInterface;
using GameEngine.UserInterface.UI;
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
    public sealed class Player : Entity
    {
        public int collectible { get; private set; }
        public int width { get; private set; }
        public int height { get; private set; }

        public bool collider = false;
        public bool isJumping = false;

        public SDL_Rect hitbox, platform = new SDL_Rect { };

        public Player(string name, int health, Vector2D position, int width, int height) : base(name, health, position)
        { 
            base.name = name;
            base.health = health;
            base.position.x = position.x;
            base.position.y = position.y;
            this.width = width;
            this.height = height;

            acceleration.x = 5;
            acceleration.y = 20;
        }

        public void HandleInputs(SDL_Event events)
        {
            if (events.type == SDL_EventType.SDL_KEYDOWN && events.key.repeat == 0)
            {
                switch (events.key.keysym.sym)
                {
                    case SDL_Keycode.SDLK_ESCAPE:   // Pressed ESCAPE : Show the PAUSE menu
                        Graphics.state = Graphics.GameState.Pause;
                        break;

                    case SDL_Keycode.SDLK_F1:       // Pressed F1 : Show the DEBUG menu
                        Graphics.debugMode = !Graphics.debugMode;
                        break;

                    case SDL_Keycode.SDLK_a:        // Pressed A : Move the player to the left on the X axis
                        MoveX(-acceleration.x);
                        break;

                    case SDL_Keycode.SDLK_d:        // Pressed D : Move the player to the right on the X axis
                        MoveX(acceleration.x);
                        break;

                    case SDL_Keycode.SDLK_SPACE:    // Pressed SPACE : Move the player up on the Y axis
                        if (isOnGround)
                        {
                            MoveY(-acceleration.y);
                            isOnGround = false;
                        }
                        break;
                }
            }
            else if (events.type == SDL_EventType.SDL_KEYUP && events.key.repeat == 0)
            {
                switch (events.key.keysym.sym)
                {
                    case SDL_Keycode.SDLK_a:        // Released A : Stop the player's velocity goal movement
                        velocityGoal.x += acceleration.x;
                        break;

                    case SDL_Keycode.SDLK_d:        // Released D : Stop the player's velocity goal movement
                        velocityGoal.x -= acceleration.x;
                        break;
                }
            }
        }

        public void Update()
        {
            // Interpolate the movement
            velocity.x = LinearInterpolation(velocity.x, velocityGoal.x, 10);
            //velocity.y = LinearInterpolation(velocity.y, velocityGoal.y, 10);

            // Apply gravity to the Y axis
            velocity.y += GRAVITY;

            // Make the player move
            position.x += velocity.x;
            position.y += velocity.y;

            if (position.y + height >= Application.WINDOW_HEIGHT)
            {
                position.y = Application.WINDOW_HEIGHT - height;
                velocity.y = 0;

                isOnGround = true;
            }

            SDL_Rect hitbox = new SDL_Rect { x = (int)position.x, y = (int)position.y, w = width, h = height };
            SDL_Rect player1 = new SDL_Rect { x = (int)position.x + 5, y = (int)position.y + 5, w = width - 10, h = height - 10 };

            SDL_SetRenderDrawColor(Application.Renderer, 255, 0, 0, 255);
            SDL_RenderDrawRect(Application.Renderer, ref hitbox);
            SDL_RenderDrawRect(Application.Renderer, ref player1);
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
