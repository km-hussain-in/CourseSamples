class NativeMethodTest2 {

	public static void main(String[] args) {
		double i = Double.parseDouble(args[0]);
		short a = Short.parseShort(args[1]);
		var emp = new TaxPayerBridge(i);
		try{
			System.out.printf("Income Tax = %.2f%n", emp.getIncomeTax(a));
		}catch(Exception e){
			System.out.println(e);
		}
	}
}

