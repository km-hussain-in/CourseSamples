#include "series2.h"

namespace Series
{
	double Sequence::Sum(int count)
	{
		double total = 0;

		for(int i = 1; i <= count; ++i)
			total += Next();

		return total;
	}
					
	LinearSequence::LinearSequence(float first, float step)
	{	
		current = first; 
		difference = step; 
	}

	double LinearSequence::Next()
	{
		double result = current;
		current += difference;
		return result;
	}

	double LinearSequence::Seek(int term)
	{
		return current += difference * (term - 1);
	}

	PowerSequence::PowerSequence(float multiplier)
	{
		current = 1;
		ratio = multiplier; 
	}

	double PowerSequence::Next()
	{
		double result = current;
		current *= ratio;
		return result;
	}
}


