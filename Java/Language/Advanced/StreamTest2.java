import java.util.ArrayList;

//record type - it is a class that produces immutable value objects (whose state cannot be modified after initialization)
//Java (16 onwards) compiler auto-generates the class for record type which includes
//final fields, a constructor to initialize their values, methods for getting their values
//and overrides for toString, hashCode and equals methods.
record Seller(String name, int sold, int rating) implements Comparable<Seller> {
	public int compareTo(Seller that) {
		return this.name.compareTo(that.name);
	}
}

class StreamTest2 {

	public static void main(String[] args) {
		int min = args.length > 0 ? Integer.parseInt(args[0]) : 0;
		var store = new ArrayList<Seller>();
		store.add(new Seller("Chetan", 3000, 2));
		store.add(new Seller("Bhavin", 6000, 4));
		store.add(new Seller("Akshay", 4000, 5));
		store.add(new Seller("Snehal", 9000, 4));
		store.add(new Seller("Sarika", 5000, 3));
		store.add(new Seller("Harshal", 2000, 1));
		store.stream()
			.filter(s -> s.sold() >= min)
			.sorted()
			.map(s -> s.name() + "\t" + s.sold() + "\t" + "*".repeat(s.rating()))
			.forEach(System.out::println);
	}
}

