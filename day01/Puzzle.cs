namespace day01;

public class Puzzle
{
    public static int Part1(List<int> col1, List<int> col2)
    {
        col1.Sort();
        col2.Sort();
        var totalDiff = col1.Zip(col2, (x, y) => Math.Abs(x - y)).Sum();
        return totalDiff;
    }

    public static int Part2(List<int> col1, List<int> col2)
    {
        var col2Uniques = col2.GroupBy(x => x).Select(g => (Number: g.Key, Count: g.Count())).ToDictionary();
        return col1.Select(x => col2Uniques.TryGetValue(x, out var occurrences) ? occurrences * x : 0 ).Sum();
    }
}