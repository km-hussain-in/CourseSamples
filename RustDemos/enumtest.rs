//#![allow(warnings, unused)] 

mod console;

enum Figure {
	Triangle,
	Quadrilateral,
	Polygon(u32),
}


fn angle(shape: Figure) -> f32 {
	match shape {
		Figure::Triangle => 60.0,
		Figure::Quadrilateral => 90.0,
		Figure::Polygon(sides) => 
			180.0 * (1.0 - 2.0 / sides as f32)
	}
}

fn main() {
    let n = input!("Number of sides: ", u32);
    println!("Angle of triangle = {}", 
        angle(Figure::Triangle));
    println!("Angle of quadrilateral = {}", 
        angle(Figure::Quadrilateral));
    println!("Angle of polygon = {:.2}", 
        angle(Figure::Polygon(n)));
}
