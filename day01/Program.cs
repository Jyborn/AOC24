

using day01;

var part = Environment.GetEnvironmentVariable("part");

var col1 = new List<int>();
var col2 = new List<int>();
using FileStream fs = new ("input.txt", FileMode.Open, FileAccess.Read);
using StreamReader sr = new(fs);
string? line;
while ((line = sr.ReadLine()) != null)
{
    var cols = line.Split(new []{' ', '\t'}, StringSplitOptions.RemoveEmptyEntries);
    col1.Add(int.Parse(cols[0]));
    col2.Add(int.Parse(cols[1]));
}

var solution = part switch
{
    "part1" => Puzzle.Part1(col1, col2),
    "part2" => Puzzle.Part2(col1, col2),
    _ => throw new ArgumentOutOfRangeException($"unexpected part {part}")
};

Console.WriteLine($"Solution: {solution}");



