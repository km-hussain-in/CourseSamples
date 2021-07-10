package finance;

@MaxDuration(12) //@MaxDuration(value=12)
public class HomeLoan {

	public float common(double amount, int years) {
		return amount < 5000000 ? 9.5f : 8.5f;
	}

	public float woman(double amount, int years) {
		return common(amount, years) - 1;
	}
}

