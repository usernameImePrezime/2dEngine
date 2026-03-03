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
            double deltaTime = elapsed.TotalSeconds;
            _lastTime = DateTime.Now;

            Update(deltaTime);
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
        for (int i = 0; i < _gameObjects.Count; i++)
        {
            for (int j = i + 1; j < _gameObjects.Count; j++)
            {
                _gameObjects[i].CheckCollision(_gameObjects[j]);
            }
        }
    }
    protected virtual void Render() 
    {
        foreach (var obj in _gameObjects)
        {
            obj.Draw();
        }
    }
}