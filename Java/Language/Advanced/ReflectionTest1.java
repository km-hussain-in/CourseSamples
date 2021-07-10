import java.lang.reflect.Field;

record Rectangle(double length, double breadth) {}

record Student(int id, String course, float score, int iq) {}

class ReflectionTest1 {
	/*
	private static void printAsXml(Rectangle obj) {
		System.out.println("<Rectangle>");
		System.out.printf("   <length>%s</length>%n", obj.length());
		System.out.printf("   <breadth>%s</breadth>%n", obj.breadth());
		System.out.println("</Rectangle>");
		System.out.println();
	}

	private static void printAsXml(Student obj) {
		System.out.println("<Student>");
		System.out.printf("   <id>%s</id>%n", obj.id());
		System.out.printf("   <course>%s</course>%n", obj.course());
		System.out.printf("   <score>%s</score>%n", obj.score());
		System.out.println("</Student>");
		System.out.println();
	}
	*/

	private static void printAsXml(Object obj) {
		Class<?> c = obj.getClass();
		System.out.printf("<%s>%n", c.getName());
		for(Field f : c.getDeclaredFields()){
			System.out.printf("  <%s>", f.getName());
			try{
				f.setAccessible(true);
				System.out.print(f.get(obj));
			}catch(Exception e){
				System.out.print(e);
			}
			System.out.printf("</%s>%n", f.getName());
		}
		System.out.printf("</%s>%n", c.getName());
		System.out.println();
	}

	public static void main(String[] args) {
		printAsXml(new Rectangle(5.4, 3.9));
		printAsXml(new Student(13, "Java", 81.5f, 148));
	}
}

