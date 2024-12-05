namespace day05;

public class Puzzle
{
    public static int Part1(List<(int, int)> rules, List<List<int>> data)
    {
        return data.Where(row => IsValidRow(rules, row)).Select(row => row.ElementAt(row.Count / 2)).Sum();
    }

    private static bool IsValidRow(List<(int, int)> rules, List<int> row)
    {
        var rowPos = row.Select((x, i) => (x, i)).ToDictionary(x => x.x, x => x.i);
        
        return rules.Where(rule => rowPos.ContainsKey(rule.Item1) && rowPos.ContainsKey(rule.Item2)).All(rule => rowPos[rule.Item1] < rowPos[rule.Item2]);
    }
    public static int Part2(List<(int, int)> rules, List<List<int>> data)
    {
        var invalidRows = data.Where(row => !IsValidRow(rules, row)).ToList();
        
        return invalidRows
            .Select(row => ReorderRow(row, rules))
            .Select(row => row.ElementAt(row.Count / 2))
            .Sum();
    }

    private static List<int> ReorderRow(List<int> row, List<(int, int)> rules)
    {
        var elementOrder = row.ToDictionary(element => element, after => new List<int>());
        
        rules
            .Where(rule => row.Contains(rule.Item1) && row.Contains(rule.Item2))
            .ToList()
            .ForEach(rule => elementOrder[rule.Item1].Add(rule.Item2));
        
        return row.OrderBy(r => elementOrder[r].Count).ToList();
    }
}