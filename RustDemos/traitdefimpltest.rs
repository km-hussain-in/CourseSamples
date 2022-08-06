//#![allow(warnings, unused)] 

mod console;

trait Sequence {
	fn next(&mut self) -> f64;
    fn sum(&mut self, count: u32) -> f64 {
        let mut total = 0.0;
	    for _ in 0 .. count {
		    total += self.next();
	    }
	    total
    }
}

struct AP(f64, f64);

struct GP(f64, f64);

struct Fib(i64, i64);

impl Fib {
    fn new() -> Fib {
        Fib(0, 1)
    }
}

impl Sequence for Fib {
    fn next(&mut self) -> f64 {
        let result = self.0;
        self.0 += self.1;
        self.1 = result;
        result as f64
    }
}



impl Sequence for AP{
	fn next(&mut self) -> f64 {
	    let result = self.0;
		self.0 += self.1;
		result
	}
}

impl Sequence for GP{
	fn next(&mut self) -> f64 {
	    let result = self.0;
		self.0 *= self.1;
		result
	}
}



fn main() {
    let n = input!("Number of terms: ", u32);
    let mut ap = AP(1.0, 2.0);
    println!("Arithmetic Sum = {}", 
        ap.sum(n));
    let mut gp = GP(1.0, 2.0);
    println!("Geometric Sum = {}", 
        gp.sum(n));
    let mut fp = Fib::new();
    println!("Fibonacci Sum = {}", 
        fp.sum(n));
}
