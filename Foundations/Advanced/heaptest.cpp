#include <iostream>


class Banner
{
public:

	void Resize(float l, float b)
	{
		length = l;
		breadth = b;
	}

	double Area() const
	{
		return length * breadth - 0.86 * radius * radius;
	}

	Banner(float l=80, float b=25, float r=0)
	{
		length = l;
		breadth = b;
		radius = r;
		std::cout << "Banner instance initialized" << std::endl;
	}

	~Banner()
	{
		std::cout << "Banner instance is finalized" << std::endl;
	}
private: 
	
	float length;
	float breadth;
	float radius;
	char text[80];
};


double BannerPrice(const Banner* info)
{
	double area = info->Area();
	float rate = area < 100 ? 6.75 : 8.25;

	return rate * area;
}

int Run(void)
{
	Banner* mybanner = new Banner; //Initializing a new instance of Banner on heap using default constructor
	std::cout << "Price of my banner = "
		  << BannerPrice(mybanner)
		  << std::endl;
	delete mybanner; //explictly removing instance from the heap

	Banner* yourbanner = new Banner(40, 15, 1); //Initializing a new instance of Banner on heap using parameterized constructor 
	std::cout << "Price of your banner = "
		  << BannerPrice(yourbanner)
		  << std::endl;
	delete yourbanner;
}

int main(void)
{
	Run();
}


