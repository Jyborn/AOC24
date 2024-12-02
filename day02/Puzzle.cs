namespace day02;

public class Puzzle
{
    public static int Part1()
    {
        using FileStream fs = new ("input.txt", FileMode.Open, FileAccess.Read);
        using StreamReader sr = new (fs);
        string line;
        int safeReports = 0;
        while ((line = sr.ReadLine()) is not null)
        {
            var levels = line.Split(new []{' ', '\t'}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            
            if (IsSafeReport(levels)) safeReports++;
            
        }
        return safeReports;
    }

    private static bool IsSafeReport(List<int> level)
    {
        bool isIncreasing = true;
        bool isDecreasing = true;

        for (int i = 1; i < level.Count; i++)
        {
            var diff = level[i] - level[i - 1];
            if (Math.Abs(diff) is < 1 or > 3) return false;
            
            if (diff < 0) isIncreasing = false;
            if (diff > 0) isDecreasing = false;
        }
        return isIncreasing || isDecreasing;
    }

    public static int Part2()
    {
        using FileStream fs = new ("input.txt", FileMode.Open, FileAccess.Read);
        using StreamReader sr = new (fs);
        string line;
        int safeReports = 0;
        while ((line = sr.ReadLine()) is not null)
        {
            var levels = line.Split(new []{' ', '\t'}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            
            if (IsSafeReport(levels) || RemoveOneIsSafeReport(levels)) safeReports++;
            
        }
        return safeReports;
    }

    private static bool RemoveOneIsSafeReport(List<int> levels)
    {
        for (int i = 0; i < levels.Count; i++)
        {
            var newLevels = levels.Where((_, index) => index != i).ToList();
            if (IsSafeReport(newLevels))
            {
                return true;
            }
        }
        return false;
    }
}