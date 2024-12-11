using day11;

using FileStream fs = new("input.txt", FileMode.Open, FileAccess.Read);
using StreamReader sr = new(fs);
var line = sr.ReadLine() ?? "";

var part = Environment.GetEnvironmentVariable("part");
var solution = part switch
{
    "part1" => Puzzle.Part1(line, 25),
    "part2" => Puzzle.Part2(line, 75),
    _ => throw new ArgumentOutOfRangeException($"unexpected part {part}")
};

Console.WriteLine("\n---------Solution---------");
Console.WriteLine(solution);
Console.WriteLine("--------------------------");