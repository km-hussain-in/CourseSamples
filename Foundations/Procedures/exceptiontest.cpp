#include <iostream>
#include <string>

long Compute(int first, int last, short step)
{
	long result = 0;

	if(first > last)
		throw std::string("Invalid Range"); //raising exception

	if(step <= 0)
		throw step;

	for(int current = first; current <= last; current += step)
	{
		result += current * current;
	}

	return result;
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

	try
	{
		cout << "Your Computation Result = "
		     << Compute(lower, upper, increment)
		     << endl;
	}
	catch(string msg) //exception handler
	{
		cout << "Error: " <<  msg << endl; 
	}
	catch(short num)
	{
		cout << "Error - Invalid Increment Value: " << num << endl;
	}
}



