#include "banner2.h"
#include <stdio.h>

int main(void)
{
	Banner mybanner = {}; 
	float w, h;
	printf("Banner Dimensions: ");
	scanf("%f%f", &w, &h);
	
	mybanner.width = w;
	mybanner.height = h;
	printf("Rectanglar Banner Price = %.2lf\n", BannerPrice(&mybanner));
	mybanner.shape = Elliptical;
	printf("Elliptical Banner Price = %.2lf\n", BannerPrice(&mybanner));
}

