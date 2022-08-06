//#![allow(warnings, unused)] 

mod console;

trait Sequence {
	fn next(&mut self) -> f64;
}

struct AP(f64, f64);

struct GP(f64, f64);

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

fn sum(items: &mut dyn Sequence, count: u32) -> f64 {
    let mut total = 0.0;
	for _ in 0 .. count {
		total += items.next();
	}
	total
}

fn main() {
    let n = input!("Number of terms: ", u32);
    let mut ap = AP(1.0, 2.0);
    println!("Arithmetic Sum = {}", 
        sum(&mut ap, n));
    let mut gp = GP(1.0, 2.0);
    println!("Geometric Sum = {}", 
        sum(&mut gp, n));
}
