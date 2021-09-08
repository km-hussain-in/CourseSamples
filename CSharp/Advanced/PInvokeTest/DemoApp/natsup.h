#include <string.h>

#ifndef NATSUP_H
#define NATSUP_H

long long GCD(long long, long long);

int ReverseString(const char*, char*);

typedef struct {
	int begin;	
	int end;
} Range;

typedef float (*Sequence)(int);

double SequenceSum(Sequence, const Range*);

#endif

