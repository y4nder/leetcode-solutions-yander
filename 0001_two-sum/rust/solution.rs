use std::collections::HashMap;

#[cfg(feature = "harness")]
pub struct Solution;

impl Solution {
    pub fn two_sum(nums: Vec<i32>, target: i32) -> Vec<i32> {
        let mut map = HashMap::new();
        for (i, &val) in nums.iter().enumerate() {
            let complement = target - val;
            if let Some(&j) = map.get(&complement) {
                return vec![j as i32, i as i32];
            }
            map.insert(val, i);
        }
        vec![]
    }
}
