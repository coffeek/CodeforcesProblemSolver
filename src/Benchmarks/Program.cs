using BenchmarkDotNet.Running;
using Benchmarks.Benchmarks;

Console.WriteLine(BenchmarkRunner.Run<XorArray>());
