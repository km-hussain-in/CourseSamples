using System;
using System.Linq;

class ParallelLinqTest
{
	class Program
	{
		static long Calculate(int amount)
		{
			int t = Environment.TickCount + 100 * amount;
			while(Environment.TickCount < t);
			return amount * amount;
		}

		static void Main(string[] args)
		{
			int m = args.Length > 0 ? int.Parse(args[0]) : 10;
			int t1, t2;
			long result = 0;
			t1 = Environment.TickCount;
			for(int n = 1; n <= m; ++n)
				result += Calculate(n);
			t2 = Environment.TickCount;
			Console.WriteLine("Serial Computation Result = {0}, obtained in {1:0.0} seconds.", result, (t2 - t1) / 1000.0);
			t1 = Environment.TickCount;
			result = (from n in Enumerable.Range(1, m).AsParallel() select Calculate(n)).Sum();
			t2 = Environment.TickCount;
			Console.WriteLine("Parallel Computation Result = {0}, obtained in {1:0.0} seconds.", result, (t2 - t1) / 1000.0);
		}
	}
}

