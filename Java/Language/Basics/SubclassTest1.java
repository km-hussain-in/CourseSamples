class SubclassTest1 {

	private static double tax(payroll.Employee emp) {
		double i = emp.income(); //calling income method of Employee class on object referred by emp
		return i > 10000 ? 0.15 * (i - 10000) : 0;
	}

	public static void main(String[] args) {
		var jack = new payroll.Employee(); //var will be inferred from the initializer (rhs)
		jack.setHours(186);
		jack.setRate(52);
		System.out.printf("Jack's ID is %d, INCOME is %.2f and TAX is %.2f%n", jack.getId(), jack.income(), tax(jack));
		var jill = new payroll.SalesPerson(186, 52, 48000);
		System.out.printf("Jill's ID is %d, INCOME is %.2f and TAX is %.2f%n", jill.getId(), jill.income(), tax(jill));
	}
}

