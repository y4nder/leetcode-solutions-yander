public class Solution
{
    public int MaxIceCream(int[] costs, int coins)
    {
        // sort
        var freq = new int[costs.Max() + 1];
        foreach (var f in costs)
        {
            freq[f] += 1;
        }

        var result = new List<int>();

        for (int idx = 0; idx < freq.Length; idx++)
        {
            for (int count = 0; count < freq[idx]; count++)
            {
                result.Add(idx);
            }
        }

        // count values
        var output = 0;
        var curr = 0;

        foreach (var item in result)
        {
            if (curr + item <= coins)
            {
                output += 1;
                curr += item;
            }
        }
        return output;
    }
}
