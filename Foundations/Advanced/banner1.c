#include "banner1.h"

/*
double BannerPrice(float width, float height)
{
	double area;
	float rate;

	area = width * height;
	rate = area < 100 ? 6.75 : 8.25;

	return rate * area;
}
*/

double BannerPrice(Banner info)
{
	double area;
	float rate;

	area = info.width * info.height;
	rate = area < 100 ? 6.75 : 8.25;

	return rate * area;
}

