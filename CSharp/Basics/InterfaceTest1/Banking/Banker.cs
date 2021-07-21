namespace Banking
{
	public static class Banker
	{
		private static long nid = System.DateTime.Now.Ticks % 1000000;

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
	}
}

