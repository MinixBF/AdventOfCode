using System;
using System.Collections.Generic;
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
            var counter = 0;
            foreach (var line in _input)
            {
                var split = line.Split(':');
                // Get Card Number : Card 1 with paterd Card %d
                var allNumbers = split[1].Split('|');
                var winNumbers = allNumbers[0].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToList();
                var numbers = allNumbers[1].Split(' ').Where(x => !string.IsNullOrWhiteSpace(x)).Select(int.Parse).ToList();
                Cards.Add(new Card(counter++, winNumbers, numbers));
            }
            Console.WriteLine(Cards.Count);

            var result = 0;
            foreach (var card in Cards)
            {
                var matches = 0;
                foreach (var winNumber in card.WinNumbers)
                {
                    if (card.Numbers.Contains(winNumber))
                    {
                        matches++;
                    }
                }
                if(matches > 0)
                {
                    _resultPart1 += Math.Pow(2, matches - 1);
                    result += matches;
                }
            }
        }

        public override ValueTask<string> Solve_1() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is {_resultPart1}");

        public override ValueTask<string> Solve_2() => new();
    }

    public record Card(int id, List<int> WinNumbers, List<int> Numbers);
}
