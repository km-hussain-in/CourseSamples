using System;
using System.Text;
using System.Linq;
using System.Runtime.InteropServices;

namespace PInvokeTest
{
	class Program
	{
		[DllImport("natsup", EntryPoint="GCD")]
		extern static long GreatestDivisor(long first, long second);

		[DllImport("natsup")]
		extern static int ReverseString(string original, StringBuilder reversed);

		struct Range
		{
			public int Begin, End;
		}

		delegate float Sequence(int at);

		[DllImport("natsup")]
		extern static double SequenceSum(Sequence seq, in Range lim);

		static void Main(string[] args)
		{
			switch(args[0])
			{
				case "gcd":
					long m = long.Parse(args[1]);
					long n = long.Parse(args[2]);
					Console.WriteLine(GreatestDivisor(m, n));
					break;
				case "reverse":
					var buf = new StringBuilder(args[1].Length);
					ReverseString(args[1], buf);
					Console.WriteLine(buf);
					break;
				case "sequence":
					var bounds = new Range
					{
						Begin = 1,
						End = int.Parse(args[1]) + 1
					};
					double sum = SequenceSum(t => 2 * t - 1, bounds);
					Console.WriteLine(sum);
					break;
			}
		}
	}
}

