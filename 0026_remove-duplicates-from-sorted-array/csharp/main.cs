using System;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        var lines = Console.In.ReadToEnd().Split('\n');
        int[] nums = JsonSerializer.Deserialize<int[]>(lines[0]);
        var result = new Solution().RemoveDuplicates(nums);
        Console.WriteLine(JsonSerializer.Serialize(result));
    }
}
