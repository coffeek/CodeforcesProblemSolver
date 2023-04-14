using System.Collections.Generic;
using System.Linq;

namespace Solver.Geometry;

public class Quad
{
  public Vector2[] V;

  public bool ContainsPoint(Vector2 p) =>
    Enumerable.Range(0, 4).All(i => Geometry.Cross(V[(i + 1) % 4] - V[i], p - V[i]) <= 0);

  public IEnumerable<Vector2> Points() => V;

  public IEnumerable<Segment2> Edges() =>
    Enumerable.Range(0, 4).Select(i => new Segment2(V[i], V[(i + 1) % 4]));

  public Quad(Vector2 a, Vector2 b, Vector2 c, Vector2 d) =>
    V = new[] { a, b, c, d };
}
