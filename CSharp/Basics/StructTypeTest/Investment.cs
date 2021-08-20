struct Investment
{
	public readonly double Sum;
	public readonly int Years;
	private bool risk;

	public Investment(double amount, int duration)
	{
		Sum = amount;
		Years = duration;
		risk = false;
	}

	public void AllowRisk(bool yes)
	{
		risk = yes;
	}

	public float Interest()
	{
		return risk ? 8 : 6;
	}

}

