using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Programming_assignment_4
{
    public class Collisions
    {
        private static float leftEdge = -300;
        private static float rightEdge = Raylib.GetScreenWidth() + 300;
        private static float topEdge = -300;
        private static float bottomEdge = Raylib.GetScreenHeight() + 300;

        public static bool CheckEnemyCollision(Vector2 position, float radius, Vector2 velocity)
        {
            // Collision detection for the enemy
            bool collided = false;

            if (position.X - radius <= leftEdge || position.X + radius >= rightEdge)
            {
                velocity.X = -velocity.X;
                collided = true;
            }

            if (position.Y - radius <= topEdge || position.Y + radius >= bottomEdge)
            {
                velocity.Y = -velocity.Y;
                collided = true;
            }

            return collided;
        }
    }
}


