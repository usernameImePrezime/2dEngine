using System.Collections.Generic;
using System.Numerics;
namespace _2dEngine.Core
{
    public struct Boundary
    {
        public float X, Y, W, H;
        public Boundary(float x, float y, float w, float h) { X = x; Y = y; W = w; H = h; }
        public bool Contains(Vector2 p) => p.X >= X && p.X <= X + W && p.Y >= Y && p.Y <= Y + H;
    }
    public class QuadTree
    {
        private const int CAPACITY = 4;
        private Boundary _boundary;
        private List<GameObject> _objects = new List<GameObject>();
        private bool _isDivided = false;
        private QuadTree _nw, _ne, _sw, _se;
        public QuadTree(Boundary boundary)
        {
            _boundary = boundary;
        }
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
            float halfW = _boundary.W / 2;
            float halfH = _boundary.H / 2;
            _nw = new QuadTree(new Boundary(_boundary.X, _boundary.Y, halfW, halfH));
            _ne = new QuadTree(new Boundary(_boundary.X + halfW, _boundary.Y, halfW, halfH));
            _sw = new QuadTree(new Boundary(_boundary.X, _boundary.Y + halfH, halfW, halfH));
            _se = new QuadTree(new Boundary(_boundary.X + halfW, _boundary.Y + halfH, halfW, halfH));
            _isDivided = true;
            foreach (var obj in _objects)
            {
                _nw.Insert(obj); _ne.Insert(obj); _sw.Insert(obj); _se.Insert(obj);
            }
            _objects.Clear();
        }
    }
}