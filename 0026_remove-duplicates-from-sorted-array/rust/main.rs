use std::io::{self, Read};

mod solution;
use solution::Solution;

fn main() {
    let mut input = String::new();
    io::stdin().read_to_string(&mut input).unwrap();
    let data: Vec<&str> = input.lines().collect();
    let mut nums: Vec<i32> = serde_json::from_str(data[0]).unwrap();
    let result = Solution::remove_duplicates(&mut nums);
    println!("{}", serde_json::to_string(&result).unwrap());
}
