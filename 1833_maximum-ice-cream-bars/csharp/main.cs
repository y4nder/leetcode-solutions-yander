using System;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        var lines = Console.In.ReadToEnd().Split('\n');
        int[] costs = JsonSerializer.Deserialize<int[]>(lines[0]);
        int coins = JsonSerializer.Deserialize<int>(lines[1]);
        var result = new Solution().MaxIceCream(costs, coins);
        Console.WriteLine(JsonSerializer.Serialize(result));
    }
}
