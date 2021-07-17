using System;

enum RiskLevel {None, Low, High}

class Investment 
{
	private double invest;
	private int years;
	private RiskLevel risk;

	public Investment(double amount, int period)
	{
		invest = amount;
		years = period;
	}

	public void AllowRisk(bool yes)
	{
		risk = yes ? RiskLevel.Low : RiskLevel.None;
	}

	public void AdjustRisk(RiskLevel level)
	{
		risk = level;
	}

	public double GetIncome()
	{
		float rate;
		switch(risk)
		{
			case RiskLevel.Low:
				rate = 7;
				break;
			case RiskLevel.High:
				rate = 8;
				break;
			default:
				rate = 5;
				break;
		}
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
		inv.AdjustRisk(RiskLevel.High);
		Console.WriteLine("Income in Platinum Scheme: {0:0.00}", inv.GetIncome());
	}

}

