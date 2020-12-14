namespace AdventOfCode2020.Day_11
{
    public class SeatingAreaFactory
    {
        public static SeatingArea CreateSeatingAreaFromString(string input)
        {
            var lines = input.Split("\r\n");
            var area = new int[lines.Length, lines[0].Length];
            for (var i = 0; i < lines.Length; i++)
            {
                var line = lines[i];
                for (var j = 0; j < line.Length; j++)
                {
                    area[i, j] = line[j] switch
                    {
                        '.' => SeatingOptions.Floor,
                        'L' => SeatingOptions.EmptySeat,
                        '#' => SeatingOptions.OccupiedSeat,
                        _ => SeatingOptions.Floor
                    };
                }
            }

            return new SeatingArea(area);
        }
    }
}