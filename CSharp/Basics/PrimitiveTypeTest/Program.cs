using System;

double Income(double sum, int years, bool risky=false)
{
	float rate = risky ? 8 : 6;
	double amount = sum * Math.Pow(1 + rate / 100, years);
	return amount - sum;
}

Console.Write("Amount: ");
double s = double.Parse(Console.ReadLine());
Console.Write("Period: ");
int y = int.Parse(Console.ReadLine());
Console.WriteLine("Income in low-risk investment: {0:0.00}", Income(s, y, true));
Console.WriteLine("Income in no-risk investment: {0:0.00}", Income(s, y));
