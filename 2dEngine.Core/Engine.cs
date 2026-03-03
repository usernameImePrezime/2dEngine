using System;
using System.Collections.Generic;
using System.Numerics;
namespace _2dEngine.Core;

public class Engine
{
    protected bool _isRunning;
    private DateTime _lastTime;
    protected List<GameObject> _gameObjects = new List<GameObject>();
    public void Run()
    {
        _isRunning = true;
        _lastTime = DateTime.Now;
        while (_isRunning)
        {
            TimeSpan elapsed = DateTime.Now - _lastTime;
            double dt = elapsed.TotalSeconds;
            _lastTime = DateTime.Now;
            Update(dt);
            Render();
        }
    }
    protected virtual void Update(double dt)
    {
        Boundary screen = new Boundary(0, 0, 800, 450);
        QuadTree qtree = new QuadTree(screen);
        foreach (var obj in _gameObjects)
        {
            obj.Update(dt);
            qtree.Insert(obj);
        }
        foreach (var obj in _gameObjects)
        {
            var range = new Boundary(obj.Position.X - 15, obj.Position.Y - 15, 30, 30);
            var neighbors = qtree.Query(range);
            foreach (var neighbor in neighbors)
            {
                if (obj != neighbor) obj.CheckCollision(neighbor);
            }
        }
    }
    protected virtual void Render()
    {
        foreach (var obj in _gameObjects) obj.Draw();
    }
}