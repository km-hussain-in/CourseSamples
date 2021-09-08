namespace Payroll
{
	public class Employee
	{
		private int hours;
		private float rate;
		private int id;
		private static int count;

		public Employee()
		{
			id = 101 + count++;
		}

		public Employee(int hours, float rate) : this()
		{
			this.hours = hours;
			this.rate = rate;
		}

		public int Hours
		{
			get
			{
				return hours;
			}

			set
			{
				hours = value;
			}
		}

		public float Rate
		{
			get { return rate; }
			set { rate = value; }
		}

		public int Id
		{
			get { return id; }
		}

		public virtual double GetIncome()
		{
			double income = hours * rate;
			int ot = hours - 180;
			if(ot > 0)
				income += 50 * ot;
			return income;
		}

		public static int CountInstances()
		{
			return count;
		}
	}
}

