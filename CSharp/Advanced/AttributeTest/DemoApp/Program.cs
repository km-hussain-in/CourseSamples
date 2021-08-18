using Finance.Loans;
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
			Type t = Type.GetType("Finance.Loans." + args[1] + ",Finance", true);
			object policy = Activator.CreateInstance(t);
			MethodInfo option = t.GetMethod(args.Length < 3 ? "Common" : args[2]);
			var mda = option.GetCustomAttribute<MaxDurationAttribute>();
			int m = mda?.Limit ?? 6;
			var interest = option.CreateDelegate<RateFunc>(policy);
			for(int n = 1; n <= m; ++n)
			{
				float i = interest(p, n) / 1200;
				double e = p * i / (1 - Math.Pow(1 + i, -12 * n));
				Console.WriteLine("{0, -6}{1, 12:0.00}", n, e);
			}
		}
	}
}

