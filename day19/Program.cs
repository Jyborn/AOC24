using day19;

using FileStream fs = new("test.txt", FileMode.Open, FileAccess.Read);
using StreamReader sr = new(fs);
var input = new List<string>();
string line;
while ((line = sr.ReadLine()) != null)
{
    input.Add(line);
}
var towels = input[0].Split(',').Select(t => t.Trim()).ToList();
var designs = input.Skip(2).ToList();
var part = Environment.GetEnvironmentVariable("part");
var solution = part switch
{
    "part1" => Puzzle.Part1(towels, designs),
    "part2" => Puzzle.Part2(towels, designs),
    _ => throw new ArgumentOutOfRangeException($"unexpected part {part}")
};

Console.WriteLine("\n---------Solution---------");
Console.WriteLine(solution);
Console.WriteLine("--------------------------");