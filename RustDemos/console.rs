#![macro_use]
#[allow(unused_macros)]

macro_rules! input {
    ($prompt:expr) => {{
    	print!($prompt);
    	console::read::<String>()
    }};
    ($prompt:expr, $type:ty) => {{
        print!($prompt);
        console::read::<$type>()
    }};
}

pub fn read<T>() -> T 
where T: std::str::FromStr,
T::Err: std::fmt::Debug,
{
    use std::io::Write;
	std::io::stdout().flush().expect("io error");
	let mut line = String::new();
	std::io::stdin().read_line(&mut line).expect("io error");
	line.trim().parse::<T>().expect("bad input")
}

