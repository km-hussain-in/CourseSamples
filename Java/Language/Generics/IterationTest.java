import java.util.Iterator;

class SimpleStack<V> implements Iterable<V>{

	Node top;

	//inner member class
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

	public Iterator<V> iterator() {
		//creating a new instance of an inner local anonymous class (closure) which implements Iterator<V>
		return new Iterator<V>(){
			
			Node current = top;

			public boolean hasNext() {
				return current != null;
			}

			public V next() {
				V val = current.value;
				current = current.below;
				return val;
			}
		};
	}
}

class IterationTest {

	public static void main(String[] args) {
		String[] a = {"Monday", "Tuesday", "Wednesday", "Thursday", "Friday"};
		for(String s : a)
			System.out.println(s);
		System.out.println();
		for(String s : a)
			System.out.println(s);
		SimpleStack<Interval> b = new SimpleStack<>();
		b.push(new Interval(5, 31));
		b.push(new Interval(4, 12));
		b.push(new Interval(6, 53));
		b.push(new Interval(7, 24));
		b.push(new Interval(3, 45));
		System.out.println();
		for(Interval i : b)
			System.out.println(i);
		System.out.println();
		while(!b.empty())
			System.out.println(b.pop());
	}
}

