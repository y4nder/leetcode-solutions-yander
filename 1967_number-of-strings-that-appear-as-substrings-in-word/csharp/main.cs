using System;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        var lines = Console.In.ReadToEnd().Split('\n');
        string[] patterns = JsonSerializer.Deserialize<string[]>(lines[0]);
        string word = JsonSerializer.Deserialize<string>(lines[1]);
        var result = new Solution().NumOfStrings(patterns, word);
        Console.WriteLine(JsonSerializer.Serialize(result));
    }
}
