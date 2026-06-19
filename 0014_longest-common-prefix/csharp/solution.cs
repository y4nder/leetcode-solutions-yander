public class Solution
{
    public string LongestCommonPrefix(string[] strs)
    {
        if (strs.Length is 0)
            return "";

        var reference = strs[0];

        for (int i = 0; i < reference.Length; i++)
        {
            var c = reference[i];
            for (int j = 1; j < strs.Length; j++)
            {
                if (i >= strs[j].Length || strs[j][i] != c)
                    return reference[0..i];
            }
        }

        return reference;
    }
}
