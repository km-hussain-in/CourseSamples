#include <iostream>

using namespace std;

template <typename T>
void Swap(T& first, T& second) //function template with type parameter T
{
	T third = first;
	first = second;
	second = third;
}

int main(void)
{
	int ia = 23, ib = 54;
	double da = 3.2, db = 4.5;

	cout << "Original int values = " << ia << ", " << ib << endl;
	Swap(ia, ib); //calling templated function with T=int
	cout << "Swapped int values = " << ia << ", " << ib << endl;

	cout << "Original double values = " << da << ", " << db << endl;
	Swap(da, db); //calling templated function with T=double
	cout << "Swapped double values = " << da << ", " << db << endl;
	Swap(db, da); //reusing templated function
	//Swap(ia, da);
}

