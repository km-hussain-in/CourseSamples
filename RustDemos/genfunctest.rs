//#![allow(warnings, unused)] 

mod console;

fn select<T>(key: i8, first: T, second: T) -> T {
	if key % 2 == 0 {
		first
	}else{
		second
	}
}

fn main() {
  let s = input!("Selector: ", i8);
  let sa = select(s, 23, 34);
  println!("Selected age is {}", sa);
  let sw = select(s, 73.4, 68.5);
  println!("Selected weight is {}", sw);
  let sn = select(s, "Jack", "Jill");
  println!("Selected name is {}", sn);	
}
