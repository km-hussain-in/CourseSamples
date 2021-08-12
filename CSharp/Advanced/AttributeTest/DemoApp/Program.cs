using Finance;
using System;
using System.Reflection;

namespace DemoApp
{
	using RateFunc = System.Func<double, int, float>;
	
	class Program
	{
		static void Main(string[] args)
		{
			double p = double.Parse(args[0]);
			Type t = Type.GetType("Finance." + args[1] + ",FinLib");
			object policy = Activator.CreateInstance(t);
			var op = t.GetMethod(args.Length < 3 ? "GetInterestRate" : "GetInterestRateFor" + args[2]);
			var mda = op.GetCustomAttribute<MaxDurationAttribute>();
			int m = mda?.Limit ?? 10;
			var rate = op.CreateDelegate<RateFunc>(policy);
			for(int n = 1; n <= m; ++n)
			{
				float i = rate(p, n) / 1200;
				double e = p * i / (1 - Math.Pow(1 + i, -12 * n));
				Console.WriteLine("{0, -6}{1, 12:0.00}", n, e);
			}
		}
	}
}

