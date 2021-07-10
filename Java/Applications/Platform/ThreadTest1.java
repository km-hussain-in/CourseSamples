class ThreadTest1 {

	private static void handleJob(int id, String client) {
		System.out.printf("Accepted job<%d> for client<%s>%n", id, client);
		Worker.doWork(id);
		System.out.printf("Finished job<%d> for client<%s>%n", id, client);
	}

	public static void main(String[] args) {
		int n = args.length > 0 ? Integer.parseInt(args[0]) : 50;
		Thread child = new Thread(() -> {
			handleJob(n, "Jack");
		});
		child.setDaemon(n > 100); //JVM does not wait for a background thread(whose daemon property is true) to exit
		child.start();
		handleJob(60, "Jill");
	}
}

