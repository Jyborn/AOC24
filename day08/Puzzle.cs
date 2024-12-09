using System.Numerics;

namespace day08;

public class Puzzle
{
    
    // varje freq kolla distance till alla samma freq row, cols och se om pos +- distance är utanför
    public static int Part1(List<string> map)
    {
        var frequencies = GetFrequencyPositions(map);
        var bounds = new Vector2(map.Count, map[0].Length);
        return (
                from frequency in frequencies
                select frequency.Value
                into positions
                from pair in
                    positions.SelectMany((position1, i) =>
                            positions.Where((position2, j) => i != j),
                        (position1, position2) => new { position1, position2 })
                select HasValidAntinode(pair.position1, pair.position2, bounds))
            .OfType<Vector2?>()
            .Select(validAntinode => validAntinode.Value)
            .ToList().Distinct().Count();
    }

    private static Dictionary<char, List<Vector2>> GetFrequencyPositions(List<string> map)
    {
        var frequencies = new Dictionary<char, List<Vector2>>();
        for (var i = 0; i < map.Count; i++)
        {
            for (var j = 0; j < map[i].ToCharArray().Length; j++)
            {
                if (map[i][j] == '.') continue;
                if (!frequencies.ContainsKey(map[i][j]))
                { 
                    frequencies[map[i][j]] = [];   
                }
                frequencies[map[i][j]].Add(new Vector2(i, j));
            }
        }
        return frequencies;
    }

    private static Vector2? HasValidAntinode(Vector2 current, Vector2 other, Vector2 bounds)
    {
        var distance = (current.X - other.X, current.Y - other.Y);
        var newPos = new Vector2(current.X + distance.Item1, current.Y + distance.Item2);
        if (newPos.X >= 0 && newPos.X <= bounds.X - 1 && newPos.Y >= 0 && newPos.Y <= bounds.Y - 1)
        {
            return newPos;
        }

        return null;
    }
    public static int Part2()
    {
        return 0;
    }
}