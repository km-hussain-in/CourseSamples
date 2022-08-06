//#![allow(warnings, unused)] 

mod console;

fn main() {
  let mut first = input!("First: ", u32);
  let last = input!("Last : ", u32);
  let mut total = 0;
  while first <= last {
  	total += first * first;
  	first += 1;
  }
  println!("Total = {}", total);
}
