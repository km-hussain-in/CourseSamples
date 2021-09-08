using System;

namespace Greeting
{

	class FormalGreeter
	{
		public string Title { get; set; } = "Mr";

		public string Greet(string visitor) => $"Hello {Title} {visitor}";	
	}

	class CasualGreeter
	{

		public String Greeted { get; set; } = "Nobody";

		public int Count { get; set; } = 0;

		public string Greet(string visitor)
		{
			Greeted = visitor;
			Count += 1;
			return $"Hi {visitor}";
		}
	}

	static class DynamicGreeter
	{
		public static dynamic Build(string salute)
		{
			dynamic greeter = new System.Dynamic.ExpandoObject();
			greeter.Time = DateTime.Now;
			greeter.Meet = (Func<string, string>)(person => $"{salute} {person}");
			if(salute == "Welcome")
				greeter.Leave = (Func<string, string>)(person => $"Goodbye {person}");
			return greeter;
		}
	}
}


