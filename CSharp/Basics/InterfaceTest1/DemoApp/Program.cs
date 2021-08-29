using Banking;
using System;

namespace DemoApp
{

    class Program
    {
		static void PayAnnualInterest(Account[] entries)
		{
			foreach(Account entry in entries)
			{
				IProfitable p = entry as IProfitable;
				p?.AddInterest(12);
			}
		}

        static void Main(string[] args)
        {
			Account[] bank = new Account[5];	
			bank[0] = Banker.OpenSavingsAccount();
			bank[0].Deposit(5000);
			bank[1] = Banker.OpenCurrentAccount();
			bank[1].Deposit(20000);
			bank[2] = Banker.OpenSavingsAccount();
			bank[2].Deposit(25000);
			bank[3] = Banker.OpenCurrentAccount();
			bank[3].Deposit(40000);
			bank[4] = Banker.OpenSavingsAccount();
			bank[4].Deposit(45000);
			PayAnnualInterest(bank);
			foreach(var acc in bank)
				Console.WriteLine("{0}\t{1:0.00}", acc.Id, acc.Balance);

        }
    }
}

//dotnet add package Banking -s ../Banking/bin/Debug/

