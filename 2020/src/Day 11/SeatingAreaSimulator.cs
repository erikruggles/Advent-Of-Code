namespace AdventOfCode2020.Day_11
{
    public class SeatingAreaSimulator
    {
        public static SeatingArea FindStableSeatingArea()
        {
            var currentSeatingArea = Day11Input.GenerateSeatingAreaFromInput();
            var nextSeatingArea = FindNextSeatingArea(currentSeatingArea);
            
            while (currentSeatingArea != nextSeatingArea)
            {
                currentSeatingArea = nextSeatingArea;
                nextSeatingArea = FindNextSeatingArea(currentSeatingArea);
            }

            return currentSeatingArea;
        }
        
        private static SeatingArea FindNextSeatingArea(SeatingArea currentSeatingArea)
        {
            var newArea = new int[currentSeatingArea.Floor.GetLength(0), currentSeatingArea.Floor.GetLength(1)];

            for (var y = 0; y < newArea.GetLength(0); y++)
            {
                for (var x = 0; x < newArea.GetLength(1); x++)
                {
                    newArea[y, x] = currentSeatingArea.DetermineSeatsNewState(x, y);
                }
            }

            return new SeatingArea(newArea);
        }
    }
}