using System.Numerics;

namespace day13;

public class Puzzle
{
    public static int Part1(List<Machine> machines)
    {
        return machines.Select(SolveMachine).Sum(x => x);
    }

    private static int SolveMachine(Machine machine)
    {
        var (prizeX, prizeY) = (machine.P.X, machine.P.Y);
        var minCost = int.MaxValue;
        
        for (var aPresses = 0; aPresses <= 100; aPresses++)
        {
            for (var bPresses = 0; bPresses <= 100; bPresses++)
            {
                var currentX = machine.A.DeltaX * aPresses + machine.B.DeltaX * bPresses;
                var currentY = machine.A.DeltaY * aPresses + machine.B.DeltaY * bPresses;
                
                if (currentX == prizeX && currentY == prizeY)
                {
                    var cost = 3 * aPresses + bPresses;
                    
                    if (cost < minCost)
                    {
                        minCost = cost;
                    }
                }
            }
        }
        
        return minCost == int.MaxValue ? 0 : minCost;
    }
    
    public static long Part2(List<Machine> machines)
    {
        var newMachines = new List<Machine>();
        machines.ForEach(x => newMachines.Add(x with { P = new Prize(x.P.X + 10000000000000, x.P.Y + 10000000000000) }));
        newMachines.ForEach(x => Console.WriteLine(x.ToString()));
        
        
        
        return newMachines.Select(BetterSolve).Sum(x => x);
    }

    private static long BetterSolve(Machine machine)
    {
        return 0;
    }
}