using System;

namespace DelegateTest
{
	delegate float Scheme(int period);

	class Investment 
	{
		private double invest;
		private int years;

		public Investment(double amount, int period)
		{
			invest = amount;
			years = period;
		}

		public double GetIncome(Scheme interest)
		{
			float rate = interest(years);
			double amount = invest * Math.Pow(1 + rate / 100, years);
			return amount - invest;
		}

	}

	class Program 
	{
		
		static float SilverScheme(int y) 
		{
			return y < 3 ? 6 : 7;
		}

		public static void Main(string[] args)
		{
			double p = double.Parse(args[0]);
			int n = int.Parse(args[1]);
			Investment inv = new Investment(p, n);
			Console.WriteLine("Income in Silver Scheme: {0:0.00}", inv.GetIncome(SilverScheme));
			Console.WriteLine("Income in Gold Scheme: {0:0.00}", inv.GetIncome(y => 8 + 0.1f * y));
		}

	}
}
