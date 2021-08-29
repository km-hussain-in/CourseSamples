using Payroll;
using System;

double GetIncomeTax(Employee emp)
{
	double i = emp.GetIncome();
	return i > 10000 ? 0.15 * (i - 10000) : 0;
}

void Appraise(Employee emp)
{
	float raise;
	if(emp is SalesPerson sp)
		raise = sp.Sales < 100000 ? 1 : 1.1f;
	else
		raise = emp.Hours < 175 ? 1 : 1.2f;
	emp.Rate *= raise;
}

var jack = new Employee();
jack.Hours = 186;
jack.Rate = 52;
var jill = new SalesPerson(186, 52, 68000);
Console.WriteLine("Jack's ID is {0}, Income is {1:0.00} and Tax is {2:0.00}", jack.Id, jack.GetIncome(), GetIncomeTax(jack));
Console.WriteLine("Jill's ID is {0}, Income is {1:0.00} and Tax is {2:0.00}", jill.Id, jill.GetIncome(), GetIncomeTax(jill));
Appraise(jack);
Console.WriteLine("Jack's Income after appraisal is {0:0.00}", jack.GetIncome());
Appraise(jill);
Console.WriteLine("Jill's Income after appraisal is {0:0.00}", jill.GetIncome());
Console.WriteLine("Number of Employees = {0}", Employee.CountInstances());

