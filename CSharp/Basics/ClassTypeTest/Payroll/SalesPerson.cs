namespace Payroll
{
	public class SalesPerson : Employee
	{
		public double Sales { get; set; }

		public SalesPerson(int hours, float rate, double sales) : base(hours, rate)
		{
			Sales = sales;
		}

		public override double GetIncome()
		{
			double commission = Sales >= 20000 ? 0.05 * Sales : 0;
			return base.GetIncome() + commission;
		}
	}
}

