using System;
using System.Threading.Tasks;

namespace AsyncAwaitTest
{
	class Computation
	{
		private long Calculate(int amount)
		{
			int t = Environment.TickCount + 100 * amount;
			while(Environment.TickCount < t);
			return amount * amount;
		}

		public long Compute(int first, int last)
		{
			long result = 0;
			for(int value = first; value <= last; ++value)
			{
				result += Calculate(value);
			}
			return result;
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
			var c = new Computation();
			var r = await c.ComputeAsync(1, count);
			Console.WriteLine("Done!");
			Console.WriteLine($"Result = {r}");
		}

		static void Main(string[] args)
		{
			int n = args.Length > 0 ? int.Parse(args[0]) : 10;
			var job = DoComputation(n);
			while(!job.IsCompleted)
			{
				Console.Write(".");
				Task.Delay(500).Wait();
			}
		}
	}
}

