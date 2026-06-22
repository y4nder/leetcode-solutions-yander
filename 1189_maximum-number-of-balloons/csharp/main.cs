using System;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        var lines = Console.In.ReadToEnd().Split('\n');
        string text = JsonSerializer.Deserialize<string>(lines[0]);
        var result = new Solution().MaxNumberOfBalloons(text);
        Console.WriteLine(JsonSerializer.Serialize(result));
    }
}
