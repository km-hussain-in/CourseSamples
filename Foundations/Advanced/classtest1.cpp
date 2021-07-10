#include <iostream>

class Banner
{
public: //members declared in  this block are visible every where

	void Resize(float l, float b) //void Banner::Resize(Banner* this, float l, float b)
	{
		length = l; //this->length = l;
		breadth = b; //this->breadth = b;
	}

	double Area() //double Banner::Area(Banner* this)
	{
		return length * breadth; //this->length * this->breadth
	}

	//constructor - a special member function whose name matches with the class name
	//implemented to handle initialization of new instances. In C++ a constructor which
	//can be called without explicitly passing any argument is known as the default
	//constructor because it is called automatically
	Banner()
	{
		length = 80;
		breadth = 25;
	}

private: //members declared in this block are only visible within this class
	 //commonly includes variable definitions
	
	float length;
	float breadth;
};

double BannerPrice(Banner info)
{
	double area = info.Area(); //Banner::Area(&info)
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
	Banner yourbanner;
	yourbanner.Resize(w, h); //Banner::Resize(&yourbanner, w, h)
	std::cout << "Price of your banner = "
		  << BannerPrice(yourbanner)
		  << std::endl;
	//mybanner.Resize(30, 50);
}


