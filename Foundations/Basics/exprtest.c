#include "console.h"

//a global variable that identifies a 64-bit(long long) integer(int) value initialized to zero
long long int upper = 0;

int main(void)
{
	//a local variable that identifies a 64-bit integer value currently uninitialized
	long long int total;

	upper = GetInt("Upper Limit: ");
	total = upper * (upper + 1) / 2; // expression
	PutInt("Sum of Integers = ", total);
}


