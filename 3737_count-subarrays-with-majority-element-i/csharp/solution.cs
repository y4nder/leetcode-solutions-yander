public class Solution
{
    public int CountMajoritySubarrays(int[] nums, int target)
    {
        var score = nums.Select(n => n == target ? 1 : -1).ToArray();

        var prefixSums = new int[nums.Length + 1];

        for (int i = 1; i <= nums.Length; i++)
        {
            prefixSums[i] = prefixSums[i - 1] + score[i - 1];
        }

        var count = 0;
        for (int l = 0; l < prefixSums.Length; l++)
        {
            for (int r = l + 1; r < prefixSums.Length; r++)
            {
                if (prefixSums[r] > prefixSums[l])
                    count++;
            }
        }

        return count;
    }
}

