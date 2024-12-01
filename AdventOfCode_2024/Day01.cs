using AoCHelper;

namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly List<string> inputLines;
    private readonly long _resultPart1;
    private readonly long _resultPart2;

    public Day01()
    {
        // Read input file
        inputLines = [.. File.ReadAllLines(InputFilePath)];

        // Get only number clean 
        List<long> left = [];
        List<long> right = [];
        foreach (var line in inputLines)
        {
            var split = line.Split(' ');
            left.Add(long.Parse(split[0]));
            right.Add(long.Parse(split[3]));
        }

        var sortedLeft = left.OrderBy(x => x).ToList();
        var sortedRight = right.OrderBy(x => x).ToList();

        for (int i = 0; i < sortedLeft.Count; i++)
        {
            // Calculer la différence absolue (Part 1)
            _resultPart1 += Math.Abs(sortedLeft[i] - sortedRight[i]);

            // Calculer les occurrences multipliées (Part 2)
            _resultPart2 += left[i] * right.Count(n => n == left[i]);
        }
    }

    public override ValueTask<string> Solve_1() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is {_resultPart1}");

    public override ValueTask<string> Solve_2() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 2 is {_resultPart2}");

    
}