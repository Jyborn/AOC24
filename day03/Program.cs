using day03;

string content;
try
{
    using FileStream fs = new ("input.txt", FileMode.Open, FileAccess.Read);
    using StreamReader sr = new (fs);
    content = sr.ReadToEnd();
}
catch (Exception e)
{
    Console.WriteLine(e);
    throw;
}
var part = Environment.GetEnvironmentVariable("part");
var solution = part switch
{
    "part1" => Puzzle.Part1(content),
    "part2" => Puzzle.Part2(content),
    _ => throw new ArgumentOutOfRangeException($"unexpected part {part}")
};

Console.WriteLine($"Solution: {solution}");