//#![allow(warnings, unused)] 

mod console;

fn main() {
  let count = input!("Count: ", u64);
  let total = count * (count + 1) / 2;
  println!("Total = {}", total);	
}
