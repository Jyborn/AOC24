using day06;

var map = new List<List<char>>();
using FileStream fs = new ("input.txt", FileMode.Open, FileAccess.Read);
using StreamReader sr = new (fs);
string line;
while ((line = sr.ReadLine()) != null)
{
    map.Add(line.Replace(" ", "").ToList());
}

var part = Environment.GetEnvironmentVariable("part");
var solution = part switch
{
    "part1" => Puzzle.Part1(map),
    "part2" => Puzzle.Part2(map),
    _ => throw new ArgumentOutOfRangeException($"unexpected part {part}")
};

Console.WriteLine(solution);