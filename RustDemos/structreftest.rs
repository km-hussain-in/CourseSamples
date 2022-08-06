//#![allow(warnings, unused)] 

mod console;

struct Employee {
	hours: u16,
	rate: f32,
	sales: f64,
}

fn employee_new(work: u16, pay: f32) -> Employee {
	Employee {hours: work, rate: pay, sales: 0.0}
}

fn employee_income(me: &Employee) -> f64 {
	let mut h = me.hours as f64;
	let r = me.rate as f64;
	if h > 40.0 {
		h += h - 40.0;
	}
	r * h + 0.05 * me.sales
}

fn employee_sell(me: &mut Employee, amount: f64) {
	me.sales += amount;
}

fn main() {
    let nh = input!("Number of hours: ", u16);
    let hr = input!("Hourly rate: ", f32);
    let mut emp = employee_new(nh, hr);
    println!("Weekly income = {:.2}", 
        employee_income(&emp));
    employee_sell(&mut emp, 8500.0);
    println!("Weekly income with commission = {:.2}", 
        employee_income(&emp));
}
