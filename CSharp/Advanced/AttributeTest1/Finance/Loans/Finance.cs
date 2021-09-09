namespace Finance
{
	using System; 

	[AttributeUsage(AttributeTargets.Method)]
	public class MaxDurationAttribute : Attribute
	{
		public int Limit { get; set; }

		public MaxDurationAttribute(int value=5) => Limit = value;
	}

	public class EducationLoan
	{
		[MaxDuration]
		public float GetInterestRate(double amount, int years) => 6.5f;
	}

	public class PersonalLoan
	{	
		public float GetInterestRate(double amount, int years) => 10 + 0.25f * years;
		
		public float GetInterestRateForEmployees(double amount, int years) => 8 + 0.2f * years;
	}

	public class HomeLoan
	{
		[MaxDuration(12)]
		public float GetInterestRate(double amount, int years) => amount < 5000000 ? 9.0f : 8.5f;
	
		[MaxDuration(Limit=15)]
		public float GetInterestRateForWomen(double amount, int years) => GetInterestRate(amount, years) - 1;
	}

}

