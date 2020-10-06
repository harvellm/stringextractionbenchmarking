using System;
using BenchmarkDotNet.Running;

namespace benchmarking
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<NameParserBenchmarks>();
            //var j = new NameParserBenchmarks();
            //j.ExtractValueswithSubstring();
        }
    }
}
