#include "banner2.h"


//accept an argument of a user-defined structured type by address (instead of value to avoid unnecessary copying of data) 
//using a parameter declared with const qualifier (to indicate that the addressed data will be treated as a read-only object)   
double BannerPrice(const Banner* info)
{
	double area;
	float rate;

	switch(info->shape) // (*info).shape
	{
	case Rectangular:
		area = info->width * info->height;
		break;
	case Triangular:
		area = 0.5 * info->width * info->height;
		break;
	case Elliptical:
		area = (3.14 / 4) * info->width * info->height;
		break;
	}

	//info->shape = Rectangular;

	rate = area < 100 ? 6.75 : 8.25;

	return rate * area;
}


int BannerPrint(Banner info)
{
	info.shape = Rectangular;
	//code for printing info.text in a region of info.shape with info.width and info.height
	return 1;
}

