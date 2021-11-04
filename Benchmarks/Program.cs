using System;
using BenchmarkDotNet.Running;
using Benchmarks.Benchmarks;

namespace Benchmarks
{
  class Program
  {
    static void Main()
    {
      Console.WriteLine(BenchmarkRunner.Run<GetDigitsCount>());
    }
  }
}
