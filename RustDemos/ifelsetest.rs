//#![allow(warnings, unused)] 

mod console;

fn main() {
  let length = input!("Length  : ", f32);
  let breadth = input!("Breadth: ", f32);
  if length < breadth {
    let perim = 2.0 * (length + breadth);
    println!("Perimeter = {}", perim);	
  }else{
    let area = length * breadth;
    println!("Area = {}", area);
  }
}
