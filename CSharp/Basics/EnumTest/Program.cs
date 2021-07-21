using System;

namespace EnumTest
{
	enum RiskLevel {None, Low, High}

	class Investment
	{
		private double sum;
		private int years;
		private RiskLevel risk;

		public Investment(double amount, int duration)
		{
			sum = amount;
			years = duration;
			risk = RiskLevel.None;
		}

		public void AllowRisk(bool yes)
		{
			risk = yes ? RiskLevel.Low : RiskLevel.None;
		}

		public void AdjustRisk(RiskLevel level)
		{
			risk = level;
		}

		public double Income()
		{
			float rate;
			switch(risk)
			{
				case RiskLevel.None:
					rate = 6;
					break;
				case RiskLevel.High:
					rate = 11;
					break;
				default:
					rate = 8;
					break;
			};
			double amount = sum * Math.Pow(1 + rate / 100, years);
			return amount - sum;
		}


	}

    class Program
    {
        static void Main(string[] args)
        {
			try
			{
				double s = double.Parse(args[0]);
				int y = int.Parse(args[1]);
				var inv = new Investment(s, y);
				Console.WriteLine("Income in SILVER scheme: {0:0.00}", inv.Income());
				inv.AllowRisk(true);
				Console.WriteLine("Income in GOLD scheme: {0:0.00}", inv.Income());
				inv.AdjustRisk(RiskLevel.High);
				Console.WriteLine("Income in PLATINUM scheme: {0:0.00}", inv.Income());
			}
			catch(IndexOutOfRangeException)
			{
				Console.WriteLine("Missing input!");
			}
			catch(FormatException)
			{
				Console.WriteLine("Invalid input!");
			}
        }
    }
}

