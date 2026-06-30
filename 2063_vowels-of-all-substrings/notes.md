# 2063. Vowels of All Substrings

## Problem

Given a string `word` (length up to 10^5, lowercase English), return the sum of
vowel counts across **every possible substring**.

## Key Insight — Contribution Technique

**Don't enumerate substrings. Instead, for each vowel, ask: "How many substrings
include me?"**

If character at index `i` (0-indexed) is a vowel, it adds +1 to every substring
that spans position `i`.

A substring contains position `i` iff:
- Its **start** is anywhere from `0` through `i` → `i + 1` choices
- Its **end** is anywhere from `i` through `n-1` → `n - i` choices

So a vowel at index `i` contributes:
```
contribution = (i + 1) * (n - i)
```

Walk through `word`, accumulate contributions for every vowel. O(n) time, O(1)
space.

## Walkthrough — word = "aba" (n = 3)

| i | char | vowel? | (i+1) | (n-i) | contribution |
|---|------|--------|-------|-------|-------------|
| 0 |  a   |  yes   |   1   |   3   |  1 × 3 = 3  |
| 1 |  b   |  no    |   —   |   —   |      0      |
| 2 |  a   |  yes   |   3   |   1   |  3 × 1 = 3  |

Total = 3 + 0 + 3 = **6** ✓

## Reusable Technique — "Count Subarrays Containing Index i"

This is a **combinatorial counting on subarrays** pattern. Whenever a problem
asks for a sum/aggregate over *all substrings* (or all subarrays), and the
constraint is too large for O(n²), try this:

> **For each element at index `i`, compute how many subarrays include it:**
> `(i + 1) × (n - i)`  (0-indexed) or `i × (n - i + 1)`  (1-indexed)

Then multiply by the element's "weight" (here, 1 if vowel else 0) and sum.

**Other problems where this applies:**
- Sum of all subarray minimums (LeetCode 907)
- Sum of all subarray maximums
- Count substrings with a specific character appearing exactly k times
- Any "sum over all substrings" where you can break the answer into per-index
  contributions

## High-Level Pseudocode

```
function sumOfVowels(word):
    n = length(word)
    total = 0
    vowels = set('a', 'e', 'i', 'o', 'u')

    for i from 0 to n-1:
        if word[i] is in vowels:
            total = total + (i + 1) * (n - i)

    return total
```

- **Time:** O(n) — single pass
- **Space:** O(1) — just a counter and a fixed set of 5 vowels
- **Overflow note:** Use a 64-bit integer (`long` in Java, `long long` in C++,
  Python handles this automatically). Constraint n=10^5 means the maximum
  contribution for one position is ~(10^5 × 10^5) = 10^10, and summing across
  n positions could reach ~10^15 — well past 32-bit signed int.

