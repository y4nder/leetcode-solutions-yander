using System;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        var lines = Console.In.ReadToEnd().Split('\n');
        string word = JsonSerializer.Deserialize<string>(lines[0]);
        var result = new Solution().CountVowels(word);
        Console.WriteLine(JsonSerializer.Serialize(result));
    }
}
