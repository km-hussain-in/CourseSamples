//#![allow(warnings, unused)] 

mod console;

fn main() {
  let calen = [31, 29, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31];
  let m = input!("Month (1-12): ", usize);
  println!("Number of Days = {}", calen[m - 1]);	
}
