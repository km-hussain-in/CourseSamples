//A class defined without an explicit superclass implicitly extends java.lang.Object which is the common root of all reference types in Java
class Interval implements Comparable<Interval> {

	private int min; 
	private int sec; 

	public Interval(int m, int s) {
		min = m + s / 60;
		sec = s % 60;
	}

	public int minutes() { return min; }

	public int seconds() { return sec; }

	public int time() { return 60 * min + sec; }

	//overriding method of java.lang.Object to return the string representation of the state of this object
	public String toString() {
		if(sec < 10)
			return min + ":0" + sec;
		return min + ":" + sec;
	}

	//overriding method of java.lang.Object to return same integer value for all objects with matching states
	public int hashCode() {
		return min + sec;
	}

	//overriding method of java.lang.Object to return true only is this object and other object are of same class and have matching state
	public boolean equals(Object other) {
		if(other instanceof Interval){
			Interval that = (Interval) other;
			return (this.min == that.min) && (this.sec == that.sec);
		}
		return false;
	}

	public int compareTo(Interval that) {
		return this.time() - that.time();
	}
}


