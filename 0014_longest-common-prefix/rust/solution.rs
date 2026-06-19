#[cfg(feature = "harness")]
pub struct Solution;

impl Solution {
    pub fn longest_common_prefix(strs: Vec<String>) -> String {
        if strs.is_empty() {
            return "".into();
        }

        let rf = &strs[0];

        for i in 0..rf.len() {
            let c = rf.as_bytes()[i];
            let iter = 1..strs.len();
            for j in iter {
                let curr = &strs[j];
                if i >= curr.len() || curr.as_bytes()[i] != c {
                    return rf[0..i].into();
                }
            }
        }
        rf.into()
    }
}
