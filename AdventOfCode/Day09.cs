namespace AdventOfCode
{
    public class Day09 : BaseDay
    {
        private readonly List<string> _input;
        private readonly long _resultPart1;
        private readonly long _resultPart2;

        public Day09()
        {
            _input = File.ReadAllLines(InputFilePath).ToList();

            List<Sensor> SensorValues = _input.Select(Parse).ToList();

            SensorValues.ForEach(sensor => sensor.CalculateDifferences());
            _resultPart1 = SensorValues.Select(sensor => sensor.NextValueDiffAndValues().Last().Last()).Sum();
            _resultPart2 = SensorValues.Select(sensor => sensor.PastValueDiffAndValues().Last().First()).Sum();

            Sensor Parse(string input)
            {
                var sensor = new Sensor();
                sensor.Values.AddRange(input.Split(' ').Select(long.Parse).ToList());
                sensor.Differences.Add(sensor.GenerateFirstDiffSquence());
                return sensor;
            }
        }
        public override ValueTask<string> Solve_1() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is {_resultPart1}");

        public override ValueTask<string> Solve_2() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is {_resultPart2}");
    }

    class Sensor
    {
        public List<long> Values { get; set; }
        public List<List<long>> Differences { get; set; }
        public Sensor()
        {
                Values = new List<long>();
                Differences = new List<List<long>>();
        }

        public void CalculateDifferences()
        {
            // from the top to the bottom
            // While the last value is not list of 0 
            while (Differences.Last().Any(x => x != 0))
            {
                Differences.Add(NextDiffList(Differences.Last()));
            }
            
        }

        public List<long> NextDiffList(List<long> differences)
        {
            // 10  13  16  21  30  45 values
            //  3   3   5   9  15 differences
            //   0   2   4   6 -> need to be generated

            var nextDiff = new List<long>();
            for (var i = 0; i < differences.Count -1; i++)
            {
                nextDiff.Add(differences[i + 1] - differences[i]);
            }
            return nextDiff;
        } 


        // z: 0   3   6   9  12  15  B -> Values
        // x: 3   3   3   3   3  A -> Differences
        // y:   0   0   0   0   0 -> need to be generated
        public List<List<long>> NextValueDiffAndValues()
        {
            var AllValues = new List<List<long>>(Differences);
            // To Values to top of list
            AllValues.Insert(0, Values);
            // Reverse list
            AllValues.Reverse();
            for (var i = 0; i < AllValues.Count; i++)
            {
                if (i == 0) AllValues[i].Add(AllValues[i].Last());
                else
                {
                    var last = AllValues[i].Last();
                    var diff = AllValues[i - 1].Last();
                    var next = last + diff;
                    AllValues[i].Add(next);
                }
            }
            return AllValues;
        }

        public List<List<long>> PastValueDiffAndValues()
        {
            var AllValues = new List<List<long>>(Differences);
            // To Values to top of list
            AllValues.Insert(0, Values);
            // Reverse list
            AllValues.Reverse();
            for (var i = 0; i < AllValues.Count; i++)
            {
                if (i == 0) AllValues[i].Insert(0, AllValues[i].First());
                else
                {
                    var last = AllValues[i].First();
                    var diff = AllValues[i - 1].First();
                    var next = last - diff;
                    AllValues[i].Insert(0, next);
                }
            }
            return AllValues;
        }

        public List<long> GenerateFirstDiffSquence()
        {
            return NextDiffList(Values);
        }


        //public long GetNextValue()
        //{

        //}
    }
}
