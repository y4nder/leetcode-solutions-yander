public class Solution
{
    public long CountVowels(string word)
    {
        var n = word.Length;
        long total = 0;

        bool exists(char character)
        {
            switch (character)
            {
                case 'a':
                case 'e':
                case 'i':
                case 'o':
                case 'u':
                    return true;
                default:
                    return false;
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (exists(word[i]))
            {
                total += (long)(i + 1) * (n - i);
            }
        }

        return total;
    }
}
