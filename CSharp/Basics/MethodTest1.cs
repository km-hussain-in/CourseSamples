using System;

static class Program
{
	private static double Average(double first, double second, params double[] other)
	{
		double total = first + second;
		foreach(double value in other)
			total += value;
		return total / (2 + other.Length);
	}

	private static double Average(double first, double second, out double deviation)
	{
		deviation = first > second ? (first - second) / 2 : (second - first) / 2;
		return Average(first, second);
	}

	public static void Main(string[] args)
	{
		Console.WriteLine("Average of two values = {0}", Average(23.5, 28.6));
		Console.WriteLine("Average of five values = {0}", Average(23.5, 28.6, 17.2, 32.9, 24.7));
		if(args.Length > 1)
		{
			double x = double.Parse(args[0]);
			double y = double.Parse(args[1]);
			double d;
			double a = Average(x, y, out d);
			Console.WriteLine($"Average of given values is {a} with a deviation of {d}");
		}
	}
}

