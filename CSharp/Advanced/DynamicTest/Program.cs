using System;

namespace DynamicTest
{
	class Program
	{
		static dynamic CreateEmployee(int hours, float rate)
		{
			dynamic employee = new System.Dynamic.ExpandoObject();
			employee.Hours = hours;
			employee.Rate = rate;
			employee.Income = (Func<double>)(() => employee.Hours * employee.Rate);
			if(hours > 180)
				employee.Bonus = (Func<float, double>)(p => 0.01 * p * employee.Rate * (employee.Hours - 180));
			return employee;
		}

		static void Main(string[] args)
		{
			try
			{	
				Type t = Type.GetType($"DynamicTest.{args[0]}", true);
				dynamic g = Activator.CreateInstance(t); //DLR call-site will be created for g to support duck typing
				Console.WriteLine(g.Meet("Jack"));
				if(args.Length > 2)
				{
					int h = int.Parse(args[1]);
					float r = float.Parse(args[2]);
					dynamic emp = CreateEmployee(h, r);
					Console.WriteLine("Income: {0:0.00}", emp.Income());
					Console.WriteLine("Bonus : {0:0.00}", emp.Bonus(40));
				}
				Console.WriteLine(g.Leave("Jack"));
			}
			catch(Exception ex)
			{
				Console.WriteLine("Error: {0}", ex.Message);
			}
		}
	}
}

