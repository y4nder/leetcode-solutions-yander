using System;
using System.Text.Json;

public class Program
{
    public static void Main()
    {
        var lines = Console.In.ReadToEnd().Split('\n');
        string s = JsonSerializer.Deserialize<string>(lines[0]);
        string target = JsonSerializer.Deserialize<string>(lines[1]);
        var result = new Solution().RearrangeCharacters(s, target);
        Console.WriteLine(JsonSerializer.Serialize(result));
    }
}
