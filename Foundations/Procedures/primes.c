static int IsPrime(long n) //IsPrime will not be published (as a global function)
{
	register long m;

	if(n < 4)
		return n > 1;

	if((n % 2) == 0)
		return 0;

	for(m = 3; m * m <= n; m += 2)
	{
		if((n % m) == 0)
			return 0;
	}

	return 1;
}

int CountPrimes(long first, long last)
{
	int count = 0;
	register long n;

	for(n = first; n <= last; ++n)
	{
		count += IsPrime(n);
	}

	return count;
}



