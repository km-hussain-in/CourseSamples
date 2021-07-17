using System;

partial class Interval : IComparable<Interval>
{
	public int CompareTo(Interval that)
	{
		return this.GetTime() - that.GetTime();
	}
}

static class Program
{
	private static T SelectByIndex<T>(int index, T first, T second)
	{
		if((index % 2) == 1)
			return first;
		return second;
	}

	private static T SelectGreater<T>(T first, T second) where T : IComparable<T>
	{
		if(first.CompareTo(second) > 0)
			return first;
		return second;
	}

	public static void Main(string[] args)
	{
		if(args.Length > 0)
		{
			int i = int.Parse(args[0]);
			string ss = SelectByIndex(i, "Monday", "Friday");
			Console.WriteLine($"Selected string = {ss}");
			double sd = SelectByIndex(i, 7.89, 9.87);
			Console.WriteLine($"Selected double = {sd}");
			Interval si = SelectByIndex(i, new Interval(2, 30), new Interval(3, 20));
			Console.WriteLine($"Selected Interval = {si}");
		}			
		else
		{
			string ss = SelectGreater("Monday", "Friday");
			Console.WriteLine($"Selected string = {ss}");
			double sd = SelectGreater(7.89, 9.87);
			Console.WriteLine($"Selected double = {sd}");
			Interval si = SelectGreater(new Interval(2, 30), new Interval(3, 20));
			Console.WriteLine($"Selected Interval = {si}");
		}
	}
}

