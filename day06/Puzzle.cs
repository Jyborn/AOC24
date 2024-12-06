namespace day06;

public class Puzzle
{
    private static readonly int[][] Directions =
    [
        [0, -1], //up
        [1, 0], //right
        [0, 1], //down
        [-1, 0], //left
    ];
    
    public static int Part1(List<List<char>> map)
    {
        return MovePlayer(map).Count;
    }

    private static HashSet<(int, int)> MovePlayer(List<List<char>> map)
    {
        int currDir = 0, x = 0, y = 0;
        (x, y) = GetPlayerPosition(map);
        
        var spotsVisited = new HashSet<(int, int)> { (x, y) };

        while (true)
        {
            var dirX = Directions[currDir][0];
            var dirY = Directions[currDir][1];
            
            int newX = x + dirX, newY = y + dirY;

            if (newX < 0 || newX >= map.Count || newY < 0 || newY >= map.Count) 
                break;
            
            if (map[newY][newX] == '#')
            {
                currDir = (currDir + 1) % Directions.Length;
            }
            else
            {
                spotsVisited.Add((newX, newY));
                x = newX;
                y = newY;
            }
        }
        
        return spotsVisited;
    }
    private static (int x, int y) GetPlayerPosition(List<List<char>> map)
    {
        return map.Select((row, index) => (row.IndexOf('^'), index)).First(pos => pos.Item1 != -1);
    }

    public static int Part2(List<List<char>> map)
    {
        var loopObstacles = 0;
        var walkedSpots = MovePlayer(map);
        foreach (var walkedSpot in walkedSpots)
        {
            var currTile = map[walkedSpot.Item2][walkedSpot.Item1];
            if (currTile == '#' || currTile == '^') continue;
            var newMap = map.Select((row => row.ToList())).ToList();
            newMap[walkedSpot.Item2][walkedSpot.Item1] = '#';
            if (IsLoop(newMap))
            {
                loopObstacles++;
            }
        }
        
        return loopObstacles;
    }

    private static bool IsLoop(List<List<char>> map)
    {
        int currDir = 0, x = 0, y = 0;
        (x, y) = GetPlayerPosition(map);
        
        var spotsVisited = new HashSet<(int, int, int)> { (x, y, currDir) };

        while (true)
        {
            var dirX = Directions[currDir][0];
            var dirY = Directions[currDir][1];
            
            int newX = x + dirX, newY = y + dirY;

            if (newX < 0 || newX >= map.Count || newY < 0 || newY >= map.Count)
                break;
            
            if (spotsVisited.Contains((newX, newY, currDir)))
            {
                return true;
            }
            
            if (map[newY][newX] == '#')
            {
                currDir = (currDir + 1) % Directions.Length;
            }
            else
            {
                spotsVisited.Add((newX, newY, currDir));
                x = newX;
                y = newY;
            }
        }

        return false;
    }
}