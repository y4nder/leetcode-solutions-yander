# 1833. Maximum Ice Cream Bars

## Beginner Explanation

Imagine you have **7 coins** in your pocket and you walk into an ice cream shop. The shop has ice creams that cost different amounts — say 1, 3, 2, 4, and 1 coin each. You want to buy **as many ice creams as possible** before your coins run out.

The question is: what's the smartest order to buy them?

Think about it this way — if you buy the expensive ones first, you run out of coins fast and end up with fewer ice creams. But if you start with the cheapest ones, your coins last longer and you get more in total.

So the strategy is simple: **always pick the cheapest one available first**, then the next cheapest, and keep going until you can't afford anything anymore.

That's the whole idea. Sort the prices from lowest to highest, then greedily buy as many as you can from the front of the list.

The only twist the problem adds is that it asks you to sort using a specific technique called **counting sort** (instead of the usual sort). The reason is that prices are always between 1 and 100,000 — small enough that you can just count how many ice creams exist at each price point, then walk through those prices one by one.

---

## Core Problem

You have a fixed budget (`coins`) and a list of item prices (`costs`). You want to **maximize the number of items you can buy**, not the total value — just the count.

Key insight: since you only care about quantity, always buy the cheapest available item first. This is a classic **greedy** problem.

The constraint says to solve it with **counting sort** specifically — this matters because `costs[i] <= 10^5`, which makes a frequency array feasible and avoids the O(n log n) overhead of comparison-based sort.

---

## Core Pattern: [Greedy](./greedy-algorithm.md) + [Counting Sort](./counting-sort.md)

**Why greedy works here:** buying cheaper items first leaves more budget for additional items. Spending on expensive ones early only reduces your count.

**Why counting sort instead of regular sort:** cost values are bounded integers (1 to 100,000). A frequency array lets you sweep prices in O(max_cost) instead of sorting the array in O(n log n).

### High-level pseudocode

```
freq[1..MAX_COST] = count of each price in costs

count = 0
for price from 1 to MAX_COST:
    can_buy = min(freq[price], coins / price)
    count  += can_buy
    coins  -= can_buy * price
    if coins == 0: break

return count
```

Time: O(n + MAX_COST) — one pass to build freq, one sweep to buy  
Space: O(MAX_COST) — the frequency array

---

## Counting Sort — What It Is and How It Works

### The basic idea

Normal sorting (like quicksort or mergesort) works by **comparing** elements against each other. That's why it costs O(n log n) — you need roughly log n comparisons per element.

Counting sort takes a completely different approach: instead of comparing, it **counts**. It asks "how many times does each value appear?" and uses that information to reconstruct the sorted order directly.

### Step-by-step

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

### When can you use it?

Counting sort only works when:
1. Values are **integers** (you can't use a float as an array index)
2. The **range of values is known and reasonably small** — you need to allocate a frequency array of that size

If values range from 1 to 100,000, you allocate an array of 100,001 slots. That's fine. If values could be up to 10^18, you'd need a billion-slot array — not feasible.

### Why it's faster than comparison sort

| Algorithm       | Time         | Space        |
|----------------|--------------|--------------|
| Quicksort       | O(n log n)   | O(log n)     |
| Mergesort       | O(n log n)   | O(n)         |
| Counting Sort   | O(n + k)     | O(k)         |

`k` = range of values. When `k` is small relative to `n`, counting sort wins easily.

### The catch

Counting sort is **not a general-purpose sort** — it breaks the O(n log n) lower bound only because it cheats: it exploits extra knowledge about the data (bounded integer range) that comparison sorts don't get to assume.

---

## Real-World Analogy

**Budget shopping with a fixed wallet:** imagine you're at a flea market with $20 and want to grab as many items as possible. You naturally reach for the $1 items before the $5 items. The counting sort maps to a price rack sorted from cheapest to most expensive — you just walk down the rack buying everything you can still afford.

Other domains with the same shape:
- **Cloud cost optimization** — maximize number of VMs/jobs schedulable within a compute budget
- **Ad bidding** — maximize impressions bought when each ad slot has a fixed cost and you have a daily budget
- **Inventory purchasing** — a retailer with a fixed cash position buying the most units possible across SKUs with varying per-unit costs
