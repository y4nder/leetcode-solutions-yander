use std::io::{self, Read};

mod solution;
use solution::Solution;

fn main() {
    let mut input = String::new();
    io::stdin().read_to_string(&mut input).unwrap();
    let data: Vec<&str> = input.lines().collect();
    let text: String = serde_json::from_str(data[0]).unwrap();
    let result = Solution::max_number_of_balloons(text);
    println!("{}", serde_json::to_string(&result).unwrap());
}
