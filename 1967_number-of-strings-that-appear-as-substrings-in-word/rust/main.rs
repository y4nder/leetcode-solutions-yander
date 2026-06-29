use std::io::{self, Read};

mod solution;
use solution::Solution;

fn main() {
    let mut input = String::new();
    io::stdin().read_to_string(&mut input).unwrap();
    let data: Vec<&str> = input.lines().collect();
    let patterns: Vec<String> = serde_json::from_str(data[0]).unwrap();
    let word: String = serde_json::from_str(data[1]).unwrap();
    let result = Solution::num_of_strings(patterns, word);
    println!("{}", serde_json::to_string(&result).unwrap());
}
