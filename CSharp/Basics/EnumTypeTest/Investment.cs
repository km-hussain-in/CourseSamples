enum RiskLevel {None, Low, High}

struct Investment
{
	public readonly double Sum;
	public readonly int Years;
	private RiskLevel risk;

	public Investment(double amount, int duration)
	{
		Sum = amount;
		Years = duration;
		risk = RiskLevel.None;
	}

	public void AllowRisk(bool yes)
	{
		risk = yes ? RiskLevel.Low : RiskLevel.None;
	}

	public void AllowRisk(RiskLevel level)
	{
		risk = level;
	}

	public float Interest()
	{
		float rate;
		switch(risk)
		{
			case RiskLevel.Low:
				rate = 8;
				break;
			case RiskLevel.High:
				rate = 9;
				break;
			default:
				rate = 6;
				break;
		}
		return rate;
	}

}

