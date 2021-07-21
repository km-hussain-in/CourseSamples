namespace Banking
{
	sealed class CurrentAccount : Account
	{
		public override void Deposit(decimal amount)
		{
			if(Balance < 0)
				amount *= 0.9M;
			Balance += amount;
		}
		
		public override void Withdraw(decimal amount)
		{
			Balance -= amount;
		}
	}
}

