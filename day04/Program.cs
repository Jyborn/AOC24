
using day04;

char[,] grid;
try
{
    using FileStream fs = new ("input.txt", FileMode.Open, FileAccess.Read);
    using StreamReader sr = new (fs);
    var lines = new List<string>();
    string line;
    while ((line = sr.ReadLine()) != null)
    {
        lines.Add(line);
    }

    grid = new char[lines.Count, lines[0].Length];
    for (var i = 0; i < lines.Count; i++)
    {
        for (var j = 0; j < lines[i].Length; j++)
        {
            grid[i, j] = lines[i][j];
        }
    }
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}

var part = Environment.GetEnvironmentVariable("part");
var solution = part switch
{
    "part1" => Puzzle.Part1(grid, "XMAS"),
    "part2" => Puzzle.Part2(grid),
    _ => throw new ArgumentOutOfRangeException($"unexpected part {part}")
};

Console.WriteLine(solution);