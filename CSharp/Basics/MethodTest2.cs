using System;

static class Program 
{
	private static double GetIncome(double invest, int years, bool risk=false)
	{
		float rate = risk ? 7 : 5;
		double amount = invest * Math.Pow(1 + rate / 100, years);
		return amount - invest;
	}

	public static void Main(string[] args)
	{
		double p = double.Parse(args[0]);
		int n = int.Parse(args[1]);
		Console.WriteLine("Income in Gold Scheme: {0:0.00}", GetIncome(p, n, true));
		Console.WriteLine("Income in Silver Scheme: {0:0.00}", GetIncome(p, n));
	}

}

