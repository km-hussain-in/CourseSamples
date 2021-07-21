using System;

namespace ObjectClassTest
{
	partial class Interval
	{
		public static Interval operator+(Interval lhs, Interval rhs)
		{
			return new Interval(lhs.Minutes + rhs.Minutes, lhs.Seconds + rhs.Seconds);
		}

		public static Interval Parse(string val)
		{
			string[] parts = val.Split(':');
			int m = int.Parse(parts[0]);
			int s = int.Parse(parts[1]);
			return new Interval(m, s);
		}
	}

    class Program
    {
		static void Print(object obj, string label)
		{
			var t = obj.GetType();
			Console.WriteLine("{0} {1} = {2}", t.Name, label, obj);
		}

		static bool Match(object key, params object[] items)
		{
			foreach(object item in items)
			{
				if(item.GetHashCode() == key.GetHashCode() && item.Equals(key))
					return true;
			}
			return false;
		}

        static void Main(string[] args)
        {
            Interval a = new Interval(5, 15);
			Print(a, "first");
			Interval b = new Interval(3, 50);
			Print(b, "second");
			Interval c = a + b;
			Print(c, "sum");
			if(args.Length > 0)
			{
				Interval i = Interval.Parse(args[0]);
				if(Match(i, a, b, c))
					Console.WriteLine("Found match!");
				else
					Console.WriteLine("No match found!");
			}
			Rectangle d = new Rectangle(30, 29);
			Print(d, "frame");
        }
    }
}
