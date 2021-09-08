using System;

namespace DemoApp
{
	delegate float InterestRate(int years);

	class Program 
	{
	
		public static double CashValue(double installment, int years, InterestRate rate)
		{
			float i = rate(years) / 100;
			return installment * (1 + 1 / i) * (Math.Pow(1 + i, years) - 1);
		}
		
		static float SafeScheme(int y) 
		{
			return y < 3 ? 6 : 7;
		}

		public static void Main(string[] args)
		{
			double p = double.Parse(args[0]);
			int n = int.Parse(args[1]);
			Console.WriteLine("Final Amount in riskless investment: {0:0.00}", CashValue(p, n, SafeScheme));
			Console.WriteLine("Final amount in riskful investment : {0:0.00}", CashValue(p, n, y => 8 + 0.1f * y));
		}

	}
}

