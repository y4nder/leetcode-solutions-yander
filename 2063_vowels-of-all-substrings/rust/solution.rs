#[cfg(feature = "harness")]
pub struct Solution;

impl Solution {
    pub fn count_vowels(word: String) -> i64 {
        let n = word.len();
        let mut total: i64 = 0;

        fn exists(character: char) -> bool {
            match character {
                'a' | 'e' | 'i' | 'o' | 'u' => true,
                _ => false,
            }
        }

        for i in 0..n {
            if exists(word.as_bytes()[i] as char) {
                total += ((i + 1) as i64) * ((n - i) as i64);
            }
        }

        total
    }
}
