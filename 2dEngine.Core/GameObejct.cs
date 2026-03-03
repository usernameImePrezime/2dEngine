using System.Numerics;
namespace _2dEngine.Core;

public abstract class GameObject
{
    public Vector2 Position;
    public Vector2 Velocity;
    public GameObject(Vector2 startPosition)
    {
        Position = startPosition;
    }
    public virtual void Update(double dt)
    {
        Position += Velocity * (float)dt;
    }
    public abstract void Draw();
    public virtual void CheckCollision(GameObject other) { }
}