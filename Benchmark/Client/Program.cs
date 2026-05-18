using BenchmarkDotNet.Running;
using System.Diagnostics;

namespace Bybit.Net.Benchmark.Client
{
    public class Program
    {
        public static int ServerPort = 5000;

        public static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
}
