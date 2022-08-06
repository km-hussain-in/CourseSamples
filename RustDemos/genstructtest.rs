//#![allow(warnings, unused)] 

struct Pair<T> {
	first: T,
	second: T,
}

impl<T> Pair<T> {
	fn select(self, count: i32) -> T {
		if count % 2 == 0 {
			self.first
		}else{
			self.second
		}
	}
}

fn main() {
  let a = Pair {first: 34, second: 45};
  println!("Selected age: {}", a.select(8)); 
  let w = Pair {first: 68.4, second: 74.8};
  println!("Selected weight: {}", w.select(11)); 
  let n = Pair {first: "Jack", second: "Jill"};
  println!("Selected name: {}", n.select(8)); 
}
