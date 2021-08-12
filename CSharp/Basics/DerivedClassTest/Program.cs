using System;

namespace DerivedClassTest
{
	using Payroll;

    class Program
    {
		static double GetIncomeTax(Employee emp)
		{
			double i = emp.GetIncome();
			return i > 10000 ? 0.15 * (i - 10000) : 0;
		}

		static double GetAverageIncome(Employee[] group)
		{
			double total = 0;
			foreach(Employee member in group)
			{
				total += member.GetIncome();
			}
			return total / group.Length;
		}

		static double GetTotalSales(Employee[] group)
		{
			double total = 0;
			foreach(Employee member in group)
			{
				if(member is SalesPerson agent)
					total += agent.Sales;
			}
			return total;
		}

        static void Main(string[] args)
        {
			var jack = new Employee();
			jack.Hours = 186;
			jack.Rate = 52;
			var jill = new SalesPerson(186, 52, 68000);
			Console.WriteLine("Jack's ID is {0}, Income is {1:0.00} and Tax is {2:0.00}", jack.Id, jack.GetIncome(), GetIncomeTax(jack));
			Console.WriteLine("Jill's ID is {0}, Income is {1:0.00} and Tax is {2:0.00}", jill.Id, jill.GetIncome(), GetIncomeTax(jill));
			Employee[] dept = new Employee[5];
			dept[0] = jack;
			dept[1] = jill;
			dept[2] = new Employee(178, 196);	
			dept[3] = new Employee(195, 235);	
			dept[4] = new SalesPerson(166, 44, 32000);	
			Console.WriteLine("Number of Employees = {0}", Employee.CountInstances());
			Console.WriteLine("Average Income = {0:0.00}", GetAverageIncome(dept));
			Console.WriteLine("Total Sales = {0:0.00}", GetTotalSales(dept));
        }
    }
}
