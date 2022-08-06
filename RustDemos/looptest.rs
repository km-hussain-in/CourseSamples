mod console;

macro_rules! fast_mul_10 {
	($to: expr) => {
		($to << 1) + ($to << 3)
	};
}

fn main() {
  let num = input!("Positive Integer: ", u32);
  let mut a = 1;
  let b = num;
  let mut c = 0;
  let digits = loop {
  	a = fast_mul_10!(a);
  	c += 1;
  	if a > b {break c;}
  };
  println!("Digit Count = {}", digits);
}