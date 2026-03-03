using System.Numerics;
using Raylib_cs;
using _2dEngine.Core;

namespace _2dEngine.Sandbox;
public class Ball : GameObject
{
    public float Radius;
    public Color Color;
    public Ball(Vector2 pos, Vector2 vel, float radius, Color color) : base(pos)
    {
        Velocity = vel;
        Radius = radius;
        Color = color;
    }
    public override void Update(double dt)
    {
        base.Update(dt); // Position += Velocity * dt
        // 800x450
        if (Position.X <= Radius || Position.X >= 800 - Radius) Velocity.X *= -1;
        if (Position.Y <= Radius || Position.Y >= 450 - Radius) Velocity.Y *= -1;
    }
    public override void Draw()
    {
        Raylib.DrawCircleV(Position, Radius, Color);
    }
}