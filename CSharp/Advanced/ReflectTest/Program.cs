using System;

namespace ReflectTest
{

	record Customer(string Name, decimal Credit);

	record Product(string Code, int Stock, decimal Price);

	class Program
	{
		static void PrintAsXml(object obj)
		{
			Type t = obj.GetType();
			Console.WriteLine("<{0}>", t.Name);
			foreach(var p in t.GetProperties())
				Console.WriteLine("    <{0}>{1}</{0}>", p.Name, p.GetValue(obj));
			Console.WriteLine("</{0}>", t.Name);
			Console.WriteLine();
		}

		static void Main()
		{
			PrintAsXml(new Customer("Jack", 5000));
			PrintAsXml(new Product("HDD", 75, 3250));
		}
	}
}

