# 1358. Number of Substrings Containing All Three Characters

## Technique: Last Seen Index

For each right index `r`, track the last position where each of 'a', 'b', 'c' appeared.
The minimum of those three positions (`min_last`) is the rightmost valid left boundary.

Every starting index from `0` to `min_last` (inclusive) forms a valid substring ending at `r`,
so add `min_last + 1` to the total count.

**Why this works:** A substring `s[l..r]` contains all three chars only if each char has appeared
at or before `r`. The earliest we can place `l` and still have all three is just after the oldest
last-seen index — but any `l` ≤ `min_last` is also valid. So valid starts = `min_last + 1`.

**Complexity:** O(n) time, O(1) space.

### Walkthrough: s = "abcabc"

| r | char | last[a] | last[b] | last[c] | min_last | count added |
|---|------|---------|---------|---------|----------|-------------|
| 0 | a    | 0       | -1      | -1      | -1       | 0           |
| 1 | b    | 0       | 1       | -1      | -1       | 0           |
| 2 | c    | 0       | 1       | 2       | 0        | 1           |
| 3 | a    | 3       | 1       | 2       | 1        | 2           |
| 4 | b    | 3       | 4       | 2       | 2        | 3           |
| 5 | c    | 3       | 4       | 5       | 3        | 4           |

Total = 0+0+1+2+3+4 = **10** ✓

### Python Pseudocode

```python
def numberOfSubstrings(s: str) -> int:
    # Track the most recent index of each character.
    # Initialize to -1: "not yet seen".
    last = {'a': -1, 'b': -1, 'c': -1}
    count = 0

    for r, ch in enumerate(s):
        last[ch] = r                          # Update last-seen for current char
        min_last = min(last.values())         # Rightmost valid left boundary
        if min_last != -1:                    # All three chars have been seen
            count += min_last + 1            # Valid starts: 0..min_last (inclusive)

    return count
```
