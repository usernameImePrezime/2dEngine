using System.Collections.Generic;
using System.Numerics;
namespace _2dEngine.Core;

public struct Boundary
{
    public float X, Y, W, H;
    public Boundary(float x, float y, float w, float h) { X = x; Y = y; W = w; H = h; }
    public bool Contains(Vector2 p) => 
        p.X >= X && p.X <= X + W && p.Y >= Y && p.Y <= Y + H;
    public bool Intersects(Boundary range) =>
        !(range.X > X + W || range.X + range.W < X || 
          range.Y > Y + H || range.Y + range.H < Y);
}
public class QuadTree
{
    private const int CAPACITY = 4;
    private Boundary _boundary;
    private List<GameObject> _objects = new List<GameObject>();
    private bool _isDivided = false;
    private QuadTree _nw, _ne, _sw, _se;
    public QuadTree(Boundary boundary) => _boundary = boundary;
    public bool Insert(GameObject obj)
    {
        if (!_boundary.Contains(obj.Position)) return false;
        if (_objects.Count < CAPACITY && !_isDivided)
        {
            _objects.Add(obj);
            return true;
        }
        if (!_isDivided) Subdivide();
        return _nw.Insert(obj) || _ne.Insert(obj) || _sw.Insert(obj) || _se.Insert(obj);
    }
    private void Subdivide()
    {
        float hW = _boundary.W / 2;
        float hH = _boundary.H / 2;
        _nw = new QuadTree(new Boundary(_boundary.X, _boundary.Y, hW, hH));
        _ne = new QuadTree(new Boundary(_boundary.X + hW, _boundary.Y, hW, hH));
        _sw = new QuadTree(new Boundary(_boundary.X, _boundary.Y + hH, hW, hH));
        _se = new QuadTree(new Boundary(_boundary.X + hW, _boundary.Y + hH, hW, hH));
        _isDivided = true;
        foreach (var obj in _objects) { _nw.Insert(obj); _ne.Insert(obj); _sw.Insert(obj); _se.Insert(obj); }
        _objects.Clear();
    }
    public List<GameObject> Query(Boundary range, List<GameObject> found = null)
    {
        found ??= new List<GameObject>();
        if (!_boundary.Intersects(range)) return found;
        foreach (var obj in _objects) if (range.Contains(obj.Position)) found.Add(obj);
        if (_isDivided) { _nw.Query(range, found); _ne.Query(range, found); _sw.Query(range, found); _se.Query(range, found); }
        return found;
    }
}