use std::cmp;

#[cfg(feature = "harness")]
pub struct Solution;

impl Solution {
    pub fn rearrange_characters(s: String, target: String) -> i32 {
        let max_letters = 26;

        let mut s_count = vec![0; max_letters];
        let mut target_count = vec![0; max_letters];

        for c in s.chars() {
            s_count[c as usize - 'a' as usize] += 1;
        }

        for c in target.chars() {
            target_count[c as usize - 'a' as usize] += 1;
        }

        let mut result = i32::MAX;

        for i in 0..max_letters {
            if target_count[i] > 0 {
                result = cmp::min(result, s_count[i] / target_count[i]);
            }
        }

        result
    }
}

