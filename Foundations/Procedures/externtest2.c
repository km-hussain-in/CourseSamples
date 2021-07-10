#include <stdio.h>

extern int CountPrimes(long, long); 

int main(void)
{
	long lower, upper;
	printf("Lower and Upper Limit: ");
	scanf("%ld%ld", &lower, &upper);

	printf("Number of Primes = %d\n", CountPrimes(lower, upper));

}

