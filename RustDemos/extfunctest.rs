mod console;

extern "C" {
	fn gcd(m: u64, n: u64) -> u64;
}

fn main() {
	let a = input!("Positive Integer (1/2): ", u64);
	let b = input!("Positive Integer (2/2): ", u64);
	unsafe {
		println!("G.C.D = {}", gcd(a, b));
	}
}

//as -o libgcd.a gcd.s
//rustc extfunctest.rs -L. -lgcd
