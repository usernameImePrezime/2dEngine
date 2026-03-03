using System;
namespace _2dEngine.Core;
public class Engine
{
    private bool _isRunning;
    private DateTime _lastTime;
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
    protected virtual void Update(double dt) { /* Logika igre */ }
    protected virtual void Render() { /* Crtanje */ }
}