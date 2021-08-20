using System;

namespace GenMethodTest
{
	partial class Interval : IComparable<Interval>
	{
		public int CompareTo(Interval? that)
		{
			return this.GetTime() - that!.GetTime();
		}
	}

    class Program
    {
		static T Select<T>(int index, T first, T second)
		{
			if((index % 2) == 1)
				return first;
			return second;
		}

		static T Select<T>(T first, T second) where T : IComparable<T>
        {
			if(first.CompareTo(second) > 0)
				return first;
			return second;
		}

		static void Main(string[] args)
        {
			if(args.Length > 0)
			{		
				int i = int.Parse(args[0]);
				string ss = Select(i, "Monday", "Friday");
				Console.WriteLine($"Selected string = {ss}");
				double sd = Select(i, 3.45, 5.43);
				Console.WriteLine($"Selected double = {sd}");
				Interval si = Select(i, new Interval(7, 20), new Interval(6, 30));
				Console.WriteLine($"Selected Interval = {si}");
			}
			else
			{
				string ss = Select("Monday", "Friday");
				Console.WriteLine($"Selected string = {ss}");
				double sd = Select(3.45, 5.43);
				Console.WriteLine($"Selected double = {sd}");
				Interval si = Select(new Interval(7, 20), new Interval(6, 30));
				Console.WriteLine($"Selected Interval = {si}");
			}

        }
    }
}
