using System.Numerics;

namespace day14;

public class Puzzle
{
    private const int Width = 101;
    private const int Height = 103;
    
    public static int Part1(List<(Vector2, Vector2)> robots)
    {   
        var robotsAfterMove = robots.Select(x => MoveRobot(x.Item1, x.Item2, 100)).ToList();
        var robotPositions = robotsAfterMove.Select(robot => robot.Item1).ToList();
        return SafetyFactor(robotPositions);
    }

    private static (Vector2, Vector2) MoveRobot(Vector2 startPos, Vector2 velocity, int steps)
    {
        var newX = (int)(startPos.X + velocity.X * steps) % Width;
        var newY = (int)(startPos.Y + velocity.Y * steps) % Height;
        if (newX < 0) newX += Width;
        if (newY < 0) newY += Height;
        return (new Vector2(newX, newY), velocity);
    }

    private static int SafetyFactor(List<Vector2> positions)
    {
        int[] quads = [0, 0, 0, 0];
        const int midX = Width / 2;
        const int midY = Height / 2;
        foreach (var pos in positions)
        {
            switch (pos)
            {
                case { X: < midX, Y: < midY }:
                    quads[0]++;
                    break;
                case { X: > midX, Y: < midY }:
                    quads[1]++;
                    break;
                case { X: < midX, Y: > midY }:
                    quads[2]++;
                    break;
                case { X: > midX, Y: > midY }:
                    quads[3]++;
                    break;
            }
        }

        return quads.Aggregate(1, (current, quad) => current * quad);
    }
    
    public static int Part2(List<(Vector2, Vector2)> robots)
    {
        var steps = 1;
        var robotsAfterMove = robots.Select(x => MoveRobot(x.Item1, x.Item2, 1)).ToList();
        while (!IsChristmasTree(robotsAfterMove.Select(rob => rob.Item1).ToList()))
        {
            steps++;
            Console.WriteLine($"steps: {steps}");
            robotsAfterMove = robotsAfterMove.Select(x => MoveRobot(x.Item1, x.Item2, 1)).ToList();
        }
        
        return steps;
    }

    private static bool IsChristmasTree(List<Vector2> positions)
    {
        
        
        return true;
    }
}