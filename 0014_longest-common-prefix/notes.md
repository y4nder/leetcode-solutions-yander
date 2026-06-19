# 14. Longest Common Prefix

## Problem Summary
Find the longest prefix shared by all strings in an array. Return `""` if none exists.

## Key Observations
- A prefix must match from index 0 across **all** strings, not just some.
- The common prefix can be at most as long as the shortest string.
- If the array has one string, that string is the answer.

## Approaches

### 1. Horizontal Scanning (compare pairwise)
- Start with `prefix = strs[0]`.
- For each subsequent string, trim the prefix until it matches the start of that string.
- Stop early if prefix becomes `""`.
- **Time:** O(S) where S = total characters. **Space:** O(1).

### 2. Vertical Scanning (character by character)
- Take the first string as the reference.
- For each character index `i`, check if all strings have the same character at `i`.
- Stop when a mismatch is found or any string runs out of characters.
- **Time:** O(S). **Space:** O(1).

### 3. Divide and Conquer
- Split the array in half, find LCP of each half recursively, then find LCP of the two results.
- **Time:** O(S). **Space:** O(m log n) where m = length of shortest string.

### 4. Binary Search on prefix length
- Binary search on the length of the prefix (0 to min string length).
- For each candidate length, check if all strings share that prefix.
- **Time:** O(S log m). **Space:** O(1).

## Recommended Approach
**Vertical scanning** — simplest to implement, short-circuits early on mismatches, and is easy to reason about.

## Edge Cases
- Single string in array → return that string.
- Empty string in array → return `""`.
- All strings identical → return the string itself.
- No common prefix at all → return `""`.

## Complexity (Vertical Scanning)
- **Time:** O(S) — S is the sum of all characters in worst case (all strings identical).
- **Space:** O(1).
