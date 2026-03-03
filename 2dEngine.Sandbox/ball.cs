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
        if (Position.X <= Radius || Position.X >= 800 - Radius) Velocity.X *= -1;
        if (Position.Y <= Radius || Position.Y >= 450 - Radius) Velocity.Y *= -1;
    }
    public override void Draw()
    {
        Raylib.DrawCircleV(Position, Radius, Color);
    }
    public override void CheckCollision(GameObject other)
    {
        if (other is Ball otherBall)
        {
            if (this == otherBall) return;
            float distance = Vector2.Distance(this.Position, otherBall.Position);
            if (distance < (this.Radius + otherBall.Radius))
            {
                Vector2 temp = this.Velocity;
                this.Velocity = otherBall.Velocity;
                otherBall.Velocity = temp;
                this.Position += this.Velocity * 0.01f;
                otherBall.Position += otherBall.Velocity * 0.01f;
            }
        }
    }
}