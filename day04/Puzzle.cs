namespace day04;

public class Puzzle
{
    private static readonly int[][] Directions =
    [
        [0, 1],
        [1, 0],
        [0, -1],
        [-1, 0],
        [1, 1],
        [-1, 1],
        [1, -1],
        [-1, -1]
    ];
    
    public static int Part1(char[,] grid, string word)
    {
        var occurrences = 0;
        var rows = grid.GetLength(0);
        var cols = grid.GetLength(1);
        for (var x = 0; x < rows; x++)
        {
            for (var y = 0; y < cols; y++)
            {
                foreach (var direction in Directions)
                {
                    for (var w = 0; w < word.Length; w++)
                    {
                        var newX = x + w * direction[0];
                        var newY = y + w * direction[1];
                        if (newX < 0 || newX >= rows || newY < 0 || newY >= cols || grid[newX, newY] != word[w]) 
                            break;

                        if (w == word.Length - 1)
                            occurrences++;
                    }
                }
            }
            
        }
        
        return occurrences;
    }

    public static int Part2(char[,] grid)
    {
        var occurrences = 0;
        var rows = grid.GetLength(0);
        var cols = grid.GetLength(1);
        for (var x = 1; x < rows - 1; x++)
        {
            for (var y = 1; y < cols - 1; y++)
            {
                if (grid[x, y] != 'A') continue;
                //topLeft - botRight
                var diagonal1 = (grid[x - 1, y - 1] == 'M' && grid[x + 1, y + 1] == 'S') ||
                                (grid[x - 1, y - 1] == 'S' && grid[x + 1, y + 1] == 'M');
                //topRight - botLeft
                var diagonal2 = (grid[x + 1, y - 1] == 'M' && grid[x - 1, y + 1] == 'S') ||
                                (grid[x + 1, y - 1] == 'S' && grid[x - 1, y + 1] == 'M');
                    
                if (diagonal1 && diagonal2) occurrences++;
            }
        }

        return occurrences;
    }
}