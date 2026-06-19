# 1. Two Sum

## Problem

Given an array of integers `nums` and an integer `target`, return the **indices** of the two numbers that add up to `target`. You may assume exactly one valid answer exists, and you cannot use the same element twice.

```
Input:  nums = [2, 7, 11, 15], target = 9
Output: [0, 1]   (nums[0] + nums[1] == 9)
```

---

## Approaches

### 1. Brute Force — O(n²) time, O(1) space

Check every pair (i, j) where i < j.

```
nums = [2, 7, 11, 15], target = 9

i=0 (2):
  j=1: 2 + 7  = 9  ✓  → return [0, 1]
  j=2: 2 + 11 = 13
  j=3: 2 + 15 = 17

i=1 (7):
  j=2: 7 + 11 = 18
  j=3: 7 + 15 = 22
...
```

Simple but slow — scans O(n²) pairs in the worst case.

---

### 2. Hash Map (One Pass) — O(n) time, O(n) space  ← optimal

**Key insight:** for each element `num`, the number needed to reach `target` is `complement = target - num`. If the complement was seen earlier, we're done. Otherwise, store `num → index` for future lookups.

#### Step-by-step trace

```
nums = [2, 7, 11, 15],  target = 9

Step 1 — i=0, num=2
  complement = 9 - 2 = 7
  map = {}  →  7 not found
  map.insert(2 → 0)

  map: { 2:0 }

Step 2 — i=1, num=7
  complement = 9 - 7 = 2
  map = {2:0}  →  2 FOUND at index 0
  return [0, 1]  ✓
```

#### Visual walkthrough (array view)

```
index:   0    1    2    3
nums:  [ 2    7   11   15 ]
        ↑
        i=0  →  need 7  →  not in map yet
              ↑
              i=1  →  need 2  →  map has 2 at index 0  →  DONE
```

#### Hash map state evolution

```
         ┌──────────────────────────────────────────┐
         │               HashMap                    │
         │                                          │
i=0 ──▶  │   num:2  complement:7   miss → store 2  │
         │   ┌───────┐                              │
         │   │ 2 → 0 │                              │
         │   └───────┘                              │
         │                                          │
i=1 ──▶  │   num:7  complement:2   HIT  → [0, 1]   │
         │   ┌───────┐                              │
         │   │ 2 → 0 │  ◀── found complement here  │
         │   └───────┘                              │
         └──────────────────────────────────────────┘
```

---

## Why one pass works

We only need to look *backwards*. When we're at index `i`:
- Everything before `i` is already in the map.
- If the complement exists anywhere before `i`, the map holds it.
- If the complement is at some `j > i`, we'll catch it when we reach `j` (the roles reverse: `j` will look back and find `i` in the map).

So we never need a second pass.

---

## Complexity

| Approach   | Time   | Space  |
|------------|--------|--------|
| Brute force | O(n²) | O(1)   |
| Hash map   | O(n)   | O(n)   |

Hash map trades space for time — we pay O(n) extra memory to eliminate the inner loop entirely.

---

## Edge Cases

- **Duplicate values used once:** `[3, 3], target=6` — the first `3` is stored in the map; the second `3` finds it.
  ```
  i=0: complement=3, not in map → store {3:0}
  i=1: complement=3, found at 0 → return [0, 1]  ✓
  ```
- **Negative numbers:** `[-1, -3, 5], target=-4` — works identically; complement arithmetic handles negatives.
- **Large arrays:** O(n) ensures we handle `n=10^4` (LeetCode constraint) trivially.

---

## Solutions

### Rust

```rust
impl Solution {
    pub fn two_sum(nums: Vec<i32>, target: i32) -> Vec<i32> {
        let mut map = std::collections::HashMap::new();
        for (i, &num) in nums.iter().enumerate() {
            let complement = target - num;
            if let Some(&j) = map.get(&complement) {
                return vec![j as i32, i as i32];
            }
            map.insert(num, i);
        }
        unreachable!()
    }
}
```

`unreachable!()` is correct because the problem guarantees exactly one solution exists — the loop must return before exhausting the array.

### TypeScript

```typescript
function twoSum(nums: number[], target: number): number[] {
    const map = new Map<number, number>();
    for (let i = 0; i < nums.length; i++) {
        const complement = target - nums[i];
        if (map.has(complement)) return [map.get(complement)!, i];
        map.set(nums[i], i);
    }
    return [];
}
```

The `!` non-null assertion on `map.get(complement)` is safe because we just checked `map.has(complement)` on the line above.

---

## Diagram: General n-element case

```
nums = [a₀, a₁, a₂, ..., aₙ],  target = T

For each aᵢ:

  ┌─────────────────────────────────────────────────┐
  │  complement = T - aᵢ                            │
  │                                                 │
  │  complement in map?                             │
  │       │                                         │
  │    YES│                    NO                   │
  │       ▼                    ▼                    │
  │  return [map[complement],  store aᵢ → i         │
  │           i]               in map, continue     │
  └─────────────────────────────────────────────────┘

Map grows left → right as we scan:

index:  0     1     2     3     4   ...   i
      [ a₀ ] [ a₁] [ a₂] [ a₃] [ a₄]  ...
        ↑─────────────────────────────────┘
        all prior elements live in the map
        when we process index i
```

---

## Key Takeaways

1. **Complement thinking** — reframe "find two numbers summing to T" as "for each number, find its complement."
2. **Hash map for O(1) lookup** — converts an O(n) inner search into O(1), collapsing O(n²) to O(n).
3. **One pass is enough** — storing as you go means you never need to revisit earlier elements.
4. **The problem guarantees a solution** — no need to handle the no-answer case (hence `unreachable!()` in Rust).
