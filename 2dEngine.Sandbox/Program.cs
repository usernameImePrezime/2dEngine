using Raylib_cs;
using System.Numerics;
using _2dEngine.Core;
using _2dEngine.Sandbox;
Raylib.InitWindow(800, 450, "2dEngine | QuadTree Optimization");
Raylib.SetTargetFPS(60);
var game = new MyGame();
game.Run();
Raylib.CloseWindow();

public class MyGame : Engine
{
    public MyGame()
    {
        var rnd = new Random();
        for (int i = 0; i < 100; i++) // Sada možeš slobodno staviti i 200+
        {
            var pos = new Vector2(rnd.Next(50, 750), rnd.Next(50, 400));
            var vel = new Vector2(rnd.Next(-150, 150), rnd.Next(-150, 150));
            _gameObjects.Add(new Ball(pos, vel, 8, Color.Maroon));
        }
    }
    protected override void Update(double dt) => base.Update(dt);
    protected override void Render()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black);
        base.Render();
        Raylib.DrawFPS(10, 10);
        Raylib.EndDrawing();
    }
}