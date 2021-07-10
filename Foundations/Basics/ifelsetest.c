#include <stdio.h>

int main(void)
{
	int lower, upper;
	long total;

	printf("Lower Limit: ");
	scanf("%d", &lower);
	printf("Upper Limit: ");
	scanf("%d", &upper); 

	if(lower < upper)
	{
		total = upper * (upper + 1) / 2 - (lower - 1) * lower / 2;
		printf("Sum of Positive Integers = %ld\n", total);
	}
	else
	{
		printf("ERROR: Invalid range!\n");
	}
}

