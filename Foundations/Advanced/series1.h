namespace Series
{
	class Sequence
	{
	public:
		//enable virtual dispatch for Next
		virtual double Next()
		{
			return 1;
		}
	};

	//LinearSequence can substitute Sequence in any code
	class LinearSequence : public Sequence
	{
	public:
		LinearSequence(float, float);
		double Next();
	private:
		float current;
		float difference;
	};

	//PowerSequence can substitute Sequence in any code
	class PowerSequence : public Sequence
	{
	public:
		PowerSequence(float);
		double Next();
	private:
		double current;
		float ratio;
	};
}


