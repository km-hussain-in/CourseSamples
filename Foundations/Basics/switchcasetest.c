#include <stdio.h>

int main(void)
{
	short age; 
	float amount;

	printf("Age: ");
	scanf("%hd", &age);

	switch(age)
	{
	case 16:
		amount = 60;
		break;
	case 18:
		amount = 70;
		break;
	case 21:
		amount = 100;
		break;
	case 50:
		amount = 120;
		break;
	default:
		amount = 50;
	}

	printf("Gift Amount = %f\n", amount * age);
}



