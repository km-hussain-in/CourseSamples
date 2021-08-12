namespace Banking
{
	sealed class SavingsAccount : Account, IProfitable
	{
		const decimal MinBal = 5000;

		internal SavingsAccount()
		{
			Balance = MinBal;
		}

		public override void Deposit(decimal amount)
		{
			Balance += amount;
		}
		
		public override void Withdraw(decimal amount)
		{
			if(Balance - amount < MinBal)
				throw new InsufficientFundsException();
			Balance -= amount;
		}

		public decimal AddInterest(int months)
		{
			decimal rate = Balance < 3 * MinBal ? 3.5M : 4.0M;
			decimal interest = Balance * months * rate / 1200;
			Balance += interest;
			return interest;
		}
	}
}

