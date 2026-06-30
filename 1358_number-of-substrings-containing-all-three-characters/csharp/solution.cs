public class Solution
{
    public int NumberOfSubstrings(string s)
    {
        var last = new int[3];
        last[0] = last[1] = last[2] = -1;

        var count = 0;

        for (var r = 0; r < s.Length; r++)
        {
            last[s[r] - 'a'] = r;

            var minLast =
                last[0] < last[1]
                    ? (last[0] < last[2] ? last[0] : last[2])
                    : (last[1] < last[2] ? last[1] : last[2]);

            if (minLast != -1)
                count += minLast + 1;
        }

        return count;
    }
}
