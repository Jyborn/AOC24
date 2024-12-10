using day10;

using FileStream fs = new("input.txt", FileMode.Open, FileAccess.Read);
using StreamReader sr = new(fs);
var line = sr.ReadLine() ?? "";

var part = Environment.GetEnvironmentVariable("part");
var solution = part switch
{
    "part1" => Puzzle.Part1(line),
    "part2" => Puzzle.Part2(line),
    _ => throw new ArgumentOutOfRangeException($"unexpected part {part}")
};

Console.WriteLine("\n---------Solution---------");
Console.WriteLine(solution);
Console.WriteLine("--------------------------");