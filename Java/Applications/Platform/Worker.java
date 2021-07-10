class Worker {

	public static long doWork(int count) {
		long t = System.currentTimeMillis() + 100 * count;
		while(System.currentTimeMillis() < t);
		return count * count;
	}
}

