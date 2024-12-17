using day13;

using FileStream fs = new("input.txt", FileMode.Open, FileAccess.Read);
using StreamReader sr = new(fs);
string line;
var machines = new List<Machine>();
Button buttonA = null, buttonB = null;
Prize prize = null;
while ((line = sr.ReadLine()) != null)
{
    if (line.StartsWith("Button A:"))
    {
        var parts = line.Split(["X+", ", Y+"], StringSplitOptions.None);
        var deltaX = int.Parse(parts[1]);
        var deltaY = int.Parse(parts[2]);
        buttonA = new Button(deltaX, deltaY);
    }
    else if (line.StartsWith("Button B:"))
    {
        var parts = line.Split(["X+", ", Y+"], StringSplitOptions.None);
        var deltaX = int.Parse(parts[1]);
        var deltaY = int.Parse(parts[2]);
        buttonB = new Button(deltaX, deltaY);
    }
    else if (line.StartsWith("Prize:"))
    {
        var parts = line.Split(["X=", ", Y="], StringSplitOptions.None);
        var x = int.Parse(parts[1]);
        var y = int.Parse(parts[2]);
        prize = new Prize(x, y);
    }
    else if (string.IsNullOrWhiteSpace(line) && buttonA != null && buttonB != null && prize != null)
    {
        machines.Add(new Machine(buttonA, buttonB, prize));
        buttonA = buttonB = null;
        prize = null;
    }
}
machines.ForEach(x => Console.WriteLine(x.ToString()));
var part = Environment.GetEnvironmentVariable("part");
var solution = part switch
{
    "part1" => Puzzle.Part1(machines),
    "part2" => Puzzle.Part2(machines),
    _ => throw new ArgumentOutOfRangeException($"unexpected part {part}")
};

Console.WriteLine("\n---------Solution---------");
Console.WriteLine(solution);
Console.WriteLine("--------------------------");

public record Machine(Button A, Button B, Prize P);

public record Button(int DeltaX, int DeltaY);


public record Prize(long X, long Y);