from ctypes import CDLL

lib = CDLL("./libprimes.so")
n = int(input("Upper Limit: "))
print("Number of Primes =", lib.CountPrimes(1, n))


