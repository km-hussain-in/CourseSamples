using System;

double Income(Investment inv)
{
	float rate = inv.Interest();
	double amount = inv.Sum * Math.Pow(1 + rate / 100, inv.Years);
	return amount - inv.Sum;
}

void MakeSmart(ref Investment inv)
{
	inv.AllowRisk(inv.Sum < 50000);
}

Console.Write("Amount: ");
double s = double.Parse(Console.ReadLine());
Console.Write("Period: ");
int y = int.Parse(Console.ReadLine());
Investment i = new Investment(s, y);
Console.WriteLine("Income in no-risk investment: {0:0.00}", Income(i));
MakeSmart(ref i);
Console.WriteLine("Income in smart investment: {0:0.00}", Income(i));
i.AllowRisk(RiskLevel.High);
Console.WriteLine("Income in high-risk investment: {0:0.00}", Income(i));
