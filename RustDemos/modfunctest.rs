//#![allow(warnings, unused)] 

mod console;
mod my;

use my::stat::average;

fn main() {
  let a = input!("First value: ", f64);
  let b = input!("Second value: ", f64);
  //let (c, d) = my::stat::average(a, b);
  let (c, d) = average(a, b);
  println!("Average is {} with a deviation of {}", c, d);
}
