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
        foreach (var obj in _gameObjects)
        {
            obj.Update(dt);
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