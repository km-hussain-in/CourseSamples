using System;

namespace MethodTest1
{
	class Program
	{
		private static double Average(double first, double second, params double[] remaining)
		{
			double total = first + second;
			foreach(double value in remaining)
			{
				total += value;
			}
			return total / (remaining.Length + 2);
		}

		private static double Average(double first, double second, out double dev)
		{
			dev = first > second ? (first - second) / 2 : (second - first) / 2;
			return Average(first, second);
		}

		public static void Main(string[] args)
		{
			Console.WriteLine("Hello World!");	
			Console.WriteLine("Average of five values: {0}", Average(22.7, 31.8, 27.6, 18.3, 35.4));
			if(args.Length > 1)
			{
				double x = double.Parse(args[0]);
				double y = double.Parse(args[1]);
				double a = Average(x, y, out double d);
				Console.WriteLine($"Average of input values is {a} with a deviation of {d}");
			}
		}
	}
}

