# Counting Sort

## The Basic Idea

Normal sorting (like quicksort or mergesort) works by **comparing** elements against each other. That's why it costs O(n log n) — you need roughly log n comparisons per element.

Counting sort takes a completely different approach: instead of comparing, it **counts**. It asks "how many times does each value appear?" and uses that information to reconstruct the sorted order directly.

---

## Step-by-Step Walkthrough

Say you have: `[3, 1, 2, 1, 3]` and values range from 1 to 3.

**Step 1 — Build a frequency array:**

```
index:  1  2  3
freq:   2  1  2    ← "1 appears 2x, 2 appears 1x, 3 appears 2x"
```

**Step 2 — Read it back in order:**

```
index 1 → output "1" twice  → [1, 1]
index 2 → output "2" once   → [1, 1, 2]
index 3 → output "3" twice  → [1, 1, 2, 3, 3]
```

That's the sorted array — no comparisons needed.

---

## High-Level Pseudocode

```
k = max value in input

freq[0..k] = array of zeros

for each value v in input:
    freq[v] += 1

result = []
for i from 0 to k:
    repeat freq[i] times:
        result.append(i)

return result
```

---

## When Can You Use It?

Counting sort only works when:

1. Values are **integers** (you can't use a float as an array index)
2. The **range of values is known and reasonably small** — you need to allocate a frequency array of that size

If values range from 1 to 100,000, you allocate an array of 100,001 slots. That's fine. If values could be up to 10^18, you'd need a billion-slot array — not feasible.

---

## Complexity

| Algorithm      | Time       | Space    |
|----------------|------------|----------|
| Quicksort      | O(n log n) | O(log n) |
| Mergesort      | O(n log n) | O(n)     |
| Counting Sort  | O(n + k)   | O(k)     |

`k` = range of values (max − min). When `k` is small relative to `n`, counting sort wins easily.

---

## The Catch

Counting sort is **not a general-purpose sort** — it breaks the O(n log n) lower bound only because it cheats: it exploits extra knowledge about the data (bounded integer range) that comparison sorts don't get to assume.

Use it when the problem tells you values are bounded integers. It's a signal worth recognizing in LeetCode constraints like `1 <= costs[i] <= 10^5`.

---

## Problems That Use This Pattern

- [1833. Maximum Ice Cream Bars](./notes.md)
