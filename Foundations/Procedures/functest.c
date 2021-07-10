#include <stdio.h>

long Summation(int count)
{
	return count * (count + 1) / 2;
}

int main(void)
{
	int lower, upper;
	long total = 0;

	printf("Lower Limit: ");
	scanf("%d", &lower);
	printf("Upper Limit: ");
	scanf("%d", &upper); 

	if(lower < upper)
	{
		total = Summation(upper) - Summation(lower - 1);
		printf("Sum of Positive Integers = %ld\n", total);
	}
	else
	{
		printf("ERROR: Invalid range!\n");
	}
}

