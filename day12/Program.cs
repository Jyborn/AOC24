using day12;

using FileStream fs = new("test.txt", FileMode.Open, FileAccess.Read);
using StreamReader sr = new(fs);
string line;
var grid = new List<List<char>>();
while ((line = sr.ReadLine()) != null)
{
    grid.Add(line.ToCharArray().ToList());
}

var part = Environment.GetEnvironmentVariable("part");
var solution = part switch
{
    "part1" => Puzzle.Part1(grid),
    "part2" => Puzzle.Part2(grid),
    _ => throw new ArgumentOutOfRangeException($"unexpected part {part}")
};

Console.WriteLine("\n---------Solution---------");
Console.WriteLine(solution);
Console.WriteLine("--------------------------");