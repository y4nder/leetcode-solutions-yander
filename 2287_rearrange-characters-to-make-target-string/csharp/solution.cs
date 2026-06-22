public class Solution
{
    public int RearrangeCharacters(string s, string target)
    {
        // var sCount = s.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        // var targetCount = target.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
        //
        // var result = int.MaxValue;
        //
        // foreach (var (character, count) in targetCount)
        // {
        //     if (!sCount.ContainsKey(character))
        //         return 0;
        //     result = Math.Min(result, sCount[character] / count);
        // }
        //
        // return result;

        const int MAX_LETTERS = 26;

        int[] sCount = new int[MAX_LETTERS];
        int[] targetCount = new int[MAX_LETTERS];

        foreach (char c in s)
            sCount[c - 'a']++;
        foreach (char c in target)
            targetCount[c - 'a']++;

        int result = int.MaxValue;

        for (int i = 0; i < MAX_LETTERS; i++)
        {
            if (targetCount[i] > 0)
            {
                result = Math.Min(result, sCount[i] / targetCount[i]);
            }
        }

        return result;
    }
}
