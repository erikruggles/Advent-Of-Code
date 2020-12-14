using System;

namespace AdventOfCode2020.Day_11
{
    public class SeatingAreaSimulator
    {
        public static SeatingArea FindStableSeatingArea()
        {
            var currentSeatingArea = Day11Input.GenerateSeatingAreaFromInput();
            return FindStableSeatingArea(currentSeatingArea,
                (seatingArea, y, x) => seatingArea.DetermineNewSeatStateUsingAdjacentRules(y, x));
        }

        public static SeatingArea FindStableSeatingAreaUsingNewMethod()
        {
            var currentSeatingArea = Day11Input.GenerateSeatingAreaFromInput();
            return FindStableSeatingArea(currentSeatingArea,
                (seatingArea, y, x) => seatingArea.DetermineNewSeatStateUsingLineOfSightRules(y, x));
        }

        public static SeatingArea FindStableSeatingArea(SeatingArea seatingArea,
            Func<SeatingArea, int, int, int> determineNewSeatMethod)
        {
            var currentSeatingArea = seatingArea;
            var nextSeatingArea = FindNextSeatingArea(currentSeatingArea, determineNewSeatMethod);

            while (currentSeatingArea != nextSeatingArea)
            {
                currentSeatingArea = nextSeatingArea;
                nextSeatingArea = FindNextSeatingArea(currentSeatingArea, determineNewSeatMethod);
            }

            return currentSeatingArea;
        }

        private static SeatingArea FindNextSeatingArea(SeatingArea currentSeatingArea, Func<SeatingArea, int, int, int> determineNewSeatMethod)
        {
            var newArea = new int[currentSeatingArea.Floor.GetLength(0), currentSeatingArea.Floor.GetLength(1)];

            for (var y = 0; y < newArea.GetLength(0); y++)
            {
                for (var x = 0; x < newArea.GetLength(1); x++)
                {
                    newArea[y, x] = determineNewSeatMethod(currentSeatingArea, y, x);
                }
            }

            return new SeatingArea(newArea);
        }
    }
}