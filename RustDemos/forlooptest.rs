//#![allow(warnings, unused)] 

mod console;

fn main() {
  let first = input!("First: ", u32);
  let last = input!("Last : ", u32);
  let mut total: u64 = 0;
  for each in first ..= last {
  	total += (each * each) as u64;
  }
  println!("Total = {}", total);
}
