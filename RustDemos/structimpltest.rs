//#![allow(warnings, unused)] 

mod console;

mod shop {

  pub struct Employee {
	hours: u16,
	rate: f32,
	sales: f64,
  }

  impl Employee {
  
    pub fn new(work: u16, pay: f32) -> Employee {
   	    Employee {hours: work, rate: pay,sales: 0.0}
    }

    pub fn income(&self) -> f64 {
	    let mut h = self.hours as f64;
	    let r = self.rate as f64;
	    if h > 40.0 {
		    h += h - 40.0;
	    }
	    r * h + 0.05 * self.sales
    }

    pub fn sell(&mut self, amount: f64) {
	    self.sales += amount;
    }
  }
}

fn main() {
    let nh = input!("Number of hours: ", u16);
    let hr = input!("Hourly rate: ", f32);
    let mut emp = shop::Employee::new(nh, hr);
    println!("Weekly income = {:.2}", 
        emp.income());
    emp.sell(8500.0);
    //emp.hours += 5;
    println!("Weekly income with commission = {:.2}", 
        emp.income());
}
