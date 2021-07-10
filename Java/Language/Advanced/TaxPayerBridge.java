class TaxPayerBridge {

	private double income;

	public TaxPayerBridge(double income){
		this.income = income;
	}

	public boolean validate(short age){
		return age >= 18 && age < 100;
	}

	public native double getIncomeTax(short age);

	static{
		System.loadLibrary("tpbsup");
	}

}

