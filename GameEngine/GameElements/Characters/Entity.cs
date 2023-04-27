
using GameEngine.UserInterface;
using System.Runtime.CompilerServices;

namespace GameEngine.GameElements.Characters
{
    public struct Vector2D
    {
        public float x, y;
    }

    public struct Hitbox
    {
        public float x, y, width, height;
    }

    public enum EntityState
    {
        Alive,
        Dead
    }

    public abstract class Entity
    {
        public Graphics gfx = new Graphics();
        public Vector2D position, velocity, acceleration;
        public Hitbox hitbox;

        public EntityState entityState;

        public string name = "Unknow";
        public int health;

        private const float gravity = 5;

        public Entity(string name, int health, Vector2D position)
        {
            this.name = name;
            this.health = health;
            this.position = position;
        }

        public virtual void MoveX(float movement)
        {
            velocity.x += movement;
            position.x += velocity.x;
        }

        public virtual void MoveY(float movement)
        {
            velocity.y += movement;
            position.y += velocity.y + gravity * gfx.deltaTime;
        }
    }
}
