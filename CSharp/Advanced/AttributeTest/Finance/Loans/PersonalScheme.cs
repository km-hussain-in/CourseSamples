namespace Finance.Loans
{
	public class PersonalScheme
	{	
		public float Common(double amount, int years) => 10 + 0.25f * years;
		
		public float Employees(double amount, int years) => 8 + 0.2f * years;
	}
}

