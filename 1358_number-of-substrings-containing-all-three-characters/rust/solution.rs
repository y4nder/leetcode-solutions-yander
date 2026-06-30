#[cfg(feature = "harness")]
pub struct Solution;

impl Solution {
    pub fn number_of_substrings(s: String) -> i32 {
        let mut last = [-1, -1, -1];

        let mut count = 0;

        for r in 0..s.len() {
            last[s.as_bytes()[r] as usize - 'a' as usize] = r as i32;

            let min_last = if last[0] < last[1] {
                if last[0] < last[2] {
                    last[0]
                } else {
                    last[2]
                }
            } else {
                if last[1] < last[2] {
                    last[1]
                } else {
                    last[2]
                }
            };

            if min_last != -1 {
                count += min_last + 1;
            }
        }

        count
    }
}
