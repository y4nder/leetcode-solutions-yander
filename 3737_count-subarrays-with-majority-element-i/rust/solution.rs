#[cfg(feature = "harness")]
pub struct Solution;

impl Solution {
    pub fn count_majority_subarrays(nums: Vec<i32>, target: i32) -> i32 {
        let score: Vec<i32> = nums
            .iter()
            .map(|&n| if n == target { 1 } else { -1 })
            .collect();

        let mut prefix_sums = vec![0; score.len() + 1];

        for i in 1..=nums.len() {
            prefix_sums[i] = prefix_sums[i - 1] + score[i - 1];
        }

        let mut count = 0;

        for l in 0..prefix_sums.len() {
            for r in l + 1..prefix_sums.len() {
                if prefix_sums[r] > prefix_sums[l] {
                    count += 1;
                }
            }
        }

        count
    }
}

