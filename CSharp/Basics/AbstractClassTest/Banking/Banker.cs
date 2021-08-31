namespace Banking
{
	public static class Banker
	{
		private static long nid;

		static Banker()
		{
			nid = System.DateTime.Now.Ticks % 1000000;
		}

		public static Account OpenCurrentAccount()
		{
			return new CurrentAccount()
			{
				Id = 100000000L + nid++
			};
		}

		public static Account OpenSavingsAccount()
		{
			return new SavingsAccount()
			{
				Id = 200000000L + nid++
			};
		}

		public static bool Transfer(this Account sender, decimal funds, Account receiver)
		{
			if(ReferenceEquals(sender, receiver))
				return false;
			sender.Withdraw(funds);
			receiver.Deposit(funds);
			return true;
		}
	}
}


