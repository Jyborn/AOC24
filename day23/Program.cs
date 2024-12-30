using day23;

using FileStream fs = new("test.txt", FileMode.Open, FileAccess.Read);
using StreamReader sr = new(fs);
string line;
var connections = new Dictionary<string, HashSet<string>>();
while ((line = sr.ReadLine()) != null)
{
    var computers = line.Split('-');
    if (!connections.ContainsKey(computers[0])) connections[computers[0]] = [];
    if (!connections.ContainsKey(computers[1])) connections[computers[1]] = [];
    connections[computers[0]].Add(computers[1]);
    connections[computers[1]].Add(computers[0]);
}
connections.ToList().ForEach(connection => Console.WriteLine($"{connection.Key}: {string.Join(",", connection.Value)}"));
var part = Environment.GetEnvironmentVariable("part");
var solution = part switch
{
    "part1" => Puzzle.Part1(connections),
    "part2" => Puzzle.Part2(connections),
    _ => throw new ArgumentOutOfRangeException($"unexpected part {part}")
};

Console.WriteLine("\n---------Solution---------");
Console.WriteLine(solution);
Console.WriteLine("--------------------------");