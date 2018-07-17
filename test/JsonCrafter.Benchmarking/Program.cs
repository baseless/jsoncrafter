using System;
using BenchmarkDotNet.Running;

namespace JsonCrafter.Benchmarking
{
    class Program
    {
        static void Main(string[] args)
        {
            
        }

        static void RunBenchMark<T>()
        {
            Console.Write(BenchmarkRunner.Run<T>());
            Console.WriteLine($"Benchmark completed for {typeof(T).Name.ToUpper()}. Press a key to continue ..");
            Console.ReadKey();
        }
    }
}
