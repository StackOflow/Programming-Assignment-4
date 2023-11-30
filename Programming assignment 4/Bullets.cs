using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Numerics;
using System.Threading.Tasks;
using Raylib_cs;


public class Bullets
{
    private List<Bullet> bullets;

    public Bullets()
    {
        bullets = new List<Bullet>();
    }

    public void Update()
    {
        // Move existing bullets
        foreach (Bullet bullet in bullets)
        {
            bullet.Update();
        }

        // Generate new bullets
        if (Raylib.GetRandomValue(0, 100) < 5)
        {
            float startX = Raylib.GetScreenWidth() + 10; // Start off-screen
            float startY = Raylib.GetRandomValue(0, Raylib.GetScreenHeight());

            Bullet newBullet = new Bullet(startX, startY);
            bullets.Add(newBullet);
        }

        // Remove bullets that are off-screen
        bullets.RemoveAll(bullet => bullet.Position.X < 0);
    }

    public void Draw()
    {
        foreach (Bullet bullet in bullets)
        {
            bullet.Draw();
        }
    }
}

public class Bullet
{
    public Vector2 Position;
    private float speed;

    public Bullet(float startX, float startY)
    {
        Position = new Vector2(startX, startY);
        speed = 2.5f; // Adjust the speed as needed
    }

    public void Update()
    {
        // Move the bullet
        Position.X -= speed;
    }

    public void Draw()
    {
        Raylib.DrawLine((int)Position.X, (int)Position.Y, (int)Position.X - 5, (int)Position.Y, Color.RED);
        // Adjust the line parameters (color, length, etc.) as needed
    }
}