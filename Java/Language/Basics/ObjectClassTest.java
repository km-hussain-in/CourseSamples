class ObjectClassTest {

	public static void main(String[] args) {
		Interval p = new Interval(4, 8);
		Interval q = new Interval(2, 10);
		Interval r = new Interval(3, 68);
		Interval s = q;
		System.out.printf("Interval p = %s%n", p.toString());
		System.out.printf("Interval q = %s%n", q); //printf automatically calls toString()
		System.out.printf("Interval r = %s%n", r);
		System.out.printf("Interval s = %s%n", s);
		System.out.printf("p is identical to q: %b%n", p == q);
		System.out.printf("p is identical to r: %b%n", p == r);
		System.out.printf("s is identical to q: %b%n", s == q);
		System.out.printf("p is equal to q: %b%n", p.hashCode() == q.hashCode() && p.equals(q));
		System.out.printf("p is equal to r: %b%n", p.hashCode() == r.hashCode() && p.equals(r));
		System.out.printf("s is equal to q: %b%n", s.hashCode() == q.hashCode() && s.equals(q));
	}
}

