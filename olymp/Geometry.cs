using System.Collections.Generic;
using System.Linq;
using static System.Math;
using static Olymp.Geometry;

namespace Olymp
{
  public struct Vector2
  {
    public int x;
    public int y;

    public static Vector2 operator +(Vector2 v1, Vector2 v2) =>
      new Vector2(v1.x + v2.x, v1.y + v2.y);

    public static Vector2 operator -(Vector2 v1, Vector2 v2) =>
      new Vector2(v1.x - v2.x, v1.y - v2.y);

    public Vector2(int x, int y)
    {
      this.x = x;
      this.y = y;
    }
  }

  public class Segment2
  {
    public Vector2 a;
    public Vector2 b;
    public Segment2(Vector2 a, Vector2 b)
    {
      this.a = a;
      this.b = b;
    }
  }

  public class Quad
  {
    public Vector2[] v;

    public bool ContainsPoint(Vector2 p) =>
      Enumerable.Range(0, 4).All(i => Cross(v[(i + 1) % 4] - v[i], p - v[i]) <= 0);

    public IEnumerable<Vector2> Points() => v;

    public IEnumerable<Segment2> Edjes() =>
      Enumerable.Range(0, 4).Select(i => new Segment2(v[i], v[(i + 1) % 4]));

    public Quad(Vector2 a, Vector2 b, Vector2 c, Vector2 d) =>
      v = new[] { a, b, c, d };
  }

  public static class Geometry
  {
    public static int Dot(Vector2 v1, Vector2 v2) => v1.x * v2.x + v1.y * v2.y;

    public static int Cross(Vector2 v1, Vector2 v2) => v1.x * v2.y - v2.x * v1.y;

    public static bool Intersect(Segment2 a, Segment2 b) =>
      Intersect(a.a, a.b, b.a, b.b);

    public static bool Intersect(Vector2 a, Vector2 b, Vector2 c, Vector2 d)
    {
      var ca = c - a;
      var cd = c - d;
      var cb = c - b;
      var ac = a - c;
      var ab = a - b;
      var ad = a - d;
      var d1 = Cross(cd, ca);
      var d2 = Cross(cd, cb);
      var d3 = Cross(ab, ac);
      var d4 = Cross(ab, ad);
      return (d1 * d2 < 0 && d3 * d4 < 0) ||
        d1 == 0 && PointOnEdge(a, c, d) ||
        d2 == 0 && PointOnEdge(b, c, d) ||
        d3 == 0 && PointOnEdge(c, a, b) ||
        d4 == 0 && PointOnEdge(d, a, b);
    }

    public static bool PointOnEdge(Vector2 p, Vector2 a, Vector2 b)
    {
      return p.x <= Max(a.x, b.x) && p.x >= Min(a.x, b.x) &&
             p.y <= Max(a.y, b.y) && p.y >= Min(a.y, b.y);
    }

    public static bool Intersect(Quad q1, Quad q2)
    {
      return q1.Points().Any(q2.ContainsPoint) ||
             q2.Points().Any(q1.ContainsPoint) ||
             q1.Edjes().Any(e1 => q2.Edjes().Any(e2 => Intersect(e1, e2)));
    }
  }
}
