//functional interface - an interface which defines exactly one abstract method.
//It can be implemented by the runtime to support implicit conversion from 
//a method reference compatiable (matching return and parameter types) with its abstract method 
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


class MethodRefTest {

	private static float goldScheme(int y) {
		return 8 + 0.1f * y;
	}

	private float silverScheme(int y) {
		return y < 3 ? 6 : 7;
	}

	public static void main(String[] args) {
		var input = new java.util.Scanner(System.in);
		System.out.print("Amount and Duration: ");
		double p = input.nextDouble();
		int n = input.nextInt();
		var inv = new Investment(p, n);
		System.out.printf("Income in Gold scheme: %.2f%n", inv.income(MethodRefTest::goldScheme)); //passing a static method reference
		System.out.printf("Income in Silver scheme: %.2f%n", inv.income(new MethodRefTest()::silverScheme)); //passing an instance (non-static)  method reference
	}
}

