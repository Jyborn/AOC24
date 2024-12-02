using day02;

var part = Environment.GetEnvironmentVariable("part");
var solution = part switch
{
    "part1" => Puzzle.Part1(),
    "part2" => Puzzle.Part2(),
    _ => throw new ArgumentOutOfRangeException($"unexpected part {part}")
};

Console.WriteLine($"Solution: {solution}");