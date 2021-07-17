using System;

interface IStackReader<out T>
{
	T Pop();
	bool Empty();
}

class SimpleStack<V> : IStackReader<V>
{
	class Node
	{
		internal V Value;
		internal Node Below;
	}

	private Node top;

	public void Push(V element)
	{
		top = new Node {Value = element, Below = top};
	}

	public V Pop()
	{
		V result = top.Value;
		top = top.Below;
		return result;
	}

	public bool Empty()
	{
		return top == null;
	}

}

static class Program
{
	private static void Print(this IStackReader<object> stack)
	{
		for(int i = 0; !stack.Empty(); ++i)
		{
			if(i > 0)
				Console.Write(", ");
			Console.Write(stack.Pop());
		}
		Console.WriteLine();
	}

	public static void Main()
	{
		var a = new SimpleStack<string>();
		a.Push("Monday");
		a.Push("Tuesday");
		a.Push("Wednesday");
		a.Push("Thursday");
		a.Push("Friday");
		a.Print(); //Program.Print(a);

		var b = new SimpleStack<Interval>();
		b.Push(new Interval(3, 41));
		b.Push(new Interval(5, 12));
		b.Push(new Interval(4, 23));
		b.Push(new Interval(6, 34));	
		b.Print();
	}
}

