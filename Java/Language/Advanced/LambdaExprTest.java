interface InterestRate {
	float forPeriod(int duration);
}

class Investment {

	private double amount;
	private int years;

	public Investment(double amount, int years) {
		this.amount = amount;
		this.years = years;
	}

	public double income(InterestRate rate) {
		float r = rate.forPeriod(years);
		double cash = amount * Math.pow(1 + r / 100, years);
		return cash - amount;
	}
}


class LambdaExprTest {

	public static void main(String[] args) {
		var input = new java.util.Scanner(System.in);
		System.out.print("Amount and Duration: ");
		double p = input.nextDouble();
		int n = input.nextInt();
		var inv = new Investment(p, n);
		System.out.printf("Income in Gold scheme: %.2f%n", inv.income(y -> 8 + 0.1f * y)); //passing lambda expression: (arguments) -> expression_to_evaluate
		System.out.printf("Income in Silver scheme: %.2f%n", inv.income(y -> y < 3 ? 6 : 7)); 
	}
}

