using System;

namespace GenTypeTest
{

	interface IStackReader<out V>
	{
		V Pop();
		bool Empty();
	}

	partial class SimpleStack<V> : IStackReader<V>
	{
	}

    class Program
    {
		static void PopPrint(IStackReader<object> store)
		{
			for(int n = 0; !store.Empty(); ++n)
			{
				if(n > 0)
					Console.Write(", ");
				Console.Write(store.Pop());
			}
			Console.WriteLine();
		}

        static void Main(string[] args)
        {
			var a = new SimpleStack<string>();
			a.Push("Monday");
			a.Push("Tuesday");
			a.Push("Wednesday");
			a.Push("Thursday");
			a.Push("Friday");
			PopPrint(a);
			var b = new SimpleStack<Interval>();
			b.Push(new Interval(3, 41));
			b.Push(new Interval(5, 32));
			b.Push(new Interval(8, 23));
			b.Push(new Interval(6, 14));
			PopPrint(b);
        }
    }
}
