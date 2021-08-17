using System;

namespace DynamicTest
{
	
	class Program
	{
		static void Main(string[] args)
		{
			try
			{	
				Type t = Type.GetType(args[0], true);
				object g = Activator.CreateInstance(t); 
				foreach(var prop in t.GetProperties())
				{
					Console.WriteLine($"{prop.Name} = {prop.GetValue(g)}");
				}
				dynamic dg = g;
				Console.WriteLine(dg.Meet("Jack"));
				if(args.Length > 1)
				{
					Console.WriteLine(dg.Leave(args[1]));
				}
			}
			catch(Exception ex)
			{
				Console.WriteLine("Error: {0}", ex.Message);
			}
		}
	}
}

