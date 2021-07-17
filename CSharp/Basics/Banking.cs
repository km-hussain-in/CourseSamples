namespace Banking
{
	using System;

	public class InsufficientFundsException : ApplicationException {}

	public abstract class Account
	{
		public long Id { get; internal set; }

		public double Balance { get; protected set; }

		public abstract void Deposit(double amount);

		public abstract void Withdraw(double amount);

		public void Transfer(double amount, Account that)
		{
			if(!ReferenceEquals(this, that))
			{
				this.Withdraw(amount);
				that.Deposit(amount);
			}
		}
	}

	public interface IProfitable
	{
		double AddInterest(int months);
	}

	sealed class CurrentAccount : Account
	{
		public override void Deposit(double amount)
		{
			if(Balance < 0)
				amount *= 0.9;
			Balance += amount;
		}
		
		public override void Withdraw(double amount)
		{
			Balance -= amount;
		}
	}

	sealed class SavingsAccount : Account, IProfitable
	{
		const double MinBal = 5000;

		internal SavingsAccount()
		{
			Balance = MinBal;
		}
		
		public override void Deposit(double amount)
		{
			Balance += amount;
		}
		
		public override void Withdraw(double amount)
		{
			if(Balance - amount < MinBal)
				throw new InsufficientFundsException();
			Balance -= amount;
		}

		public double AddInterest(int months)
		{
			float rate = Balance < 3 * MinBal ? 4.0f : 4.5f;
			double interest = Balance * months * rate / 1200;
			Balance += interest;
			return interest;
		}

	
	}

	public static class Banker
	{
		private static long nid = DateTime.Now.Ticks % 1000000;

		public static Account OpenCurrentAccount()
		{
			var acc = new CurrentAccount();
			acc.Id = 100000000 + nid++;
			return acc;
		}

		public static Account OpenSavingsAccount()
		{
			var acc = new SavingsAccount();
			acc.Id = 200000000 + nid++;
			return acc;
		}
	}
}

