using Payroll;
using System;

static class Program
{
	private static double Tax(Employee emp)
	{
		double i = emp.Income();
		return i > 10000 ? 0.15 * (i - 10000) : 0; 
	}

	private static double AverageIncome(Employee[] group)
	{
		double total = 0;
		foreach(Employee member in group)
		{
			total += member.Income();
		}
		return total / group.Length;
	}

	private static double TotalBonus(Employee[] group)
	{
		double total = 0;
		foreach(Employee member in group)
		{
			if(member is SalesPerson)
				total += 10 * member.Hours;
			else
				total += 50 * member.Rate;
		}
		return total;
	}

	private static double TotalSales(Employee[] group)
	{
		double total = 0;
		foreach(Employee member in group)
		{
			SalesPerson sp = member as SalesPerson;
			if(sp != null)
				total += sp.Sales;
		}
		return total;
	}

	public static void Main()
	{
		var jack = new Employee();
		jack.Hours = 186;
		jack.Rate = 52;
		Console.WriteLine("Jack's ID is {0}, Income is {1:0.00} and Tax is {2:0.00}", jack.Id, jack.Income(), Tax(jack));
		var jill = new SalesPerson(186, 52, 64000);
		Console.WriteLine("Jill's ID is {0}, Income is {1:0.00} and Tax is {2:0.00}", jill.Id, jill.Income(), Tax(jill));

		Employee[] dept = new Employee[5];
		dept[0] = jack;
		dept[1] = jill;
		dept[2] = new Employee(175, 95);
		dept[3] = new Employee(190, 210);
		dept[4] = new SalesPerson(168, 44, 36000);
		Console.WriteLine("In their department...");
		Console.WriteLine("Number of Employees = {0}", Employee.CountInstances());
		Console.WriteLine("Average Income = {0:0.00}", AverageIncome(dept));
		Console.WriteLine("Total Bonus = {0:0.00}", TotalBonus(dept));
		Console.WriteLine("Total Sales = {0:0.00}", TotalSales(dept));
	}
}

