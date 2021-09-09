using System;

namespace DemoApp
{

    class Program
    {
		static void PopPrint(IStack<object> store)
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
			SimpleStack<Interval> b = new();
			b.Push(new Interval(3, 41));
			b.Push(new Interval(5, 32));
			b.Push(new Interval(8, 23));
			b.Push(new Interval(6, 14));
			PopPrint(b);
			var c = new SimpleStack<double?>();
			c.Push(5.13);
			c.Push(7.24);
			c.Push(null);
			c.Push(4.37);
			c.Push(6.45);
			foreach(var d in c)
				Console.WriteLine(d ?? 0.01);
        }
    }
}
