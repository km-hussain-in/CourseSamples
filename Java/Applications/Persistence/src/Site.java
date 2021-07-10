package tourism;

import java.util.List;

public class Site implements java.io.Serializable{

	String name;
	private List<Visitor> visitors;

	Site(String name) {
		this.name = name;
		visitors = new java.util.ArrayList<>();
	}

	public final List<Visitor> getVisitors() { return visitors; }

	public Visitor getVisitor(String name) {
		return visitors.stream()
			.filter(v -> v.id.equals(name))
			.findFirst()
			.orElseGet(() -> {
				var visitor = new Visitor(name);
				visitors.add(visitor);
				return visitor;
			});
	}

	static final long serialVersionUID = 1L;
}

