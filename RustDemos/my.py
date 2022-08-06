def fib_fetch(n):
	if n > 1:
		return fib_fetch(n - 1) + fib_fetch(n - 2)
	else:
		return n
		
