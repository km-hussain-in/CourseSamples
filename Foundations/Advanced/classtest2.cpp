#include <iostream>

class Banner
{
public:

	void Resize(float l, float b)
	{
		length = l; 
		breadth = b;
	}

	double Area()
	{
		return length * breadth - 0.86 * radius * radius; 
	}

	//parametrized constructor which is also default constructor because its parameters
	//are declared with their default arguments
	Banner(float l=80, float b=25, float r=0)
	{
		length = l;
		breadth = b;
		radius = r;
	}
	//Banner(90, 35, 1)
	//Banner(90, 35) => Banner(90, 35, 0)
	//Banner(90) => Banner(90, 25, 0)
	//Banner() => Banner(80, 25, 0)

private: 
	
	float length;
	float breadth;
	float radius;
};

double BannerPrice(Banner info)
{
	double area = info.Area();
	float rate = area < 100 ? 6.75 : 8.25;

	return rate * area;
}

int main(void)
{
	Banner mybanner; //creating an instance of Banner (on stack) using default constructor
	std::cout << "Price of my banner = "
		  << BannerPrice(mybanner)
		  << std::endl;
	
	float w, h;
	std::cout << "Dimensions of your banner: ";
	std::cin >> w >> h;
	Banner yourbanner(w, h, 1); //creating an instance of banner (on stack) using parameterized constructor
	std::cout << "Price of your banner = "
		  << BannerPrice(yourbanner)
		  << std::endl;
}


