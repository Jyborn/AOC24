using day08;

using FileStream fs = new ("input.txt", FileMode.Open, FileAccess.Read );
using StreamReader sr = new (fs);
string line;
var map = new List<string>();
while ((line = sr.ReadLine()) != null) map.Add(line);

var part = Environment.GetEnvironmentVariable("part");
var solution = part switch
{
    "part1" => Puzzle.Part1(map),
    "part2" => Puzzle.Part2(),
    _ => throw new ArgumentOutOfRangeException($"unexpected part {part}")
};

Console.WriteLine(solution);