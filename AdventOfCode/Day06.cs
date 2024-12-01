using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode
{
    public class Day06 : BaseDay
    {
        private readonly List<string> _input;
        private readonly double _resultPart1;
        private readonly int _resultPart2;

        public Day06()
        {
            _input = File.ReadAllLines(InputFilePath).ToList();

            /*
                Time:      7  15   30
                Distance:  9  40  200

                Your toy boat has a starting speed of zero millimeters per millisecond. For each whole millisecond you spend at the beginning of the race holding down the button, the boat's speed increases by one millimeter per millisecond.
                
                options : 
            Don't hold the button at all (that is, hold it for 0 milliseconds) at the start of the race. The boat won't move; it will have traveled 0 millimeters by the end of the race.
            Hold the button for 1 millisecond at the start of the race. Then, the boat will travel at a speed of 1 millimeter per millisecond for 6 milliseconds, reaching a total distance traveled of 6 millimeters.
            Hold the button for 2 milliseconds, giving the boat a speed of 2 millimeters per millisecond. It will then get 5 milliseconds to move, reaching a total distance of 10 millimeters.
            Hold the button for 3 milliseconds. After its remaining 4 milliseconds of travel time, the boat will have gone 12 millimeters.
            Hold the button for 4 milliseconds. After its remaining 3 milliseconds of travel time, the boat will have gone 12 millimeters.
            Hold the button for 5 milliseconds, causing the boat to travel a total of 10 millimeters.
            Hold the button for 6 milliseconds, causing the boat to travel a total of 6 millimeters.
            Hold the button for 7 milliseconds. That's the entire duration of the race. You never let go of the button. The boat can't move until you let go of the button. Please make sure you let go of the button so the boat gets to move. 0 millimeters.
            */

            //var Time = new List<int>();
            //var Distance = new List<int>();
            //Time.AddRange(Parse(_input[0]));
            //Distance.AddRange(Parse(_input[1]));

            //var result = 0;
            //for (var i = 0; i < Time.Count; i++)
            //{
            //    var time = Time[i];
            //    var distance = Distance[i];
            //}



            //List<int> Parse(string input)
            //{
            //    return input.Split(':')[1].Trim().Split(' ').Select(int.Parse).ToList();
            //}
        }
        public override ValueTask<string> Solve_1() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is {_resultPart1}");

        public override ValueTask<string> Solve_2() => new($"Solution to {ClassPrefix} {CalculateIndex()}, part 1 is {_resultPart2}");
    }
}
