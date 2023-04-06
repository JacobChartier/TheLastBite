using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameElements.Characters
{
    internal class NPC
    {
        public enum Type
        {
            NonPlayableCharacter,
            Ennemy
        }

        public Type type { get; private set; }
        public int health { get; set; }
        public int positionX = 0, positionY = 0, velocityX = 0, velocityY = 0;

        public NPC(Type type, int health)
        {
        }
    }
}
