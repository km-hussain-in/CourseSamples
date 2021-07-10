class MethodTest2 {

	private static double income(double invest, short years, boolean risk) {
		double rate = risk ? 7.5 : 6.0;
		double amount = invest * Math.pow(1 + rate / 100, years);
		return amount - invest;
	}

	//overloading income method
	private static double income(double invest, short years) {
		return income(invest, years, false);
	}

	public static void main(String[] args) {
		double i = Double.parseDouble(args[0]);
		short y = Short.parseShort(args[1]);
		System.out.printf("Income in Silver scheme = %.2f%n", income(i, y));
		System.out.printf("Income in Gold scheme = %.2f%n", income(i, y, true));
	}
}

//java MethodTest2 "4999.99" "3"
