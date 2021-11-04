﻿namespace Olymp.Utils
{
  public static class Numbers
  {
    public static int DigitsCount(int n)
    {
      if (n < 0)
        n = -n;
      if (n < 100000)
      {
        if (n < 100)
          return n < 10 ? 1 : 2;
        if (n < 1000)
          return 3;
        return n < 10000 ? 4 : 5;
      }
      if (n < 10000000)
        return n < 1000000 ? 6 : 7;
      if (n < 100000000)
        return 8;
      return n < 1000000000 ? 9 : 10;
    }
  }
}
