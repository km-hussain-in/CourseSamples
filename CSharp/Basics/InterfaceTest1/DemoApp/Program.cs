using Banking;
using System;

namespace DemoApp
{
	static class BankHelper
	{
		public static Account GetNewAccount(decimal amount, bool business=false)
		{
			Account acc = business ? Banker.OpenCurrentAccount() : Banker.OpenSavingsAccount();
			acc.Deposit(amount);
			return acc;
		}

		public static void AddAnnualInterest(this IProfitable target)
		{
			decimal interest = target.GetInterest(12);
			Account acc = (Account) target;
			acc.Deposit(interest);
		}
	}

    class Program
    {
		static void PayAnnualInterest(Account[] entries)
		{
			foreach(Account entry in entries)
			{
				IProfitable p = entry as IProfitable;
				p?.AddAnnualInterest();
			}
		}

        static void Main(string[] args)
        {
			Account[] bank = new Account[5];	
			bank[0] = BankHelper.GetNewAccount(5000);
			bank[1] = BankHelper.GetNewAccount(20000, true);
			bank[2] = BankHelper.GetNewAccount(25000);
			bank[3] = BankHelper.GetNewAccount(40000, true);
			bank[4] = BankHelper.GetNewAccount(45000);
			PayAnnualInterest(bank);
			foreach(var acc in bank)
				Console.WriteLine("{0}\t{1:0.00}", acc.Id, acc.Balance);

        }
    }
}

