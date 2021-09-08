using System;
using System.Linq;
using System.Threading.Tasks;

namespace DemoApp
{
	class Computation
	{
		private long CalculatedValue(int amount)
		{
			int t = Environment.TickCount + 100 * amount;
			while(Environment.TickCount < t);
			return amount * amount;
		}

		public long Compute(int first, int last)
		{
			return Enumerable.Range(first, last)
					.AsParallel()
					.Select(CalculatedValue)
					.Sum();
		}

		public Task<long> ComputeAsync(int first, int last)
		{
			return Task<long>.Run(() => Compute(first, last));
		}
	}

	class Program
	{
		static async Task DoComputation(int count)
		{
			Console.Write("Computing...");
			var w = new System.Diagnostics.Stopwatch();
			var c = new Computation();
			w.Start();
			var r = await c.ComputeAsync(1, count);
			w.Stop();
			Console.WriteLine("Done!");
			Console.WriteLine("Result = {0}, computed in {1:0.000} seconds.", r, w.Elapsed.TotalSeconds);
		}

		static void Main(string[] args)
		{
			int n = args.Length > 0 ? int.Parse(args[0]) : 10;
			var job = DoComputation(n);
			while(!job.IsCompleted)
			{
				Console.Write(".");
				Task.Delay(200).Wait();
			}
		}
	}
}

