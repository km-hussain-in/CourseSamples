using System;

namespace MethodTest
{
    class Program
    {
		static double Income(double sum, int years, bool risky)
		{
			float rate = risky ? 8 : 6;
			double amount = sum * Math.Pow(1 + rate / 100, years);
			return amount - sum;
		}

		static double Income(double sum, int years=1)
		{
			return Income(sum, years, sum < 25000);
		}

        static void Main(string[] args)
        {
			double s = double.Parse(args[0]);
			if(args.Length > 1)
			{
				int y = int.Parse(args[1]);
				Console.WriteLine("Income in no-risk scheme: {0:0.00}", Income(s, y, false));
				Console.WriteLine("Income in low-risk scheme: {0:0.00}", Income(s, y, true));
			}
			else
			{
				Console.WriteLine("Income in smart scheme: {0:0.00}", Income(s));
			}
        }
    }
}
