#include <stdio.h>

int main(void)
{
	long num, sum;

	printf("Positive Integer: ");
	scanf("%ld", &num);

	sum = 0;

	while(num) //num != 0
	{
		sum += num % 10; //sum = sum + num % 10;
		num /= 10; //num = num / 10;
	}

	printf("Sum of Digits = %ld\n", sum);
}

