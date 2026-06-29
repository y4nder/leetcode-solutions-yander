#[cfg(feature = "harness")]
pub struct Solution;

impl Solution {
    pub fn search_insert(nums: Vec<i32>, target: i32) -> i32 {
        let mut left = 0;
        let mut right = (nums.len() - 1) as i32;
        let mut mid = (right + left) / 2;

        while left <= right {
            if nums[mid as usize] > target {
                right = mid - 1;
            } else if nums[mid as usize] < target {
                left = mid + 1;
            } else {
                return mid as i32;
            }
            mid = (right + left) / 2;
        }

        if nums[mid as usize] < target {
            mid += 1;
        }

        mid as i32
    }
}

