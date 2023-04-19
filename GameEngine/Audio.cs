using static SDL2.SDL;
using static SDL2.SDL_mixer;

namespace GameEngine
{
    internal class Audio
    {
        public static void Play(IntPtr music)
        {
            Mix_PlayMusic(music, 1);
        }
        
        public static void PlaySound(IntPtr sound)
        {
            Mix_PlayMusic(sound, 1);
        }

        public static void SetVolume(int volume)
        {
            Mix_Volume(2, volume);
        }
    }
}
