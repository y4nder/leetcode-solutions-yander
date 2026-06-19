using System;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        var lines = Console.In.ReadToEnd().Split('\n');
        int[] gain = JsonSerializer.Deserialize<int[]>(lines[0]);
        var result = new Solution().LargestAltitude(gain);
        Console.WriteLine(JsonSerializer.Serialize(result));
    }
}
