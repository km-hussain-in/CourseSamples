#include <iostream>

extern "C" int CountPrimes(long, long); //this function is implemented in C (no name mangling)

int main(void)
{
	long lower, upper;
	std::cout << "Lower and Upper Limit: ";
	std::cin >> lower >> upper;

	std::cout << "Number of Primes = "
		  << CountPrimes(lower, upper)
		  << std::endl;
}

