# An Optimal Approach

The current solution builds an intermediate sorted list from the frequency array before consuming it. That list is unnecessary — the frequency array already encodes the sorted order implicitly (index = price, value = count). You can buy greedily at each price level in one step using integer division.

## Key Insight

At each price level, the maximum number of bars you can afford is:

```
canBuy = min(freq[price], coins / price)
```

Then subtract what you spent (`canBuy * price`) from `coins` and move to the next price.

Once `coins < price`, you can't afford anything at this price or any higher price, so break early.

## Optimized Solution

```csharp
public class Solution
{
    public int MaxIceCream(int[] costs, int coins)
    {
        var freq = new int[costs.Max() + 1];
        foreach (var cost in costs)
            freq[cost]++;

        var count = 0;
        for (int price = 1; price < freq.Length; price++)
        {
            if (coins < price) break;
            var canBuy = Math.Min(freq[price], coins / price);
            count += canBuy;
            coins -= canBuy * price;
        }
        return count;
    }
}
```

## What Changed

| | Current | Optimized |
|---|---|---|
| Extra allocation | `List<int>` rebuilt from freq table | None |
| Inner loop | Nested loop to expand freq into list | Single `Math.Min` per price level |
| Early exit | No (iterates entire list) | Yes (`break` when `coins < price`) |
| Space | O(max_cost + n) | O(max_cost) |

Time complexity stays O(n + max_cost) in both cases, but the optimized version avoids the O(n) list allocation and two-pass iteration.
