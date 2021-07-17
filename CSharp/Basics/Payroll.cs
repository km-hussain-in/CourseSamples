namespace Payroll
{
	public class Employee 
	{
		private int hours;
		private float rate;
		private int id;
		static int count;

		public Employee(int h, float r)
		{
			hours = h;
			rate = r;
			id = 101 + count++;
		}

		public Employee() : this(0, 50) {}

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

		public virtual double Income()
		{
			double amount = hours * rate;
			int ot = hours - 180;
			if(ot > 0)
				amount += 50 * ot;
			return amount;
		}

		public static int CountInstances()
		{
			return count;
		}
	}

	public class SalesPerson : Employee
	{
		public double Sales { get; set; }

		public SalesPerson(int h, float r, double s) : base(h, r)
		{
			Sales = s;
		}

		public override double Income()
		{
			double amount = base.Income();
			if(Sales >= 10000)
				amount += 0.05 * Sales;
			return amount;
		}
	}
	
}

