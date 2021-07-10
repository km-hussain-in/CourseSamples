import java.util.Arrays;

class NativeMethodTest1 {

	private native static long gcd(long first, long second);

	private native static String reverseOf(String text);

	private native static int squareAll(double[] list);

	public static void main(String[] args) {
		System.loadLibrary("nmtsup"); //on UNIX this will load libnmtsup.so which will be searched in 
					      //each directory specified in java.library.path
		switch(args[0]){
			case "gcd":
				long m = Integer.parseInt(args[1]);
				long n = Integer.parseInt(args[2]);
				System.out.println(gcd(m, n));
				break;
			case "reverse":
				String msg = args[1].toLowerCase();
				System.out.println(reverseOf(msg));
				break;
			case "square":
				double[] values = Arrays.stream(args)
							.skip(1)
							.mapToDouble(Double::parseDouble)
							.toArray();
				squareAll(values);
				Arrays.stream(values).forEach(System.out::println);
				break;
		}
	}
}

