namespace day07;

public static class Puzzle
{
    public static long Part1(Dictionary<long, long[]> numbers)
    {
        return numbers.ToList().Where(x => IsValidEquation(x, ['*', '+'])).Sum(x => x.Key);
    }

    private static bool IsValidEquation(KeyValuePair<long, long[]> numbers, char[] symbols)
    {
        var target = numbers.Key;
        var terms = numbers.Value;
        
        var operatorOrders = GetCombinations(symbols, terms.Length - 1);

        foreach (var operators in operatorOrders)
        {
            var total = terms[0];
            for (var i = 0; i < operators.Length; i++)
            {   
                switch (operators[i])
                {
                    case '+': total += terms[i + 1]; break;
                    case '*': total *= terms[i + 1]; break;
                    case '|': total = long.Parse(total.ToString() + terms[i + 1]); break;
                }   
            }
            if (total == target) return true;
        }
        return false;
    }

    private static List<char[]> GetCombinations(char[] symbols, int length)
    {
        var results = new List<char[]>();
        var combination = new char[length];
        GenerateCombinations(symbols, combination, 0, results);
        return results;
    }
    
    private static void GenerateCombinations(char[] symbols, char[] combination, int position, List<char[]> results)
    {
        if (position == combination.Length)
        {
            results.Add((char[])combination.Clone());
            return;
        }

        foreach (var symbol in symbols)
        {
            combination[position] = symbol;
            GenerateCombinations(symbols, combination, position + 1, results);
        }
    }
    public static long Part2(Dictionary<long, long[]> numbers)
    {
        
        return numbers.ToList().Where(x => IsValidEquation(x, ['*', '+', '|'])).Sum(x => x.Key);
    }
}