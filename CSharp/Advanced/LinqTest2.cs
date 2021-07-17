using System;
using System.Linq;

static class Program
{
	private static long Calculate(int amount)
	{
		int t = Environment.TickCount + 100 * amount;
		while(Environment.TickCount < t);
		return amount * amount;
	}

	public static void Main(string[] args)
	{
		int m = args.Length > 0 ? int.Parse(args[0]) : 10;
		var sequence = Enumerable.Range(1, m);

		int t1 = Environment.TickCount;
		var r = (from n in sequence.AsParallel() select Calculate(n)).Sum();
		int t2 = Environment.TickCount;

		Console.WriteLine("Result = {0}, computed in {1:0.0} seconds.", r, (t2 - t1) / 1000.0);
	}
}
