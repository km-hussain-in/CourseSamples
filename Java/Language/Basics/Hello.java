class Greeter {

	public static void main(String[] args) {
		System.out.println("Hello World!");
		for(String name : args) {
			System.out.printf("Welcome %s%n", name);
		}
	}
}


