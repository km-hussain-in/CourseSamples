//#![allow(warnings, unused)] 

struct ABox {
	length: f32,
	breadth: f32,
	height: f32,
	thickness: f32,
}

fn make_box(l: f32, b: f32, h:f32) -> ABox {
	ABox {length: l, breadth:b, 
	height:h, thickness:0.0}
}

fn box_volume(bx: ABox) -> f32 {
    let ex = 2.0 * bx.thickness;
	(bx.length - ex) * (bx.breadth - ex) * (bx.height - ex)
}

fn main() {
  let mut a = make_box(12.0, 8.0, 7.0);
  a.thickness = 1.0;
  println!("Volume = {}", box_volume(a));
}
