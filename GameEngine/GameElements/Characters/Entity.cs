
using GameEngine.UserInterface;
using System.Runtime.CompilerServices;

namespace GameEngine.GameElements.Characters
{

    public struct Hitbox
    {
        public float x, y, width, height;
    }

    public enum EntityState
    {
        Alive,
        Dead
    }

    public abstract class Entity : Math
    {
        public Vector2D position, velocity, acceleration, velocityGoal;
        public Hitbox hitbox;

        public EntityState entityState;

        public string name = "Unknow";
        public bool isOnGround;
        public int health;

        public const float GRAVITY = 0.50f, DELTA_TIME = (1.0f / 60.0f);

        public Entity(string name, int health, Vector2D position)
        {
            this.name = name;
            this.health = health;
            this.position = position;
        }
        
        public float LinearInterpolation(float current, float goal, float speed)
        {
            float difference = goal - current;

            if (difference > DELTA_TIME * speed)
            {
                return current + (DELTA_TIME * speed);
            }

            if (difference < -(DELTA_TIME * speed))
            {
                return current - (DELTA_TIME * speed);
            }

            return goal;
        }

        public virtual void MoveX(float movement)
        {
            velocityGoal.x += movement;
            position.x += velocityGoal.x;
        }

        public virtual void MoveY(float movement)
        {
            velocity.y += movement;
            position.y += velocity.y * DELTA_TIME;
        }
    }
}
