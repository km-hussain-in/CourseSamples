namespace Finance.Loans
{
	public class HomeScheme				
	{
		[MaxDuration(12)]
		public float Common(double amount, int years) => amount < 5000000 ? 9.0f : 8.5f;
	
		[MaxDuration(Limit=15)]
		public float Women(double amount, int years) => Common(amount, years) - 1;
	}

}

