#include <stdio.h>

/*
void SwapInt(int* first, int* second)
{
	int third = *first;
	*first = *second;
	*second = third;
}

void SwapDouble(double* first, double* second)
{
	double third = *first;
	*first = *second;
	*second = third;
}
*/

//void type pointer can address value of ANY type
//but it does not support indirection (*, [], ->) to its addressed value
void SwapAny(void* first, void* second, int bytes)
{
	char* p = first;
	char* q = second;
	register int i;

	for(i = 0; i < bytes; ++i)
	{
		char r = p[i];
		p[i] = q[i];
		q[i] = r;
	}
}

int main(void)
{
	int ia = 23, ib = 54;
	double da = 4.5, db = 3.2;

	printf("Original int values = %d, %d\n", ia, ib);
	//SwapInt(&ia, &ib);
	SwapAny(&ia, &ib, 4);
	printf("Swapped int values = %d, %d\n", ia, ib);

	printf("Original double values = %lf, %lf\n", da, db);
	//SwapDouble(&da, &db);
	SwapAny(&da, &db, sizeof(double));
	printf("Swapped double values = %lf, %lf\n", da, db);
}

