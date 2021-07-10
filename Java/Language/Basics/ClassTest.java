class Investment {

	private double amount;
	private short years;
	private boolean risk;

	//parameterized constructor
	public Investment(double p, short n) {
		amount = p;
		years = n;
		risk = false;
	}

	public void allowRisk(boolean yes) { //public static void allowRisk(Investment this, boolean yes)
		risk = yes; //this.risk = yes;
	}

	public double income() {
		double rate = risk ? 7.5 : 6.0;
		double cash =  amount * Math.pow(1 + rate / 100, years);
		return cash - amount;
	}
}


class ClassTest {

	public static void main(String[] args) {
		double i = Double.parseDouble(args[0]);
		short y = Short.parseShort(args[1]);
		Investment s = new Investment(i, y); //activating Investment object
		System.out.printf("Income in Silver scheme = %.2f%n", s.income());
		Investment g = new Investment(i, y);
		g.allowRisk(true); //Investment.allowRisk(g, true);
		System.out.printf("Income in Gold scheme = %.2f%n", g.income());
	}
}

