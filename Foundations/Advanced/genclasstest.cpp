#include <iostream>
#include <string>

using namespace std;

template <typename TValue>
class Pair //class template with type parameter TValue
{
public:
	void Load(TValue v1, TValue v2)
	{
		first = v1;
		second = v2;
	}

	TValue Select(int count) const
	{
		if(count % 2)
			return first;
		return second;
	}

private:
	TValue first;
	TValue second;
};

int main(void)
{
	int n;
	cout << "Positive Integer: ";
	cin >> n;

	Pair<double> dp; //creating instance of templated Pair class with TValue=double
	dp.Load(3.2, 4.5);
	cout << "Selected double value = " << dp.Select(n) << endl;

	Pair<string> ds; //creating instance of templated Pair class with TValue=string
	ds.Load("Monday", "Friday");
	cout << "Selected string value = " << ds.Select(n) << endl;
}

