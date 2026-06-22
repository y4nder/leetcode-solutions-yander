use std::cmp;

#[cfg(feature = "harness")]
pub struct Solution;

impl Solution {
    pub fn max_number_of_balloons(text: String) -> i32 {
        let max_letters = 26;
        let to_find = "balloon";
        let mut s_count = vec![0; max_letters];
        let mut target_count = vec![0; max_letters];

        for c in text.chars() {
            s_count[c as usize - 'a' as usize] += 1;
        }

        for c in to_find.chars() {
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

