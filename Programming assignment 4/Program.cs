// Include necessary libraries
using Raylib_cs;
using System.Numerics;

namespace Programming_assignment_4
{
    internal class Program
    {

        // If you need variables in the Program class (outside functions), you must mark them as static
        static string title = "Game Title";
        static int windowWidth = 1750;
        static int windowHeight = 1000;
        static Bullets bullets;
        static Bullet bullet;

        static void Main(string[] args)
        {
            // Create a window to draw to. The arguments define width and height
            Raylib.InitWindow(windowWidth, windowHeight, title);
            // Set the target frames-per-second (FPS)
            Raylib.SetTargetFPS(60);

            // Setup your game. This is a function YOU define.
            Setup();

            // Loop so long as window should not close
            while (!Raylib.WindowShouldClose())
            {
                // Enable drawing to the canvas (window)
                Raylib.BeginDrawing();
                // Clear the canvas with one color
                Raylib.ClearBackground(Color.WHITE);

                // Your game code here. This is a function YOU define.
                Update();

                // Stop drawing to the canvas, begin displaying the frame
                Raylib.EndDrawing();
            }
            // Close the window
            Raylib.CloseWindow();
        }

        static void Setup()
        {
            // Your one-time setup code here

            // Parker
            Enemy.Setup();

            //Xander
            bullets = new Bullets();
            bullet = new Bullet(0, 100);
        }

        static void Update()
        {
            // Your game code run each frame here

            // Parker
            Enemy.Update();

            //Cyven
            Player.Move(windowWidth, windowHeight);

            //Xander
            bullets.Update();
            bullets.Draw();
        }
    }
}