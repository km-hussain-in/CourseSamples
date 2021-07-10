#include <iostream>


class Banner
{
public:

	void Resize(float l, float b) //void Banner::Resize(Banner* this, float l, float b)
	{
		length = l; //this->length = l;
		breadth = b; //this->breadth = b;
	}

	double Area() const //double Banner::Area(const Banner* this);
	{
		return length * breadth - 0.86 * radius * radius;
		//return this->length * this->breadth - 0.86 * this->radius * this->radius
	}

	//parametrized constructor which is also default constructor because its parameters
	//are declared with their default arguments
	Banner(float l=80, float b=25, float r=0)
	{
		length = l;
		breadth = b;
		radius = r;
		std::cout << "Banner instance initialized" << std::endl;
	}
	//Banner(90, 35, 1)
	//Banner(90, 35) => Banner(90, 35, 0)
	//Banner(90) => Banner(90, 25, 0)
	//Banner() => Banner(80, 25, 0)

	//destructor - special member function which is called automatically before
	//the instance is removed from the memory
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


//reference type (T&) - it is a higher level equivalent of a pointer type (T*) which automatically
//(1) addresses its assigned value without requiring address of (&) operator
//(2) indirects to its addressed value without requiring dereferencing (*) operator
double BannerPrice(const Banner& info)
{
	double area = info.Area(); //(*info).Area() === info->Area()
	float rate = area < 100 ? 6.75 : 8.25;

	//info.Resize(0, 0);
	return rate * area;
}

int main(void)
{
	Banner mybanner; //creating an instance of Banner (on stack) using default constructor
	std::cout << "Price of my banner = "
		  << BannerPrice(mybanner) //BannerPrice(&mybanner)
		  << std::endl;
	
	float w, h;
	std::cout << "Dimensions of your banner: ";
	std::cin >> w >> h;
	Banner yourbanner(w, h, 1); //creating an instance of banner (on stack) using parameterized constructor
	std::cout << "Price of your banner = "
		  << BannerPrice(yourbanner) //BannerPrice(&yourbanner)
		  << std::endl;
}


