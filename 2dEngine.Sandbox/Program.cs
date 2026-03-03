using Raylib_cs;
using _2dEngine.Core;
Raylib.InitWindow(800, 450, "2dEngine Sandbox");
var game = new MyGame();
game.Run();

Raylib.CloseWindow();
public class MyGame : Engine
{
    protected override void Update(double dt)
    {
        // Logika kretanja
    }

    protected override void Render()
    {
        Raylib.BeginDrawing();
        Raylib.ClearBackground(Color.Black); 
        Raylib.DrawText("2dEngine Faza 1: Game Loop Works!", 10, 10, 20, Color.White);
        Raylib.EndDrawing();
    }
}