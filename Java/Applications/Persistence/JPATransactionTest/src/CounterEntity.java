package shopping;

public class CounterEntity implements java.io.Serializable {

	private String counterName;

	private int currentValue;

	public int getNextValue() {
		return ++currentValue;
	}
}

