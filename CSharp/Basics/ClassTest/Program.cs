using System;

namespace ClassTest
{
	#if OLD_VERSION
	class Investment
	{
		private double sum;
		private int years;
		private bool risky;

		public Investment(double amount, int duration)
		{
			sum = amount;
			years = duration;
			risky = false;
		}

		public void AllowRisk(bool yes)
		{
			risky = yes;
		}

		public double Income()
		{
			float rate = risky ? 8 : 6;
			double amount = sum * Math.Pow(1 + rate / 100, years);
			return amount - sum;
		}

	}
	#else
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
	#endif

    class Program
    {
        static void Main(string[] args)
        {
			double s = double.Parse(args[0]);
			int y = int.Parse(args[1]);
			var inv = new Investment(s, y);
			Console.WriteLine("Income in no-risk scheme: {0:0.00}", inv.Income());
			inv.AllowRisk(true);
			Console.WriteLine("Income in low-risk scheme: {0:0.00}", inv.Income());
			#if !OLD_VERSION
			inv.AdjustRisk(RiskLevel.High);
			Console.WriteLine("Income in high-risk scheme: {0:0.00}", inv.Income());
			#endif
		}
    }
}
