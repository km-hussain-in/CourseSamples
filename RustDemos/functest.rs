//#![allow(warnings, unused)] 

mod console;

fn employee_income(hours: u16, rate: f32) -> f64 {
	let mut h = hours as f64;
	let r = rate as f64;
	if h > 40.0 {
		h += h - 40.0;
	}
	r * h //return r * h;
}

fn main() {
    let nh = input!("Number of hours: ", u16);
    let hr = input!("Hourly rate: ", f32);
    println!("Weekly income = {:.2}", 
        employee_income(nh, hr));
}
