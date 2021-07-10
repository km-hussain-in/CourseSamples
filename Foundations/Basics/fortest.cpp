#include <iostream>

int main(void)
{
	int upper;
	std::cout << "Upper Limit: ";
	std::cin >> upper;

	long total = 0;
	for(int current = 1; current <= upper; ++current)
	{
		total += current * current;
	}

	std::cout << "Sum of Squares = " << total << std::endl;
}


