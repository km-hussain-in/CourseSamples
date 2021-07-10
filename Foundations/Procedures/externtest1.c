#include <stdio.h>

extern long GCD(long, long); //function is implemented in some other module (gcd.o)

int main(void)
{
	long a, b;
	printf("Two Positive Integers: ");
	scanf("%ld%ld", &a, &b);

	printf("G.C.D = %ld\n", GCD(a, b));
}

