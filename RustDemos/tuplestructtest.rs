//#![allow(warnings, unused)] 

mod console;

struct AP(f64, f64);

impl AP{
	fn next(&mut self) -> f64 {
	    let result = self.0;
		self.0 += self.1;
		result
	}
}

fn sum(mut items: AP, count: u32) -> f64 {
    let mut total = 0.0;
	for _ in 0 .. count {
		total += items.next();
	}
	total
}

fn main() {
    let n = input!("Number of terms: ", u32);
    let ap = AP(1.0, 2.0);
    println!("Arithmetic Sum = {}", 
        sum(ap, n));
}
