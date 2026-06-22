# 2287. Rearrange Characters to Make Target String

## Approach: Character Frequency Count

The key insight is: how many times can we "cover" every character in `target` using the characters in `s`?

**Steps:**
1. Count the frequency of each character in `s` and in `target`.
2. For each character that appears in `target`, compute `floor(s_count[c] / target_count[c])` — this tells you how many copies of `target` that character alone can support.
3. The answer is the **minimum** across all those values, since the rarest character (relative to what `target` needs) is the bottleneck.

**Example:** `s = "ilovecodingonleetcode"`, `target = "code"`
- `c`: 2 in s, 1 in target → 2/1 = 2
- `o`: 4 in s, 1 in target → 4/1 = 4
- `d`: 2 in s, 1 in target → 2/1 = 2
- `e`: 4 in s, 1 in target → 4/1 = 4
- min(2, 4, 2, 4) = **2** ✓

**Edge case:** If a character in `target` doesn't appear in `s` at all, the answer is 0 immediately.

**Complexity:** O(n + m) time, O(1) space (at most 26 distinct letters).

## Pseudocode

```
function rearrangeCharacters(s, target):
    s_count     = frequency map of characters in s
    target_count = frequency map of characters in target

    result = infinity

    for each (char, count) in target_count:
        result = min(result, floor(s_count[char] / count))

    return result
```
