#include "series1.h"

namespace Series
{
					
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


