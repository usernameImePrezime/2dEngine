using Raylib_cs;
using _2dEngine.Core;
using _2dEngine.Sandbox;
using System.Numerics;

Raylib.InitWindow(800, 450, "2dEngine Sandbox");

var game = new MyGame();

game.Run();
Raylib.CloseWindow();
public class MyGame : Engine
{
    public MyGame()
    {
        var rnd = new Random();
        for (int i = 0; i < 50; i++)
        {
            var pos = new Vector2(rnd.Next(50, 750), rnd.Next(50, 400));
            var vel = new Vector2(rnd.Next(-200, 200), rnd.Next(-200, 200));
            _gameObjects.Add(new Ball(pos, vel, 10, Color.Maroon));
        }
    }
    protected override void Update(double dt)
    {
        base.Update(dt);
    }
    protected override void Render()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
        base.Render();
        Raylib.DrawFPS(10, 10);
        Raylib.EndDrawing();
    }
}