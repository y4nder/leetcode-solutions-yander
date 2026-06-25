# 3737. Count Subarrays With Majority Element I

## Problem Summary

Count subarrays where `target` appears **strictly more than half** the time.

- `target` count must satisfy: `count(target) > len(subarray) / 2`

## Constraints

- `n <= 1000` → O(n²) is fine (~10⁶ ops)

## Is Sliding Window a Good Fit?

**No.** Sliding window requires a **monotonic property** — expanding or shrinking the window predictably changes validity. Majority status lacks this:

- Expanding with a non-target → may invalidate
- Expanding with a target → may validate
- Shrinking from either end → effect depends on what element is removed

There's no direction you can reliably slide in to enumerate all valid subarrays without missing or double-counting.

## Approaches

### 1. Brute Force — O(n²)

For every (l, r) pair, count occurrences of `target` and check if `count > (r - l + 1) / 2`.
Fine given n ≤ 1000.

```
count = 0
for l from 0 to n-1:
    freq = 0
    for r from l to n-1:
        if nums[r] == target: freq++
        if freq > (r - l + 1) / 2: count++
return count
```

### 2. Prefix Sum / Score Transform — O(n²) loop, O(n log n) with BIT

Map each element to a score: `+1` if `nums[i] == target`, else `-1`.
Build prefix sums `P[0..n]`.

Subarray `[l, r]` is valid iff `sum(score[l..r]) > 0`
→ `P[r+1] - P[l] > 0`
→ `P[r+1] > P[l]`

Count pairs `(l, r+1)` with `l < r+1` where `P[r+1] > P[l]`.
This is a **count of non-inversions** in the prefix sum array, solvable in O(n log n) with BIT/merge sort.
For n ≤ 1000, a nested loop over prefix sums is O(n²) and simpler.

```
score = [+1 if x == target else -1 for x in nums]
P = prefix sums of score  // P[0] = 0, P[i] = P[i-1] + score[i-1]

count = 0
for l from 0 to n:
    for r from l+1 to n:
        if P[r] > P[l]: count++
return count
```

## Key Insight

The score-transform turns the majority check into a **prefix sum comparison**, which is the cleaner mental model even if you implement it as brute force.
