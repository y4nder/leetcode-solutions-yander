use std::cmp;

#[cfg(feature = "harness")]
pub struct Solution;

impl Solution {
    pub fn max_ice_cream(costs: Vec<i32>, coins: i32) -> i32 {
        // let a = costs.iter().max();
        // match a {
        //     Some(&max) => {
        //         let mut freq = [0; max + 1];
        //         for cost in costs.iter() {
        //             freq[cost] += 1;
        //         }
        //
        //         let mut count = 0;
        //         let freq_len = freq.len() as i32;
        //         let mut mutable_coins = coins;
        //         for price in 1..freq_len {
        //             if coins < price {
        //                 break;
        //             }
        //
        //             let can_buy = cmp::min(freq[price], coins / price);
        //             count += can_buy;
        //             mutable_coins -= can_buy * price;
        //         }
        //         return mutable_coins;
        //     }
        //     None => 0,
        // }

        let max = match costs.iter().max() {
            Some(&max) => max as usize,
            None => 0,
        };

        let mut freq = vec![0i32; max + 1];
        for &cost in costs.iter() {
            freq[cost as usize] += 1;
        }

        let mut count = 0;
        let mut remaining = coins;
        for price in 1..=(max as i32) {
            if remaining < price {
                break;
            }
            let can_buy = cmp::min(freq[price as usize], remaining / price);
            count += can_buy;
            remaining -= can_buy * price;
        }
        count
    }
}
