#include "banner1.h"
#include <stdio.h>

int main(void)
{
	Banner mybanner = {}; //mybanner identifies an instance of Banner type with width and height initialized to zero
	float w, h;
	printf("Banner Dimensions: ");
	scanf("%f%f", &w, &h);
	//printf("Banner Price = %.2lf\n", BannerPrice(w, h));
	
	mybanner.width = w;
	mybanner.height = h;
	printf("Banner Price = %.2lf\n", BannerPrice(mybanner));
}

