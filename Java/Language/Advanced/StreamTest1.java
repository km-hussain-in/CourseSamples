import java.util.Arrays;

class StreamTest1 {

	public static void main(String[] args) {
		int[] nums = {1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
		System.out.println("Squares of odd numbers");
		/*
		for(int n : nums){
			if((n % 2) == 1)
				System.out.println(n * n);
		}
		*/
		Arrays.stream(nums)
			.filter(n -> (n % 2) == 1)
			.map(n -> n * n)
			.forEach(System.out::println);
		int total = Arrays.stream(nums)
				.filter(n -> n > 5)
				.sum();
		System.out.printf("Sum of big numbers = %d%n", total);
	}
}

