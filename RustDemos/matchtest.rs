//#![allow(warnings, unused)] 

mod console;

fn main() {
  let icode = input!("Item Code (4 digits)  : ", i16);
  if icode < 1000 || icode > 9999 {
    return;
  }
  let qty = input!("Quantity: ", u16);
  let rate = match icode {
  	1111 => 21.95,
  	3333 => 23.95,
  	6666 => 26.95,
  	_ => 20.95
  };
  let amt = rate * qty as f32;
  println!("Payment = {:.2}", amt);
}
