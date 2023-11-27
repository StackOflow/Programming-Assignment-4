// Include necessary libraries
using Raylib_cs;
using System.Numerics;

namespace Programming_assignment_4
{
    internal class Player
    {
        //mouse
        static int mouseX = 0;
        static int mouseY = 0;
        static int mousePlayerDistance = 0;


        //player
        static float playerPosX = 500;
        static float playerPosY = 500;
        static float playerTargetAngle = 6;
        static float playerAngle = 0;
        static float playerSpeed = 25;

        static float playerVelX = 0;
        static float playerVelY = 0;
        static float playerPullX = 0;
        static float playerPullY = 0;


        static float playerMainRadius = 10;

        //obj 1

        public static void Move(int windowWidth, int windowHeight)
        {
            playerPosX = playerPosX + playerVelX;
            playerPosY = playerPosY + playerVelY;

            // movement when holding left click
            if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_BUTTON_LEFT))
            {
                mouseX = Raylib.GetMouseX();
                mouseY = Raylib.GetMouseY();

                mousePlayerDistance = (int)Math.Sqrt(((mouseX - playerPosX) * (mouseX - playerPosX)) + ((mouseY - playerPosY) * (mouseY - playerPosY)));
                playerTargetAngle = (float)Math.Atan2((mouseY - playerPosY), mouseX - playerPosX) + (float)Math.PI / 2;
                if (playerTargetAngle < 0)
                {
                    playerTargetAngle = playerTargetAngle + 6;
                }
                playerAngle = playerTargetAngle;
                playerSpeed = 0.01f * mousePlayerDistance;



                playerVelY = playerVelY - (float)Math.Cos(playerAngle) * playerSpeed / 15;
                playerVelX = playerVelX + (float)Math.Sin(playerAngle) * playerSpeed / 15;

                playerPullX = mouseX - playerPosX;
                playerPullY = mouseY - playerPosY;
                playerVelX = playerVelX + (playerPullX / 300);
                playerVelY = playerVelY + (playerPullY / 300);

                Raylib.DrawLine((int)playerPosX, (int)playerPosY, mouseX, mouseY, Color.RED);

                if (Raylib.IsMouseButtonDown(MouseButton.MOUSE_RIGHT_BUTTON) || Raylib.IsKeyDown(KeyboardKey.KEY_SPACE))
                {
                    Raylib.DrawLine((int)playerPosX, (int)playerPosY, mouseX, mouseY, Color.BLUE);
                    playerVelX = playerVelX + (playerPullX / 100);
                    playerVelY = playerVelY + (playerPullY / 100);
                }

                playerVelX = playerVelX - (playerVelX / 24);
                playerVelY = playerVelY - (playerVelY / 24);
            }

            //keep within walls + speed bounds
            if (playerPosX - playerMainRadius < 0)
            {
                playerPosX = (int)playerMainRadius;
                playerVelX = playerVelX - playerVelX * 2;
                playerVelX = playerVelX - playerVelX / 10;
            }
            if (playerPosX + (int)playerMainRadius > windowWidth)
            {
                playerPosX = windowWidth - (int)playerMainRadius;
                playerVelX = playerVelX - playerVelX * 2;
                playerVelX = playerVelX - playerVelX / 10;
            }
            if (playerPosY - playerMainRadius < 0)
            {
                playerPosY = (int)playerMainRadius;
                playerVelY = playerVelY - playerVelY * 2;
                playerVelY = playerVelY - playerVelY / 10;
            }
            if (playerPosY + (int)playerMainRadius > windowHeight)
            {
                playerPosY = windowHeight - (int)playerMainRadius;
                playerVelY = playerVelY - playerVelY * 2;
                playerVelY = playerVelY - playerVelY / 10;
            }


            if ((int)playerSpeed > 5)
            {
                playerSpeed = 5;
            }
            if ((int)playerSpeed < 0)
            {
                playerSpeed = 0;
            }

            //drag
            playerVelX = playerVelX - (playerVelX / 48);
            playerVelY = playerVelY - (playerVelY / 48);
            playerSpeed = playerSpeed - 0.1f;



            //player draw
            Raylib.DrawCircle((int)playerPosX, (int)playerPosY, playerMainRadius, Color.GOLD);
            Raylib.DrawCircleLines((int)playerPosX, (int)playerPosY, playerMainRadius, Color.BLACK);

            //DEBUG STUFF
            Raylib.DrawText("speed" + playerSpeed.ToString(), 20, 20, 20, Color.BLACK);
            Raylib.DrawText("xpos" + playerPosX.ToString(), 20, 40, 20, Color.BLACK);
            Raylib.DrawText("ypos" + playerPosY.ToString(), 20, 60, 20, Color.BLACK);
            Raylib.DrawText(mouseY.ToString(), 20, 80, 20, Color.BLACK);
            Raylib.DrawText(playerTargetAngle.ToString(), mouseX + 3, mouseY + 3, 10, Color.BLACK);
        }
    }
}