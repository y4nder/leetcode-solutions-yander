# 1732. Find the Highest Altitude

scratch notes

**Example 1:**


**Input:** gain = [-5,1,5,0,-7]
**Output:** 1
**Explanation:** The altitudes are [0,-5,-4,1,1,-6]. The highest is 1.


val = 0

0
-5 -> -5
1 -> -5 + 1 = -4
5 -> -4 + 5 = 1
0 -> 1 + 0 = 1
-7 -> 1 - 7 = -6


## How to Think About This Problem Type

**Pattern: Running Total + Track Best**

When a problem gives you an array of *changes* (gains/losses, steps, deltas) and asks for a max or min *state*, think:
1. You need a running total — each element modifies a current value, not replaces it.
2. You need to track the best (max/min) seen so far alongside the current value.
3. Ask: "What is the starting value?" — here altitude begins at 0, so initialize both `current` and `best` to 0.

**Recognition signals:**
- Input is differences/deltas, not absolute values
- Output is a max or min of some accumulated state
- You're "walking" through values and the path matters

**Mental model:** Think of it like a stock price tracker — you have daily gains/losses, and you want the highest price ever reached. You don't store all prices; you just track `current_price` and `highest_ever`.

**Related patterns:** prefix sums, Kadane's algorithm (max subarray), sliding window with running state.

## Solutions

**1. LINQ one-liner** (no extra allocation)
```csharp
public int LargestAltitude(int[] gain) =>
    gain.Aggregate((max: 0, cur: 0), (acc, g) => {
        int next = acc.cur + g;
        return (Math.Max(acc.max, next), next);
    }).max;
```

**2. Simple loop** (clearest, O(1) space — recommended)
```csharp
public int LargestAltitude(int[] gain)
{
    int max = 0, altitude = 0;
    foreach (int g in gain)
    {
        altitude += g;
        if (altitude > max) max = altitude;
    }
    return max;
}
```

**3. Prefix-sum array** (O(n) space)
```csharp
public int LargestAltitude(int[] gain)
{
    int[] altitudes = new int[gain.Length + 1];
    for (int i = 0; i < gain.Length; i++)
        altitudes[i + 1] = altitudes[i] + gain[i];
    return altitudes.Max();
}
```
