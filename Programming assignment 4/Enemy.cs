using Raylib_cs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Programming_assignment_4
{
    internal class Enemy
    {
        // Variables
        public static Vector2 position;
        public static Vector2 velocity;
        public static float radius;
        public static Enemy enemy;
        public Enemy()
        {
            radius = 25;
            Reset();
        }
        // Draws a enemy
        public static void Render()
        {
            Raylib.DrawCircleV(position, radius, Color.RED);
        }
        // Initialize the enemy
        public static void Setup()
        {
            enemy = new Enemy();
        }
        // Moves the enemy
        public static void Move()
        {
            position = position + velocity * Raylib.GetFrameTime();
        }
        public static void Collision()
        {
            // Variables set to the wall
            float leftEdge = - 300;
            float rightEdge = Raylib.GetScreenWidth() + 300;
            float topEdge = - 300;
            float bottomEdge = Raylib.GetScreenHeight() + 300;
            // Bool variuables for ball collision
            bool hitEdgeLeft = position.X <= leftEdge + radius;
            bool hitEdgeRight = position.X >= rightEdge - radius;
            bool hitEdgeTop = position.Y <= topEdge + radius;
            bool hitEdgeBottom = position.Y >= bottomEdge - radius;
            // Checks for collision
            if (hitEdgeLeft || hitEdgeRight)
            {
                velocity.X = -velocity.X;
            }
            if (hitEdgeTop || hitEdgeBottom)
            {
                velocity.Y = -velocity.Y;
            }
        }
        // Gives enemy position
        public static Vector2 GetPosition()
        {
            return position;
        }
        // Gives enemy radius
        public static float GetRadius()
        {
            return radius;
        }
        // Changes enemy direction
        public static void ReflectBallY()
        {
            velocity.Y = -velocity.Y;
        }
        public static void ReflectBallX()
        {
            velocity.X = -velocity.X;
        }
        // Resets ball to centre
        public static void Reset()
        {
            position.X = -25;
            position.Y = -25;
            //Random rng = new Random();
            velocity.X = 300;
            velocity.Y = 150;
        }
        // Main loop method
        public static void Update()
        {
            Move();
            Collision();
            Render();
        }
    }
}

