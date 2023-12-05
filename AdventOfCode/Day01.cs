using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly List<string> _input;
    private readonly int _resultPart1;
    private readonly int _resultPart2;

    public Day01()
    {

        // Read input file
        _input = File.ReadAllLines(InputFilePath).ToList();

        // Part 1
        // Get only number clean 
        var part1 = _input.Select(x => Regex.Replace(x, @"[^0-9]", "")).Where(x => !string.IsNullOrEmpty(x)).ToList();
        // Agregate first and last number. Sum all
        _resultPart1 = part1.Select(x => x[0] + x[^1].ToString()).ToList().Sum(x => int.Parse(x));

        // Part 2
        Dictionary<string, int> DictWord = new()
        {
            {"twone", 21 },
            {"eightwo", 82 },
            {"oneight", 18 },

            {"one", 1},
            {"two", 2},
            {"three", 3},
            {"four", 4},
            {"five", 5},
            {"six", 6},
            {"seven", 7},
            {"eight", 8},
            {"nine", 9}
        };
        
        var part2 = _input.Select(x => Regex.Replace(x, @"(twone|eightwo|oneight|one|two|three|four|five|six|seven|eight|nine)", m => DictWord.ContainsKey(m.Value) ? DictWord[m.Value].ToString() : "")).Where(x => !string.IsNullOrEmpty(x)).ToList();
        _resultPart2 = part2.Select(x => Regex.Replace(x, @"[^0-9]", "")).Where(x => !string.IsNullOrEmpty(x)).ToList().Select(x => x[0] + x[^1].ToString()).ToList().Sum(x => int.Parse(x));
    }

    public override ValueTask<string> Solve_1() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is {_resultPart1}");

    public override ValueTask<string> Solve_2() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 2 is {_resultPart2}");

    
}