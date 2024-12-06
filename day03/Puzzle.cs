using System.Text.RegularExpressions;

namespace day03;

public class Puzzle
{
    public static int Part1(string content)
    {
        var multiplications = ParseInput(content);
        return multiplications.Select((x) => x.Item1 * x.Item2).Sum();
    }

    private static List<(int, int)> ParseInput(string content)
    {
        const string pattern = @"mul\((\d+),(\d+)\)";
        
        var results = new List<(int x, int y)>();
        
        foreach (Match match in Regex.Matches(content, pattern))
        {
            var x = int.Parse(match.Groups[1].Value);
            var y = int.Parse(match.Groups[2].Value);
            
            results.Add((x, y));
        }

        return results;
    }
    public static int Part2(string content)
    {
        var multiplications = ParseInput(RemoveDontInstructions(content));
        return multiplications.Select((x) => x.Item1 * x.Item2).Sum();;
    }

    private static string RemoveDontInstructions(string input)
    {
        int start, end;
        const string startMark = "don't()";
        const string endMark = "do()";
        while ((start = input.IndexOf(startMark, StringComparison.Ordinal)) != -1)
        {
            end = input.IndexOf(endMark, start, StringComparison.Ordinal);
            if (end != -1)
            {
                input = input.Remove(start, end + endMark.Length - start);   
            }
            else
            {
                input = input.Remove(start);
                break;
            }
        }
        return input;
    }
}