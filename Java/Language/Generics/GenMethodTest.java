class GenMethodTest {


	//type-safe recurring code pattern 
	private static<T> T select(int count, T first, T second) {
		if((count % 2) == 1)
			return first;
		return second;
	}

	public static void main(String[] args) {
		int n = Integer.parseInt(args[0]);
		String ss = select(n, "Monday", "Friday"); //implicit conversion for arguments and explicit conversion for result 
		System.out.printf("Selected String = %s%n", ss);
		double sd = select(n, 3.45, 4.32); //automatic boxing for arguments and unboxing for result
		System.out.printf("Selected double = %s%n", sd);
		if(n > 50){
			//Interval si = select(n, new Interval(2, 30), "3:40"); 
			Interval si = select(n, new Interval(2, 30), new Interval(3, 40)); 
			System.out.printf("Selected Interval = %s%n", si);
		}
	}
}

