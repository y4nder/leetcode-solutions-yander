#[cfg(feature = "harness")]
pub struct Solution;

impl Solution {
    pub fn largest_altitude(gain: Vec<i32>) -> i32 {
        let mut max = 0;
        let mut altitude = 0;

        for g in gain {
            altitude += g;
            if max < altitude {
                max = altitude;
            }
        }

        max
    }
}

