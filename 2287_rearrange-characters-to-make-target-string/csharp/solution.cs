public class Solution
{
    public int RearrangeCharacters(string s, string target)
    {
        var sCount = s.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        var targetCount = target.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());

        var result = int.MaxValue;

        foreach (var (character, count) in targetCount)
        {
            if (!sCount.ContainsKey(character))
                return 0;
            result = Math.Min(result, sCount[character] / count);
        }

        return result;
    }
}
