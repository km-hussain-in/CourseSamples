namespace Banking
{
	sealed class CurrentAccount : Account, IChargeable
	{
		public override void Deposit(decimal amount)
		{
			Balance += amount;
		}
		
		public override void Withdraw(decimal amount)
		{
			Balance -= amount;
		}

		bool IChargeable.Withdraw(decimal rate)
		{
			if(Balance < 0)
			{
				decimal debt = -Balance;
				Withdraw(debt * rate);
				return true;
			}
			return false;
		}

	}
}

