# Optimal C# Solution

## What changes from the current solution

The current solution uses LINQ (`GroupBy` + `ToDictionary`) to build frequency maps. This allocates heap objects and pays dictionary hashing costs. Since the problem guarantees lowercase English letters, we can use fixed `int[26]` arrays instead — same O(n + m) time and O(1) space, but with lower constant factors and no allocations.

## Solution

```csharp
public class Solution
{
    public int RearrangeCharacters(string s, string target)
    {
        int[] sCount = new int[26];
        int[] targetCount = new int[26];

        foreach (char c in s) sCount[c - 'a']++;
        foreach (char c in target) targetCount[c - 'a']++;

        int result = int.MaxValue;
        for (int i = 0; i < 26; i++)
        {
            if (targetCount[i] > 0)
                result = Math.Min(result, sCount[i] / targetCount[i]);
        }

        return result;
    }
}
```

## Why it's better

| | Current | Optimal |
|---|---|---|
| Frequency map | `Dictionary<char, int>` via LINQ | `int[26]` array |
| Heap allocations | Multiple (GroupBy enumerables, dictionaries) | 2 fixed arrays |
| Missing key handling | Explicit `ContainsKey` check | `sCount[i] / targetCount[i]` naturally handles it — if `targetCount[i] == 0` the slot is skipped |
| Time complexity | O(n + m) | O(n + m) |
| Space complexity | O(1) — at most 26 keys | O(1) — fixed 26 slots |

The loop over all 26 slots replaces both the `ContainsKey` guard and the dictionary lookup with a simple array index — branches and bounds checks the JIT can optimize away.
