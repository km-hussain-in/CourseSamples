using System;

partial class Interval
{
	public static Interval operator+(Interval lhs, Interval rhs)
	{
		return new Interval(lhs.Minutes + rhs.Minutes, lhs.Seconds + rhs.Seconds);
	}
	
	public static bool operator==(Interval lhs, Interval rhs)
	{
		return lhs.GetHashCode() == rhs.GetHashCode() && lhs.Equals(rhs);
	}
	
	public static bool operator!=(Interval lhs, Interval rhs)
	{
		return !(lhs == rhs);
	}
}

struct Rectangle
{
	public int Length, Breadth;

	public override string ToString()
	{
		return $"{Length}x{Breadth}";
	}
}

static class Program
{
	private static void Print(string name, object obj)
	{
		Type t = obj.GetType();
		Console.WriteLine($"{t.Name} {name} = {obj}");
	}

	public static bool Search(object x, params object[] source)
	{
		foreach(object y in source)
		{
			if(x.GetHashCode() == y.GetHashCode() && x.Equals(y))
				return true;
		}
		return false;
	}

	public static void Main(string[] args)
	{
		var a = new Interval(3, 15);
		var b = new Interval(4, 50);
		var c = new Interval(2, 75);
		var d = b;
		var e = a + b;
		Print("a", a);	
		Print("b", b);	
		Print("c", c);	
		Print("d", d);	
		Print("e", e);	
		Console.WriteLine("a is identical to b: {0}", ReferenceEquals(a, b));
		Console.WriteLine("a is identical to c: {0}", ReferenceEquals(a, c));
		Console.WriteLine("d is identical to b: {0}", ReferenceEquals(d, b));
		if(args.Length > 1)
		{
			int m = int.Parse(args[0]);
			int s = int.Parse(args[1]);
			var f = new Interval(m, s);
			if(Search(f, a, b, c, e))
				Console.WriteLine("Matching Interval found.");
			else
				Console.WriteLine("No match found!");
		}
		Console.WriteLine("a is equal to b: {0}", a == b);	
		Console.WriteLine("a is equal to c: {0}", a == c);
		Console.WriteLine("d is equal to b: {0}", d == b);
		var g = new Rectangle {Length=32, Breadth=25};
		Print("g", g);
	}
}

