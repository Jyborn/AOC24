using System.Runtime.InteropServices.ComTypes;

namespace day11;

public class Puzzle
{
    public static int Part1(string input, int nBlinks)
    {
        var numbers = input.Split(" ").Select(long.Parse).ToList();
        for (var i = 0; i < nBlinks; i++)
        {
            //Console.WriteLine(string.Join(" ", numbers));
            Console.WriteLine($"blink {i}");
            numbers = numbers.SelectMany(number => Blink(number)).ToList();
        }
        return numbers.Count;
    }


    private static List<long> Blink(long number)
    {
        var numString = number.ToString();
        if (number == 0) { return [1]; }
        if (numString.Length % 2 == 0)
        {
            var split1 = numString[..(numString.Length / 2)];
            var split2 = numString[(numString.Length / 2)..].TrimStart('0');
            return [long.Parse(split1), long.Parse(split2.Length > 0 ? split2 : "0")];
        }
        return [number * 2024];
    }
    
    public static long Part2(string input, int nBlinks)
    {
        var numbers = input.Split(" ").ToList();
        
        //<number, occurrences>
        var numberOccs = numbers.Select(long.Parse).GroupBy(x => x).ToDictionary(g => g.Key, g => (long) g.Count());

        for (var i = 0; i < nBlinks; i++)
        {
            numberOccs.ToList().ForEach(x =>
            {
                var newNumbs = Blink(x.Key);
                var occs = x.Value;
                numberOccs[x.Key] -= occs;
                foreach (var newNumb in newNumbs)
                {
                    if (!numberOccs.ContainsKey(newNumb))
                        numberOccs[newNumb] = occs;
                    else
                        numberOccs[newNumb] += occs;
                }
                
                if (numberOccs[x.Key] <= 0)
                    numberOccs.Remove(x.Key);
            });
        }
        return numberOccs.ToList().Where(x => x.Value > 0).Sum(x => x.Value);
    }
}