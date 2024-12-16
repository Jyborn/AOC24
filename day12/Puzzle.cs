namespace day12;

public class Puzzle
{
    private static readonly int[][] Directions =
    [
        [-1, 0],
        [0, 1],
        [1, 0],
        [0, -1],
    ];
    public static int Part1(List<List<char>> grid)
    {
        grid.ForEach(row => Console.WriteLine(string.Join("", row)));
        
        var visited = new List<(int row, int col)>();
        var price = 0;
        for (var row = 0; row < grid.Count; row++)
        {
            for (var col = 0; col < grid[row].Count; col++)
            {
                if (visited.Contains((row, col))) continue;
                var region = GetRegion(grid, (row, col));
                var area = region.Count;
                var perim = GetPerimeter1(region);
                Console.WriteLine($"Area: {area}, Perimeter: {perim}, price: {area * perim}, totalPrice: {price}");
                price += area * perim;
                visited.AddRange(region);
                Console.WriteLine($"Visited: {visited.Count}");
            }
        }
        
        return price;
    }

    private static List<(int, int)> GetRegion(List<List<char>> grid, (int row, int col) pos)
    {
        var type = grid[pos.row][pos.col];

        var region = new List<(int row, int col)>() {pos};
        var queue = new Queue<(int row, int col)>();
        queue.Enqueue((pos.row, pos.col));
        while (queue.Count > 0)
        {
            var currPos = queue.Dequeue();
            for (var dir = 0; dir < Directions.Length; dir++)
            {
                var newRow = currPos.row + Directions[dir][0];
                var newCol = currPos.col + Directions[dir][1];

                if (newRow < 0 || newRow >= grid.Count || newCol < 0 || newCol >= grid[newRow].Count 
                    || grid[newRow][newCol] != type || region.Contains((newRow, newCol)))
                    continue;
                region.Add((newRow, newCol));
                queue.Enqueue((newRow, newCol));
            }
        }
        Console.WriteLine($"Region {type}: {string.Join(",", region.Select(row => row.ToString()))}");
        return region;
    }

    private static int GetPerimeter1(List<(int row, int col)> region)
    {
        var totalEdges = 0;
        foreach (var (row, col) in region)
        {
            var edges = 4;
            
            if (region.Contains((row - 1, col))) edges--;
            if (region.Contains((row + 1, col))) edges--;
            if (region.Contains((row, col - 1))) edges--;
            if (region.Contains((row, col + 1))) edges--; 
            
            totalEdges += edges;
        }
        
        return totalEdges;
    }
    
    public static int Part2(List<List<char>> grid)
    {
        grid.ForEach(row => Console.WriteLine(string.Join("", row)));
        
        var visited = new List<(int row, int col)>();
        var price = 0;
        for (var row = 0; row < grid.Count; row++)
        {
            for (var col = 0; col < grid[row].Count; col++)
            {
                if (visited.Contains((row, col))) continue;
                var region = GetRegion(grid, (row, col));
                var area = region.Count;
                var perim = GetPerimeter2(region);
                Console.WriteLine($"Area: {area}, Sides: {perim}, price: {area * perim}, totalPrice: {price}");
                price += area * perim;
                visited.AddRange(region);
                Console.WriteLine($"Visited: {visited.Count}");
            }
        }
        
        return price;
    }

    private static int GetPerimeter2(List<(int row, int col)> region)
    {
        
		//Todo: calculate shared sides of region

		return 0;
    }
}