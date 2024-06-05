namespace Solver.Geometry;

public record struct Vector2(int X, int Y)
{
  public static Vector2 operator +(Vector2 v1, Vector2 v2) => Add(v1, v2);

  public static Vector2 operator -(Vector2 v1, Vector2 v2) => Subtract(v1, v2);

  public static Vector2 Add(Vector2 left, Vector2 right) =>
    new(left.X + right.X, left.Y + right.Y);

  public static Vector2 Subtract(Vector2 left, Vector2 right) =>
    new(left.X - right.X, left.Y - right.Y);
}
