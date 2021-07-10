import finance.MaxDuration;
import java.lang.reflect.Method;

class AnnotationTest {

	public static void main(String[] args) throws Exception {
		double p = Double.parseDouble(args[0]);
		Class<?> c = Class.forName(args[1]);
		Method category = c.getMethod(args[2], double.class, int.class);
		Object scheme = c.getConstructor().newInstance();
		int rows = 5;
		if(c.isAnnotationPresent(MaxDuration.class)){
			MaxDuration md = c.getAnnotation(MaxDuration.class);
			rows = md.value();
		}
		for(int n = 1; n <= rows; ++n){
			float r = (float) category.invoke(scheme, p, n); //late binding
			float i = r / 1200;
			int m = 12 * n;
			double emi = p * i / (1 - Math.pow(1 + i, -m));
			System.out.printf("%d\t%.2f%n", n, emi);
		}
	}
}



