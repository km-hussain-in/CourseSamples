import java.util.Scanner;
import java.util.concurrent.Callable;
import java.util.concurrent.Executors;

class Computation implements Callable<Long> {

	private int first, last;

	public Computation(int first, int last) {
		this.first = first;
		this.last = last;
	}

	public Long call() {
		long result = 0;
		for(int n = first; n <= last; ++n)
			result += Worker.doWork(n);
		return result;
	}
}

class AsyncTest {

	public static void main(String[] args) throws Exception {
		var pool = Executors.newFixedThreadPool(2); //create pool of 2 worker threads
		var input = new Scanner(System.in);
		System.out.print("First Limit : ");
		int m = input.nextInt();
		var c1 = new Computation(1, m);
		//var r1 = c1.call();
		var r1 = pool.submit(c1); //make a worker thread execute c1.call
		System.out.print("Second Limit: ");
		int n = input.nextInt();
		var c2 = new Computation(m + 1, n);
		//var r2 = c2.call();
		var r2 = pool.submit(c2); //make another worker thread execute c2.call
		System.out.print("Computing");
		while(!(r1.isDone() && r2.isDone())){
			System.out.print(".");
			System.out.flush();
			Thread.sleep(300); //pause for 300 milliseconds
		}
		System.out.println("Done!");
		//var r = r1 + r2;
		var r = r1.get() + r2.get();
		System.out.printf("Result = %d%n", r);
		pool.shutdown(); //kill the worker threads
	}
}

