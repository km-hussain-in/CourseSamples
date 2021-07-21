namespace Banking
{
	public abstract class Account
	{
		public long Id { get; internal set; }

		public decimal Balance { get; protected set; }

		public abstract void Deposit(decimal amount);
	
		public abstract void Withdraw(decimal amount);

		public bool Transfer(decimal amount, Account that)
		{
			if(ReferenceEquals(this, that))
				return false;
			this.Withdraw(amount);
			that.Deposit(amount);
			return true;
		}
	}
}

