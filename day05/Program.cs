using day05;

var rules = new List<(int, int)>();
var data = new List<List<int>>();

using FileStream fs = new ("input.txt", FileMode.Open, FileAccess.Read);
using StreamReader sr = new (fs);
bool isParsingRules = true;

string? line;
while ((line = sr.ReadLine()) != null)
{
    var trimmedLine = line.Trim();

    if (string.IsNullOrEmpty(trimmedLine))
    {
        isParsingRules = false;
        continue;
    }

    if (isParsingRules)
    {
        var parts = trimmedLine.Split('|');
        rules.Add((int.Parse(parts[0]), int.Parse(parts[1])));
    }
    else
    {
        var numbers = trimmedLine.Split(',')
            .Select(int.Parse)
            .ToList();
        data.Add(numbers);
    }
}



var part = Environment.GetEnvironmentVariable("part");
var solution = part switch
{
    "part1" => Puzzle.Part1(rules, data),
    "part2" => Puzzle.Part2(rules, data),
    _ => throw new ArgumentOutOfRangeException($"unexpected part {part}")
};

Console.WriteLine(solution);