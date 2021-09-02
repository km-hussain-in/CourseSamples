using Banking;
using System;

namespace DemoApp
{
    class Program
    {
        static void Main(string[] args)
        {
			Account jack = Banker.OpenCurrentAccount();
			jack.Deposit(15000);
			Account jill = Banker.OpenSavingsAccount();
			jill.Deposit(10000);
			try
			{
				decimal payment = decimal.Parse(args[0]);
				jill.Transfer(payment, jack);
				Console.WriteLine("Payment succeeded.");
			}
			catch(InsufficientFundsException)
			{
				Console.WriteLine("Payment failed due to lack of funds!");
				jill.CloseAccount();
			}
			catch(Exception ex)
			{
				Console.WriteLine($"Error: {ex.Message}");
			}
			Console.WriteLine($"Jack's Account ID is {jack.Id} and Balance is {jack.Balance}");
			Console.WriteLine($"Jill's Account ID is {jill.Id} and Balance is {jill.Balance}");
        }
    }
}

