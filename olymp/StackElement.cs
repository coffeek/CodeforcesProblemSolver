namespace Olymp
{
  public struct StackElement
  {
    public readonly int value;
    public readonly int min;
    public readonly int max;

    public StackElement(int value, int min, int max)
    {
      this.value = value;
      this.min = min;
      this.max = max;
    }
  }
}
