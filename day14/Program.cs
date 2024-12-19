using System.Numerics;
using day14;

using FileStream fs = new("input.txt", FileMode.Open, FileAccess.Read);
using StreamReader sr = new(fs);
string line;
var robots = new List<(Vector2 startPos, Vector2 velocity)>();
while ((line = sr.ReadLine()) != null)
{
    var startPos = new Vector2(
        int.Parse(line.Substring(line.IndexOf('p') + 2, line.IndexOf(',') - (line.IndexOf('p') + 2))), 
        int.Parse(line.Substring(line.IndexOf(',') + 1, line.IndexOf('v') - (line.IndexOf(',') + 2)))
    );
    var velocity = new Vector2(
        int.Parse(line.Substring(line.IndexOf('v') + 2, line.LastIndexOf(',') - (line.IndexOf('v') + 2))), 
        int.Parse(line.Substring(line.LastIndexOf(',') + 1))
    );
    robots.Add((startPos, velocity));
}




var part = Environment.GetEnvironmentVariable("part");
var solution = part switch
{
    "part1" => Puzzle.Part1(robots),
    "part2" => Puzzle.Part2(robots),
    _ => throw new ArgumentOutOfRangeException($"unexpected part {part}")
};

Console.WriteLine("\n---------Solution---------");
Console.WriteLine(solution);
Console.WriteLine("--------------------------");