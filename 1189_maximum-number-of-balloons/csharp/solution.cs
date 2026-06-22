public class Solution
{
    public int MaxNumberOfBalloons(string text)
    {
        const int MAX_LETTERS = 26;
        const string TO_FIND = "balloon";

        int[] sCount = new int[MAX_LETTERS];
        int[] targetCount = new int[MAX_LETTERS];

        foreach (char c in text)
            sCount[c - 'a']++;
        foreach (char c in TO_FIND)
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

