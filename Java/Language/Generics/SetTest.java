import java.util.*;

class SetTest {

	//inner nested (static) member class
	static class IntervalComparison implements Comparator<Interval> {
		public int compare(Interval x, Interval y) {
			return x.seconds() - y.seconds(); 
		}
	}

	public static void main(String[] args) {
		var store = //new HashSet<Interval>();
			    //new TreeSet<Interval>();
			    new TreeSet<Interval>(new IntervalComparison());
		store.add(new Interval(5, 41));
		store.add(new Interval(7, 32));
		store.add(new Interval(4, 13));
		store.add(new Interval(6, 54));
		store.add(new Interval(3, 25));
		store.add(new Interval(2, 85));
		for(var i : store)
			System.out.println(i);
	}
}



