#include <stdio.h>

double Rectangle(float width, float height, double* perim)
{
	*perim = 2 * (width + height);

	return width * height;
}

int main(void)
{
	float l, b;
	double a, p;

	printf("Length and Breadth: ");
	scanf("%f%f", &l, &b);

	a = Rectangle(l, b, &p);

	printf("Area = %.3lf and Perimeter = %.2lf\n", a, p);
}

