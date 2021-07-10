class Investment {

	private double amount;
	private short years;
	private boolean risk;

	public Investment(double p, short n) {
		if(p < 10000)
			throw new IllegalArgumentException("Amount must be at least 10000");
		amount = p;
		years = n;
		risk = false;
	}

	public void allowRisk(boolean yes) { 
		risk = yes; 
	}

	public double income() {
		double rate = risk ? 7.5 : 6.0;
		double cash =  amount * Math.pow(1 + rate / 100, years);
		return cash - amount;
	}
}


class ExceptionTest {

	public static void main(String[] args) {
		try{
			double i = Double.parseDouble(args[0]);
			short y = Short.parseShort(args[1]);
			Investment s = new Investment(i, y); 
			System.out.printf("Income = %.2f%n", s.income());
		}catch(ArrayIndexOutOfBoundsException e){
			System.out.println("USAGE: java ExceptionTest amount-value period-value");
		}catch(Exception e){
			System.out.printf("ERROR: %s%n", e.getMessage());
		}
	}
}

