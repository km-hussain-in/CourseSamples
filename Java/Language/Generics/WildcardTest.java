class SimpleStack<V> {

	Node top;

	class Node {
		V value;
		Node below;

		Node(V val) {
			value = val;
			below = top;
		}
	}

	public void push(V val) {
		top = new Node(val);
	}

	public V pop() {
		V val = top.value;
		top = top.below;
		return val;
	}

	public boolean empty() {
		return top == null;
	}

}

class WildcardTest {

	//private static void printStack(SimpleStack<? extends Object> store) {
	private static void printStack(SimpleStack<?> store) {
		for(int i = 0; !store.empty(); ++i){
			if(i > 0) System.out.print(", ");
			System.out.print(store.pop());
		}
		System.out.println();
		//store.push("done");
	}

	public static void main(String[] args) {
		SimpleStack<String> a = new SimpleStack<String>();
		a.push("Monday");
		a.push("Tuesday");
		a.push("Wednesday");
		a.push("Thursday");
		a.push("Friday");
		SimpleStack<Interval> b = new SimpleStack<>();
		b.push(new Interval(5, 31));
		b.push(new Interval(4, 12));
		b.push(new Interval(6, 53));
		b.push(new Interval(7, 24));
		b.push(new Interval(3, 45));
		printStack(a);
		printStack(b);
	}
}

