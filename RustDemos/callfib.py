import my
import time
import ctypes

fib = ctypes.CDLL("./libfib.so")

n = int(input("Term: "))
t = time.time()
#r = my.fib_fetch(n)
r = fib.fetch(n)
t = time.time() - t
print("Result =", r, "computed in", t, "seconds")
