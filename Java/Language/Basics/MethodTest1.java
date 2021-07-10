class MethodTest1 {

	//variadic method (can be called with different number of arguments)
	private static double average(double first, double second, double... other) {
		double total = first + second;
		for(double value : other)
			total += value;
		return total / (2 + other.length);
	}

	public static void main(String[] args) {
		System.out.printf("Average of two values = %f%n", average(23.7, 19.8));
		System.out.printf("Average of five values = %f%n", average(23.7, 19.8, 31.8, 24.6, 17.4));
	}
}


