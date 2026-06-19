using System;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        var lines = Console.In.ReadToEnd().Split('\n');
        string[] strs = JsonSerializer.Deserialize<string[]>(lines[0]);
        var result = new Solution().LongestCommonPrefix(strs);
        Console.WriteLine(JsonSerializer.Serialize(result));
    }
}
