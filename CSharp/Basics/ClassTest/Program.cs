using System;

namespace ClassTest
{
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
