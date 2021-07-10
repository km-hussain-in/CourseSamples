package classic.web.app;

public class CounterBean implements java.io.Serializable {

	private short step = 1;
	private long count = 0;

	public final short getStep() { return step; }
	public final void setStep(short value) { step = value; }

	public synchronized long getNextValue() {
		return count += step;
	}
}

