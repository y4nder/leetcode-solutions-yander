public class Solution
{
    public int SearchInsert(int[] nums, int target)
    {
        var left = 0;
        var right = nums.Length - 1;
        var mid = (right + left) / 2;

        while (left <= right)
        {
            if (nums[mid] > target)
            {
                right = mid - 1;
            }
            else if (nums[mid] < target)
            {
                left = mid + 1;
            }
            else
                return mid;
            mid = (right + left) / 2;
        }

        if (nums[mid] < target)
            mid++;

        return mid;
    }
}
