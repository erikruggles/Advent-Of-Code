using System.Collections.Generic;

namespace AdventOfCode2020.Day_8
{
    public class Day8
    {
        public static int FindAccumulatorValueAtEndOfLoop()
        {
            var computer = Day8Input.CreateComputerFromInput();
            var visitedIndexes = new List<int>();
            var (currentIndex, accumulator) = computer.PerformNextInstruction();
            while (!visitedIndexes.Contains(currentIndex))
            {
                visitedIndexes.Add(currentIndex);
                (currentIndex, accumulator) = computer.PerformNextInstruction();
            }

            return accumulator;
        }
    }
}