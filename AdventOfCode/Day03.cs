using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day03 : BaseDay
    {
        private readonly List<string> _input;
        private readonly int _resultPart1;
        private readonly int _resultPart2;

        public Day03()
        {
            _input = File.ReadAllLines(InputFilePath).ToList();
            /* 
             467..114..
             ...*......
             ..35..633.
             ......#...
             617*......
             .....+.58.
             ..592.....
             ......755.
             ...$.*....
             .664.598..
            */

            // In this schematic, two numbers are not part numbers because they are not adjacent to a symbol: 114 (top right) and 58 (middle right).
            // Every other number is adjacent to a symbol and so is a part number; their sum is 4361
            var GameTables = new List<Table>();
            foreach (var input in _input)
            {
                var rows = input.ToString();
                //  467..114.. => 467 114
                var numbers = rows.Split(".").Where(x => 
                    // exclude empty string and symbol 
                    !string.IsNullOrEmpty(x) && int.TryParse(x, out var _)
                    ).ToList();
                foreach (var num in numbers)
                {

                    GameTables.Add(new Table(0, rows, "", ""));
                }
            }   

        }

        public override ValueTask<string> Solve_1() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is {_resultPart1}");

        public override ValueTask<string> Solve_2() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 2 is {_resultPart2}");
    }

    public record Table(int Number, string Rows, string Columns, string Diagonals);
}
