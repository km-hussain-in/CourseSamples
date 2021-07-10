#include "console.h"

//variable month identifies an int type value initialized to zero by default
int month;

//variable year identifies an array(by identifying address of its first value) of 64-bit int values
long long year[] = {31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31};

int main(void)
{
	//pointer variable b identifies address of an int type value
	int* b = &month; //mov rbx, offset month
	int c = *b; //mov rcx, [rbx]

	month = GetInt("Month[1-12]: ");
	PutInt("Number of Days = ", year[month - 1]);
}

