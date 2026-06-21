```rust
  pub fn max_ice_cream(costs: Vec<i32>, coins: i32) -> i32 {
      let max = match costs.iter().max() {
          Some(&m) => m as usize,
          None => return 0,
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
```
