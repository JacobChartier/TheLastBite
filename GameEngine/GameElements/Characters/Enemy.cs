using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameEngine.GameElements.Characters
{
    public enum Type
    {
        NonPlayableCharacter,
        Ennemy
    }

    internal class Enemy : Entity
    {
        public Type type { get; private set; }
        public int positionX = 0, positionY = 0, velocityX = 0, velocityY = 0;

        public Enemy(string name, int health, Vector2D position, Type type) : base(name, health, position)
        {
        }
    }
}
