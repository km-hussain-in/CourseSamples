class AutoBoxTest {

	/*
	private static String select(int count, String first, String second) {
		if((count % 2) == 1)
			return first;
		return second;
	}

	private static double select(int count, double first, double second) {
		if((count % 2) == 1)
			return first;
		return second;
	}
	*/

	//recurring code pattern 
	private static Object select(int count, Object first, Object second) {
		if((count % 2) == 1)
			return first;
		return second;
	}

	public static void main(String[] args) {
		/*
		double v = 9.75;
		Double w = v; //Double.valueOf(v) //boxing
		double x = w; //w.doubleValue() //unboxing
		Object y = x; //Double.valueOf(x)
		double z = (double)y; //((Double)y).doubleValue() 
		*/
		int n = Integer.parseInt(args[0]);
		//String ss = select(n, "Monday", "Friday");
		String ss = (String)select(n, "Monday", "Friday"); //implicit conversion for arguments and explicit conversion for result 
		System.out.printf("Selected String = %s%n", ss);
		//double sd = select(n, 3.45, 4.32);
		double sd = (double)select(n, 3.45, 4.32); //automatic boxing for arguments and unboxing for result
		System.out.printf("Selected double = %s%n", sd);
		if(n > 50){
			Interval si = (Interval)select(n, new Interval(2, 30), "3:40"); 
			System.out.printf("Selected Interval = %s%n", si);
		}
	}
}

