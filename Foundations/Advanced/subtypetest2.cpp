#include "series2.h"
#include <iostream>
#include <string>

using namespace std;
using namespace Series;


void PresentSequence(string name, Sequence& seq, int count)
{
	cout << name << ":";
	for(int i = 1; i <= count; ++i)
		cout << " " << seq.Next(); 
	cout << endl;
}

double Average(Sequence* sq, int count)
{
	LinearSequence* lsq = dynamic_cast<LinearSequence*>(sq); //return zero if sq does not point to instance of LinearSequence
	if(lsq)
	{
		double first = lsq->Seek(1);
		double last = lsq->Seek(count);
		return (first + last) / 2;
	}

	return sq->Sum(count) / count;
}

int main(void)
{
	int n;
	cout << "Number of years: ";
	cin >> n;

	LinearSequence s(3, 5);
	cout << "Average Supply: " << Average(&s, n) << endl;

	PowerSequence d(2);
	cout << "Average Supply: " << Average(&d, n) << endl;
}

