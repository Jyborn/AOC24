namespace day19;

public class Puzzle
{
    public static int Part1(List<string> towels, List<string> designs)
    {
        return designs.Count(design => IsPossible(design, towels));
    }

    private static bool IsPossible(string design, List<string> towels)
    {
        var dp = new bool[design.Length + 1];
        dp[0] = true;

        for (var i = 0; i <= design.Length; i++)
        {
            Console.WriteLine($" Design: {design}, i: {i}, dp[i]: {dp[i]}");
            if (!dp[i]) continue;
            foreach (var towel in towels)
            {
                if (i + towel.Length <= design.Length && towel == design.Substring(i, towel.Length))
                {
                    Console.WriteLine($"used towel: {towel}");
                    dp[i + towel.Length] = true;
                }
            }
        }

        return dp[design.Length];
    }
    public static int Part2(List<string> towels, List<string> designs)
    {
        return designs.Select(design => IsPossibleCombinations(design, towels)).Sum(x => x);
    }
    
    private static int IsPossibleCombinations(string design, List<string> towels)
    {
        var dp = new bool[design.Length + 1];
        dp[0] = true;
        var combinations = 0;
        for (var i = 0; i <= design.Length; i++)
        {
            if (!dp[i]) continue;
            var matches = 0;
            foreach (var towel in towels)
            {
                if (i + towel.Length <= design.Length && towel == design.Substring(i, towel.Length))
                {
                    matches++;
                    Console.WriteLine("TEST " + i + " " + towel);
                    dp[i + towel.Length] = true;
                }
            }

            if (matches > 1) combinations += matches;
        }
        
        if (combinations == 0) combinations = 1;
        if (dp[design.Length]) Console.WriteLine($"Design: {design}, result: {combinations}");
        return dp[design.Length] ? combinations : 0;
    }
    
}