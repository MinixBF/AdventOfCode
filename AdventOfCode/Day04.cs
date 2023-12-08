using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day04 : BaseDay
    {
        private readonly List<string> _input;
        private readonly double _resultPart1;
        private readonly int _resultPart2;

        public Day04()
        {
            _input = File.ReadAllLines(InputFilePath).ToList();

            /*
                Card 1: 41 48 83 86 17 | 83 86  6 31 17  9 48 53
                Card 2: 13 32 20 16 61 | 61 30 68 82 17 32 24 19
                Card 3:  1 21 53 59 44 | 69 82 63 72 16 21 14  1
                Card 4: 41 92 73 84 69 | 59 84 76 51 58  5 54 83
                Card 5: 87 83 26 28 32 | 88 30 70 12 93 22 82 36
                Card 6: 31 18 13 56 72 | 74 77 10 23 35 67 36 11
                
                Card 1 : 48 83 17 86 -> 8 points
                Card 2 : 32 61 -> 2 points
                Card 3 : 1 21 -> 2 points
                Card 4 : 84 -> 1 points

                (1 points for the first match, then doubled three times for each of the three matches after the first).

             */


            var Cards = new List<Card>();
            var counter = 1;
            
            // PARSE INPUT
            foreach (var line in _input)
            {
                var split = line.Split(':', '|');
                // Get Card Number : Card 1 with paterd Card %d
                var winNumbers = split[1].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToList();
                var numbers = split[2].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToList();
                Cards.Add(new Card(counter++, winNumbers, numbers, numbers.Intersect(winNumbers).Count()));
            }

            // PART 1
            _resultPart1 = Cards.Sum(c => Math.Pow(2, c.matches - 1));

            // PART 2 
            var range = Cards.Select(c => 1).ToList();
            for (var i = 0; i < Cards.Count; i++)
            {
                for (var j = 0; j < Cards[i].matches; j++)
                {
                    range[i + j + 1] += range[i];
                }
            }
            _resultPart2 = range.Sum();
        }

        public override ValueTask<string> Solve_1() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is {_resultPart1}");

        public override ValueTask<string> Solve_2() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is {_resultPart2}");
    }
    public record Card(int id, List<int> WinNumbers, List<int> Numbers, int matches);

    
}
