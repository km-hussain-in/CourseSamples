import java.util.*;

class ListTest {

	public static void main(String[] args) {
		var store = //new ArrayList<Interval>();
			    new LinkedList<Interval>();
		store.add(new Interval(5, 41));
		store.add(new Interval(7, 32));
		store.add(new Interval(4, 13));
		store.add(new Interval(6, 54));
		store.add(new Interval(3, 25));
		store.add(new Interval(2, 85));
		for(var i : store)
			System.out.println(i);
		System.out.printf("Third Interval = %s%n", store.get(2));
	}
}



