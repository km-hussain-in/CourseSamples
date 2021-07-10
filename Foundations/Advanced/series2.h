namespace Series
{
	class Sequence	//Abstract Data Type (ADT) - a class which does not support creation of instances.
			//It is defined specifically for supporting subtypes and has at least one pure virtual function.
	{
	public:
		
		virtual double Next() = 0; //pure (unimplemented) virtual function (will have zero entry in v-table)
		double Sum(int);	
	};

	class LinearSequence : public Sequence
	{
	public:
		LinearSequence(float, float);
		double Next();
		double Seek(int);
	private:
		float current;
		float difference;
	};

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


