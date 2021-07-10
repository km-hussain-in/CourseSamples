#include "series1.h"
#include <iostream>
#include <string>

using namespace std;
using namespace Series;

/*
void PresentSequence(string name, LinearSequence& seq, int count)
{
	cout << name << ":";
	for(int i = 1; i <= count; ++i)
		cout << " " << seq.Next();
	cout << endl;
}

void PresentSequence(string name, PowerSequence& seq, int count)
{
	cout << name << ":";
	for(int i = 1; i <= count; ++i)
		cout << " " << seq.Next();
	cout << endl;
}
*/

void PresentSequence(string name, Sequence& seq, int count)
{
	cout << name << ":";
	for(int i = 1; i <= count; ++i)
		cout << " " << seq.Next(); //Next (because it is virtual) will be called using virtual dispatch (from v-table addressed by v-ptr of instance referenced by seq)
	cout << endl;
}


int main(void)
{
	int n;
	cout << "Number of years: ";
	cin >> n;

	LinearSequence s(3, 5);
	PresentSequence("Supply", s, n);

	PowerSequence d(2);
	PresentSequence("Demand", d, n);
}

