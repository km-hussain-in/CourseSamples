import payroll.Employee; //compiler will expand Employee to payroll.Employee
import payroll.SalesPerson;

class SubclassTest2 {

	private static double averageIncome(Employee[] group) {
		double total = 0;
		for(Employee emp : group) {
			total += emp.income(); //invoke emp.class.income
		}
		return total / group.length;
	}

	private static double totalSales(Employee[] group) {
		double total = 0;
		for(Employee emp : group) {
			if(emp instanceof SalesPerson){
				SalesPerson sp = (SalesPerson) emp; //explict conversion (using cast operator) from superclass type to subclass type
				total += sp.getSales();
			}
		}
		return total;
	}

	public static void main(String[] args) {
		Employee[] department = new Employee[5];
		department[0] = new Employee(186, 52); //department[0].class => Employee.class
		department[1] = new Employee(175, 95);
		department[2] = new SalesPerson(190, 60, 65000); //implicit conversion from subclass type to superclass type required by LSP
		department[3] = new Employee(200, 150);
		department[4] = new SalesPerson(165, 45, 35000); //department[4].class => SalesPerson.class 
		System.out.printf("Average income = %.2f%n", averageIncome(department));
		System.out.printf("Total sales = %.2f%n", totalSales(department));
	}
}

