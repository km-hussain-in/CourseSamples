package tourism;

import java.util.Date;

public class Visitor implements java.io.Serializable{

	String id;
	private int visitCount;
	private Date lastVisit;
	private transient long currentVisitToken;

	Visitor(String name){
		id = name;
	}

	public final String getId() { return id; }

	public final int getVisitCount() { return visitCount; }

	public final Date getLastVisit() { return lastVisit; }

	public final long getCurrentVisitToken() { return currentVisitToken; }

	public void visit() {
		visitCount += 1;
		lastVisit = new Date();
		currentVisitToken = System.currentTimeMillis() % 1000000;
	}

	static final long serialVersionUID = 1L;
}

