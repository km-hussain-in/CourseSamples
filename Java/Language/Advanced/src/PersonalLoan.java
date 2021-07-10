package finance;

@MaxDuration //@MaxDuration(value=4)
public class PersonalLoan {

	public float common(double amount, int years) {
		return 10 + 0.25f * years;
	}

	public float employee(double amount, int years) {
		return 8 + 0.15f * years;
	}
}

