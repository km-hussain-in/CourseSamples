#[export_name = "fetch"]
pub extern fn term(n: u64) -> u64 {
	if n > 1 {
		term(n - 1) + term(n - 2)
	}
	else {
		n
	}
}

//rustc --crate-type=cdylib fib.rs
