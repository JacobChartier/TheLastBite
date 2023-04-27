using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine
{
    public class Timer
    {
        private bool mIsStarted, mIsPaused;
        private uint mStartTicks, mPausedTicks;

        public Timer()
        {
            mIsStarted = false;
            mIsPaused = false;

            mStartTicks = 0;
            mPausedTicks = 0;
        }

        public void Start()
        {
            mIsStarted = true;

            mIsPaused = false;

            mStartTicks = SDL2.SDL.SDL_GetTicks();
            mPausedTicks = 0;
        }

        public void Stop()
        {
            mIsStarted = false;
            mIsPaused = false;

            mStartTicks = 0;
            mPausedTicks = 0;
        }

        public void Pause()
        {
            if (mIsStarted && !mIsPaused)
            {
                mIsPaused = true;

                mPausedTicks = SDL2.SDL.SDL_GetTicks() - mStartTicks;
                mStartTicks = 0;
            }
        }

        public void UnPause()
        {
            if (mIsStarted && mIsPaused)
            {
                mIsPaused = false;

                mStartTicks = SDL2.SDL.SDL_GetTicks() - mPausedTicks;
                mPausedTicks = 0;
            }
        }

        public uint GetTicks()
        {
            uint time = 0;

            if (mIsStarted)
            {
                if (mIsPaused)
                {
                    time = mPausedTicks;
                }
                else
                {
                    time = SDL2.SDL.SDL_GetTicks() - mStartTicks;
                }
            }

            return time;
        }

        public bool IsStarted()
        {
            return mIsStarted;
        }

        public bool IsPaused()
        {
            return mIsPaused;
        }
    }
}
