﻿using BenchmarkDotNet.Tasks;
using System;
using System.Threading;
using Xunit;

namespace BenchmarkDotNet.IntegrationTests
{
    public class SetupAttributeTest : IntegrationTestBase
    {
        [Fact]
        public void Test()
        {
            var reports = new BenchmarkRunner().RunCompetition(new SetupAttributeTest());
            Assert.Contains("// ### Setup called ###" + Environment.NewLine, GetTestOutput());
        }

        [Setup]
        public void Setup()
        {
            Console.WriteLine("// ### Setup called ###");
        }

        [Benchmark]
        [BenchmarkTask(processCount: 1, warmupIterationCount: 1, targetIterationCount: 1)]
        public void Benchmark()
        {
            Thread.Sleep(5);
        }
    }
}
