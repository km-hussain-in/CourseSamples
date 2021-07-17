using Banking;
using System;

static class Program
{
	public static void Main(string[] args)
	{
		Account jack = Banker.OpenCurrentAccount();
		jack.Deposit(15000);
		Account jill = Banker.OpenSavingsAccount();
		jill.Deposit(10000);
		try
		{
			double payment = double.Parse(args[0]);
			jill.Transfer(payment, jack);
			Console.WriteLine("Transfer succeeded.");
		}
		catch(InsufficientFundsException)
		{
			Console.WriteLine("Transfer failed!");
		}
		catch(Exception ex)
		{
			Console.WriteLine("Error: {0)", ex.Message);
		}
		Console.WriteLine("Jack Account ID is {0} and Balance is {1}", jack.Id, jack.Balance);
		Console.WriteLine("Jill Account ID is {0} and Balance is {1}", jill.Id, jill.Balance);
	}
}

