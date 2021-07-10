#include <iostream>

long Compute(int first, int last, short step) //_Z7Computeiis
{
	long result = 0;

	for(int current = first; current <= last; current += step)
	{
		result += current * current;
	}

	return result;
}

//function overloading - redefining a function with different list of parameters
long Compute(int last, short step) //_Z7Computeis
{
	return Compute(1, last, step);
}

int main(void)
{
	using namespace std;

	int lower, upper;
	cout << "Lower and Upper Limit: ";
	cin >> lower >> upper;

	short increment;
	cout << "Increment: ";
	cin >> increment;

	cout << "Your Computation Result = "
	     << Compute(lower, upper, increment) //call _Z7Computeiis
	     << endl;
	cout << "Simple Computation Result = "
	     << Compute(upper, 1) //call _Z7Computeis
	     << endl;
}



