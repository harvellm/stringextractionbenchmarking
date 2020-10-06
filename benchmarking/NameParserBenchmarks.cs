using System;
using System.Collections.Generic;
using System.Text;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;

namespace benchmarking
{
    [RankColumn]
    [Orderer(SummaryOrderPolicy.FastestToSlowest)]
    [MemoryDiagnoser]
    public class NameParserBenchmarks
    {
        private const string CheckLine = "RMTDTL                    442051900708/31/2020    1771.75    1771.75       0.00";
        private static readonly NameParser Parser = new NameParser();

        [Benchmark(Baseline = true)]
        public void ExtractValuesWithSubstring()
        {
            Parser.ExtractWithSubstring(CheckLine);
        }
        [Benchmark]
        public void ExtractValuesWithSubstringWithoutTrim()
        {
            Parser.ExtractWithSubstring(CheckLine);
        }

        [Benchmark]
        public void ExtractValuesWithTextFieldParser()
        {
            Parser.ExtractValuesWithTextFieldParser(CheckLine);
        }
        [Benchmark]
        public void ExtractValuesWithTextFieldParserWithoutTrim()
        {
            Parser.ExtractValuesWithTextFieldParser(CheckLine);
        }


        [Benchmark]
        public void ExtractValuesWithSpan()
        {
            Parser.ExtractValuesWithSpan(CheckLine);
        }
        [Benchmark]
        public void ExtractValuesWithSpanWithoutTrim()
        {
            Parser.ExtractValuesWithSpan(CheckLine);
        }

        [Benchmark]
        public void ExtractValuesWithRegex()
        {
            Parser.ExtractValuesWithRegex(CheckLine);
        }
        [Benchmark]
        public void ExtractValuesWithRegexWithoutTrim()
        {
            Parser.ExtractValuesWithRegex(CheckLine);
        }
    }
}
