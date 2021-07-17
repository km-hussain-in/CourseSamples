using System;
using System.Linq;

static class Program
{
	private unsafe static double SquareSum(double[] values)
	{
		double result = 0;
		fixed(double* buf = &values[0])
		{
			for(int i = 0; i < values.Length; ++i)
				result += buf[i] * buf[i];
		}
		return result;
	}

	public static void Main(string[] args)
	{
		double[] list = args.Select(double.Parse).ToArray();
		Console.WriteLine("Sum of squares = {0}", SquareSum(list));
	}
}

