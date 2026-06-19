public class Solution {
    public int[] TwoSum(int[] nums, int target) {
      var map = new Dictionary<int, int>();
      for (int i = 0; i < nums.Length; i++){
        var complement = target - nums[i];
        if(map.ContainsKey(complement)) return [map[complement], i];
        map.Add(nums[i], i);
      }
      return [];
    }
}
