public class Solution
{
    public int NumOfStrings(string[] patterns, string word)
    {
        var count = 0;

        foreach (var pattern in patterns)
        {
            if (word.Contains(pattern))
            {
                count++;
            }
        }

        return count;
    }
}

