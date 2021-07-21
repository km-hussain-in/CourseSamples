using System;

namespace MethodTest2
{
    class Program
    {
		static double Income(double sum, int years, bool risky=false)
		{
			float rate = risky ? 8 : 6;
			double amount = sum * Math.Pow(1 + rate / 100, years);
			return amount - sum;
		}

        static void Main(string[] args)
        {
			try
			{
				double s = double.Parse(args[0]);
				int y = int.Parse(args[1]);
				Console.WriteLine("Income in SILVER scheme: {0:0.00}", Income(s, y));
				Console.WriteLine("Income in GOLD scheme: {0:0.00}", Income(s, y, true));
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
