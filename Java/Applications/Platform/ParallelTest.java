import java.util.stream.IntStream;

class ParallelTest {

	public static void main(String[] args) throws Exception {
		int n = args.length > 0 ? Integer.parseInt(args[0]) : 10;
		long t1 = System.currentTimeMillis();
		long r = IntStream.range(1, n + 1)
				.parallel()
				.mapToLong(Worker::doWork)
				.sum();
		long t2 = System.currentTimeMillis();
		System.out.printf("Result = %d, computed in %.3f sec.%n", r, (t2 - t1) / 1000.0);
	}
}

