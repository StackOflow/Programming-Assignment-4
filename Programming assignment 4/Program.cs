// Include necessary libraries
using Raylib_cs;
using System.Numerics;

namespace Programming_assignment_4
{
    internal class Program
    {
        // If you need variables in the Program class (outside functions), you must mark them as static
        static string title = "Game Title";

        static void Main(string[] args)
        {
            // Create a window to draw to. The arguments define width and height
            Raylib.InitWindow(800, 600, title);
            // Set the target frames-per-second (FPS)
            Raylib.SetTargetFPS(60);

            // Setup your game. This is a function YOU define.
            Setup();
            static void Main(string[] args)
            {
                // Create a window to draw to. The arguments define width and height
                Raylib.InitWindow(800, 600, title);
                // Set the target frames-per-second (FPS)
                Raylib.SetTargetFPS(60);

                while (!Raylib.WindowShouldClose())
                {
                    // Your game code run each frame here

                    // Parker
                    Enemy.Update();

                    // Check collisions for the enemy every frame within its Update method
                    // This is to ensure collisions are checked with each frame update
                    // You may need to replace these values with your actual enemy position, radius, and velocity
                    Enemy.CheckEnemyCollisionCollision();

                    Raylib.BeginDrawing();
                    Raylib.ClearBackground(Color.WHITE);

                   



                    Raylib.EndDrawing();
                }

                Raylib.CloseWindow();
            }

            static void Setup()
            {
                // Your one-time setup code here

                // Parker
                Enemy.Setup();
            }

            static void Update()
            {
                // Your game code run each frame here

                // Parker
                Enemy.Update();
            }
        }
    }
}