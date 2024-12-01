using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day07 : BaseDay
    {
        private readonly List<string> _input;
        private readonly double _resultPart1;
        private readonly int _resultPart2;

        public Day07()
        {
            _input = File.ReadAllLines(InputFilePath).ToList();

            long PatternValue(string hand) => Pack(hand.Select(card => hand.Count(x => x == card)).OrderDescending());

            long CardValue(string hand, string cardOrder) => Pack(hand.Select(card => cardOrder.IndexOf(card)));

            long Pack(IEnumerable<int> numbers) => numbers.Aggregate(1L, (a, v) => (a * 256) + v);

            var cardOrder = "123456789TJQKA";
            var hands = _input.Select(line => new CammelCard
            {
                Hand = line.Split(" ")[0].Trim(),
                Bid = int.Parse(line.Split(" ")[1].Trim())
            }).ToList();

            var handsSorted = new List<CammelCard>();
            foreach (var hand in hands)
            {
                var test = hand.Hand.Select(card => cardOrder.IndexOf(card)).ToList();
                //9A34Q becomes(8)(13)(2)(3)(11)

            }

            // big * index (rank)
            _resultPart1 = handsSorted.Select((h, i) => h.Bid * i+1).Sum();
        }
        public override ValueTask<string> Solve_1() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is {_resultPart1}");

        public override ValueTask<string> Solve_2() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is {_resultPart2}");
    }

    public class CammelCard
    {
        public string Hand { get; set; }
        public int Bid { get; set; }
        public int value { get; set; }
    }
}
