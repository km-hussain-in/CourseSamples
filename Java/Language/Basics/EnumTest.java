enum RiskLevel {
	NONE, LOW, HIGH;
}

class Investment {

	private double amount;
	private short years;
	private RiskLevel risk;

	public Investment(double p, short n) {
		amount = p;
		years = n;
		risk = RiskLevel.NONE;
	}

	public void allowRisk(boolean yes) { 
		risk = yes ? RiskLevel.LOW : RiskLevel.NONE;
	}

	public void adjustRisk(RiskLevel level) {
		risk = level;
	}

	public double income() {
		double rate;
		switch(risk){
			case LOW:
				rate = 7.5;
				break;
			case HIGH:
				rate = 8.5;
				break;
			default:
				rate = 6.0;
		}
		double cash =  amount * Math.pow(1 + rate / 100, years);
		return cash - amount;
	}
}


class EnumTest {

	public static void main(String[] args) {
		double i = Double.parseDouble(args[0]);
		short y = Short.parseShort(args[1]);
		Investment s = new Investment(i, y); 
		System.out.printf("Income in Silver scheme = %.2f%n", s.income());
		Investment g = new Investment(i, y);
		g.allowRisk(true); 
		System.out.printf("Income in Gold scheme = %.2f%n", g.income());
		Investment p = new Investment(i, y);
		p.adjustRisk(RiskLevel.HIGH);
		System.out.printf("Income in Platinum scheme = %.2f%n", p.income());
	}
}

