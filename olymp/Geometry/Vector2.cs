namespace Olymp.Geometry;

public struct Vector2
{
  public int X;
  public int Y;

  public static Vector2 operator +(Vector2 v1, Vector2 v2) =>
    new(v1.X + v2.X, v1.Y + v2.Y);

  public static Vector2 operator -(Vector2 v1, Vector2 v2) =>
    new(v1.X - v2.X, v1.Y - v2.Y);

  public Vector2(int x, int y)
  {
    X = x;
    Y = y;
  }
}
