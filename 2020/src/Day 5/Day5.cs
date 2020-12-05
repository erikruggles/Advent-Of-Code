using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day_5
{
    public class Day5
    {
        public static int FindMySeatId()
        {
            var boardingPasses = Day5Input.ParseBoardingPasses();
            var seatIds = boardingPasses.Select(b => b.DetermineSeatId()).OrderBy(s => s);

            var (minRow, minSeatId) = DetermineMinimumRowFromListOfSeatIds(seatIds);
            var (maxRow, maxSeatId) = DetermineMaximumRowFromListOfSeatIds(seatIds);

            var missingSeat = Enumerable.Range(minSeatId, maxSeatId- minSeatId).Except(seatIds);

            return missingSeat.First();
        }

        public static (int row, int seatId) DetermineMinimumRowFromListOfSeatIds(IEnumerable<int> seatIds)
        {
            var minSeatId = seatIds.Min();
            return ((minSeatId - (minSeatId % 8)) / 8, minSeatId);
        }

        public static (int row, int seatId) DetermineMaximumRowFromListOfSeatIds(IEnumerable<int> seatIds)
        {
            var maxSeatId = seatIds.Max();
            return ((maxSeatId - (maxSeatId % 8)) / 8, maxSeatId);
        }
    }
}