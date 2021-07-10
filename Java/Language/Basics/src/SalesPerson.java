package payroll;

//subclassing
public class SalesPerson extends Employee {

	private double sales;

	public SalesPerson(int h, float r, double s) {
		super(h, r); //calling superclass (Employee) constructor
		sales = s;
	}

	public double getSales() { return sales; }

	//overriding superclass method
	public double income() {
		double amount = super.income(); // calling method from superclass
		if(sales >= 10000)
			amount += 0.05 * sales;
		return amount;
	}
}

