using static SDL2.SDL;

namespace GameEngine
{
    public class Events
    {
        public delegate void KeySymbleDelegate(SDL_Keysym keysym);

        public static event KeySymbleDelegate? KeyPressedEvent;
        public static event KeySymbleDelegate? KeyReleasedEvent;

        public static void Handler()
        {
            while (SDL_PollEvent(out SDL_Event events) == 1)
            {
                switch (events.type)
                {
                    case SDL_EventType.SDL_QUIT:
                        SDL_Quit();
                        Environment.Exit(0);
                        break;

                    case SDL_EventType.SDL_KEYDOWN:
                        KeyPressedEvent?.Invoke(events.key.keysym); 
                        break;

                    case SDL_EventType.SDL_KEYUP:
                        KeyPressedEvent?.Invoke(events.key.keysym);
                        break;

                    default:
                        break;
                }
            }
        }

        public static void OnKeyPressed(SDL_Keysym keysym)
        {
            if (keysym.scancode == SDL_Scancode.SDL_SCANCODE_A || keysym.scancode == SDL_Scancode.SDL_SCANCODE_LEFT)
            {
                Graphics.rect1.x += -1;
            }
            
            if (keysym.scancode == SDL_Scancode.SDL_SCANCODE_D || keysym.scancode == SDL_Scancode.SDL_SCANCODE_RIGHT)
            {
                Graphics.rect1.x += 1;
            }
        }
    }
}
