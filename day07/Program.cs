using day07;

using FileStream fs = new("input.txt", FileMode.Open, FileAccess.Read);
using StreamReader sr = new StreamReader(fs);
var numbers = new Dictionary<long, long[]>();
string line;
while ((line = sr.ReadLine()) != null)
{
    var parts = line.Split(':');
    var total = long.Parse(parts[0].Trim());
    var terms = Array.ConvertAll(parts[1].Trim().Split(' '), long.Parse);
    numbers.Add(total, terms);
}

var part = Environment.GetEnvironmentVariable("part");
var solution = part switch
{
    "part1" => Puzzle.Part1(numbers),
    "part2" => Puzzle.Part2(numbers),
    _ => throw new ArgumentOutOfRangeException($"unexpected part {part}")
};

Console.WriteLine(solution);