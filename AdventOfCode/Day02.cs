using System.Text.RegularExpressions;

namespace AdventOfCode
{
    public class Day02 : BaseDay
    {
        private readonly List<string> _input;
        private readonly int _resultPart1;
        private readonly int _resultPart2;

        public Day02()
        {
            _input = File.ReadAllLines(InputFilePath).ToList();
            // Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green

            var listGame = new List<Game>();
            foreach (var item in _input)
            {
                listGame.Add(ParseGame(item));
            }

            // Part 1
            var listGameIds = listGame
                .Where(x => x.Red <= 12 && x.Green <= 13 && x.Blue <= 14)
                .Select(x => x.Id).ToList();
            _resultPart1 = listGameIds.Sum();


            // Part 2
            var listGameIds2 = listGame
                .Select(x => x.Red * x.Green * x.Blue)
                .ToList();

            _resultPart2 = listGameIds2.Sum();
        }

        Game ParseGame(string intput)
        {
            // Get id, max 3 color 
            
            return new Game(
                Id: int.Parse(Regex.Match(intput, @"\d+").Value),
                Red: CalculateMaxOfColor(intput, "red"),
                Green: CalculateMaxOfColor(intput, "green"),
                Blue: CalculateMaxOfColor(intput, "blue")
            );
        }

        public int CalculateMaxOfColor(string input, string color)
        {
            // 1 red get => 1 
            var regex = new Regex($@"\d+ {color}");
            var matches = regex.Matches(input);
            var max = matches.Select(x => int.Parse(x.Value.Split(" ")[0])).Max();
            return max;
        }

        public override ValueTask<string> Solve_1() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is {_resultPart1}");

        public override ValueTask<string> Solve_2() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 2 is {_resultPart2}");
    }

    

    record Game(int Id, int Red, int Green, int Blue);
}
