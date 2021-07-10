interface Consumer {

	void apply(int action);

	default void applyAll(int count) {
		for(int a = 1; a <= count; ++a)
			apply(a);
	}
}

class SomeResource implements Consumer, AutoCloseable {

	private String name;

	static { //static initializer - is invoked once automatically when the class is used for the first time in a program
		System.out.println("SomeResource class initialized.");
	}

	public SomeResource(String id) {
		name = id;
		System.out.printf("Acquired %s resource%n", name);
	}

	public void apply(int action) {
		System.out.printf("Action %d performed on %s resource%n", action, name);
	}

	public void close() {
		System.out.printf("Releasing %s resource%n", name);
	}
}


class InterfaceTest2 {

	private static void run(String info) {
		/*
		var c = new SomeResource("third");
		try{
			c.applyAll(Integer.parseInt(info));
		}finally{
			c.close();
		}
		*/
		try(var c = new SomeResource("third")){
			c.applyAll(Integer.parseInt(info));
		}
	}

	public static void main(String[] args) {
		var a = new SomeResource("first");
		a.apply(1);
		a.close();
		var b = new SomeResource("second");
		b.apply(2);
		b.close();
		try{
			run(args[0]);
		}catch(Exception e){}
	}
}

