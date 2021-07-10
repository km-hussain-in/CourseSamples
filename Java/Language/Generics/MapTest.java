import java.util.*;

class MapTest {

	public static void main(String[] args) {
		var store = //new HashMap<String, Interval>();
			    new TreeMap<String, Interval>(); 
		store.put("Monday", new Interval(5, 41));
		store.put("Tuesday", new Interval(7, 32));
		store.put("Wednesday", new Interval(4, 13));
		store.put("Thursday", new Interval(6, 54));
		store.put("Friday", new Interval(3, 25));
		store.put("Monday", new Interval(2, 41));
		if(args.length > 0) {
			Interval val = store.get(args[0]);
			if(val != null)
				System.out.println(val);
			else
				System.out.println("No such key!");
		}else{
			for(var i : store.entrySet())
				System.out.printf("%-16s%s%n", i.getKey(), i.getValue());
		}
	}
}



