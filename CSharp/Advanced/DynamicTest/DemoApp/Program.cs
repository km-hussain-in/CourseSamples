using System;

namespace DemoApp
{
	
	class Program
	{
		static void Main(string[] args)
		{
			Type t = Type.GetType(args[0]);
			if(t != null)
			{
				dynamic g = Activator.CreateInstance(t); 
				foreach(var prop in t.GetProperties())
					Console.WriteLine($"{prop.Name} = {prop.GetValue(g)}");
				Console.WriteLine(g.Greet("Jack"));
			}
			else
			{
				dynamic g = Greeting.DynamicGreeter.Build(args[0]);
				Console.WriteLine($"Time = {g.Time}");
				Console.WriteLine(g.Meet("Jack"));
				Console.WriteLine(g.Leave("Jack"));
			}
		}
	}
}

