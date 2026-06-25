using System.Text.Json;

public class Program
{
    public static void Main()
    {
        var lines = Console.In.ReadToEnd().Split('\n');
        int[] nums = JsonSerializer.Deserialize<int[]>(lines[0]);
        int target = JsonSerializer.Deserialize<int>(lines[1]);
        var result = new Solution().CountMajoritySubarrays(nums, target);
        Console.WriteLine(JsonSerializer.Serialize(result));
    }
}
