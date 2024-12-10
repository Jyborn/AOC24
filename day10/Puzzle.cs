using System.Numerics;

namespace day10;

public class Puzzle
{
    private static readonly Vector2[] Directions =
    [
        new(0, -1),
        new(1, 0),
        new(0, 1),
        new(-1, 0)
    ];
    
    public static int Part1(List<char[]> grid)
    {
        return Execute(true, grid);
    }

    private static void Explore(List<char[]> grid, Vector2 pos, int height, ref List<Vector2> peaks, bool isPart1)
    {
        if ((isPart1 && height == 9 && !peaks.Contains(pos)) || (!isPart1 && height == 9))
        {
            peaks.Add(pos);
        }
        else
        {
            foreach (var dir in Directions)
            {
                var newX = (int) (pos.X + dir.X);
                var newY = (int) (pos.Y + dir.Y);
                if (newX < 0 || newX >= grid[0].Length || newY < 0 || newY >= grid.Count) continue;
                var nextHeight = height + 1;
                if (int.Parse(grid[newY][newX].ToString()) - nextHeight == 0)
                {
                    Explore(grid, new Vector2(newX, newY), nextHeight, ref peaks, isPart1);
                }
            }
            
        }
    }

    private static int Execute(bool isPart1, List<char[]>grid)
    {
        var startPositions = grid
            .SelectMany((row, rowIndex) => 
                row.Select((ch, colIndex) => new { ch, rowIndex, colIndex }))
            .Where(x => x.ch == '0')
            .Select(x => new Vector2(x.colIndex, x.rowIndex))
            .ToList();

        List<int> peaksPerPosition = [];
        foreach (var pos in startPositions)
        {
            List<Vector2> peaks = new();
            var height = 0;
            Explore(grid, pos, height, ref peaks, isPart1);
            peaksPerPosition.Add(peaks.Count);
        }
        
        return peaksPerPosition.Sum();
    }
    public static int Part2(List<char[]> grid)
    {
        return Execute(false, grid);
    }
}