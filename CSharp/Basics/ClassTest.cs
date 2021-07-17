using System;

class Investment 
{
	private double invest;
	private int years;
	private bool risk;

	public Investment(double amount, int period)
	{
		invest = amount;
		years = period;
	}

	public void AllowRisk(bool yes)
	{
		risk = yes;
	}

	public double GetIncome()
	{
		float rate = risk ? 7 : 5;
		double amount = invest * Math.Pow(1 + rate / 100, years);
		return amount - invest;
	}

}

static class Program 
{
	public static void Main(string[] args)
	{
		double p = double.Parse(args[0]);
		int n = int.Parse(args[1]);
		Investment inv = new Investment(p, n);
		Console.WriteLine("Income in Silver Scheme: {0:0.00}", inv.GetIncome());
		inv.AllowRisk(true);
		Console.WriteLine("Income in Gold Scheme: {0:0.00}", inv.GetIncome());
	}

}

