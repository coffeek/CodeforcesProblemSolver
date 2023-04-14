using System.Linq;
using static System.Math;

namespace Solver.Geometry;

public static class Geometry
{
  public static int Dot(Vector2 v1, Vector2 v2) => v1.X * v2.X + v1.Y * v2.Y;

  public static int Cross(Vector2 v1, Vector2 v2) => v1.X * v2.Y - v2.X * v1.Y;

  public static bool Intersect(Segment2 a, Segment2 b) =>
    Intersect(a.A, a.B, b.A, b.B);

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
    return p.X <= Max(a.X, b.X) && p.X >= Min(a.X, b.X) &&
           p.Y <= Max(a.Y, b.Y) && p.Y >= Min(a.Y, b.Y);
  }

  public static bool Intersect(Quad q1, Quad q2)
  {
    return q1.Points().Any(q2.ContainsPoint) ||
           q2.Points().Any(q1.ContainsPoint) ||
           q1.Edges().Any(e1 => q2.Edges().Any(e2 => Intersect(e1, e2)));
  }
}
