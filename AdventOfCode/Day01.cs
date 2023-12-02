using System.Text.RegularExpressions;

namespace AdventOfCode;

public class Day01 : BaseDay
{
    private readonly List<string> _input;
    private readonly int _result;

    public Day01()
    {
        // Read input file
        _input = File.ReadAllLines(InputFilePath).ToList();

        // Get only number 
        _input = _input.Select(x => Regex.Replace(x, @"[^0-9]", "")).ToList();
        // Agregate first and last number. Sum all
        _result = _input.Select(x => x[0] + x[^1].ToString()).ToList().Sum(x => int.Parse(x));

    }

    public override ValueTask<string> Solve_1() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is {_result}");

    public override ValueTask<string> Solve_2() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 2");
}
