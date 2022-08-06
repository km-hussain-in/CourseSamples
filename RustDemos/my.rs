pub mod stat {
	
	pub fn average(x: f64, y: f64) -> (f64, f64) {
		let a = (x + y) / 2.0;
		let d = if x > y {(x - y) / 2.0} else {(y - x) / 2.0};
		(a, d)
	}
}
