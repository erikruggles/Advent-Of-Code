using AdventOfCode2020.Day_11;
using Xunit;

namespace AdventOfCode2020.Test.Day11
{
    public class SeatingArea_test
    {
        [InlineData(@"LLL
L.L
LLL", 1, 1, SeatingOptions.Floor)]
        [InlineData(@"...
...
...", 1, 1, SeatingOptions.Floor)]
        [InlineData(@"###
#.#
###", 1, 1, SeatingOptions.Floor)]
        [InlineData(@"LLL
.LL
LLL", 0, 1, SeatingOptions.Floor)]
        [InlineData(@"...
...
...", 0, 1, SeatingOptions.Floor)]
        [InlineData(@"###
.##
###", 0, 1, SeatingOptions.Floor)]
        [InlineData(@"L.L
LLL
LLL", 1, 0, SeatingOptions.Floor)]
        [InlineData(@"...
...
...", 1, 0, SeatingOptions.Floor)]
        [InlineData(@"#.#
###
###", 1, 0, SeatingOptions.Floor)]
        [InlineData(@".LL
LLL
LLL", 0, 0, SeatingOptions.Floor)]
        [InlineData(@"...
...
...", 0, 0, SeatingOptions.Floor)]
        [InlineData(@".##
###
###", 0, 0, SeatingOptions.Floor)]
        [Theory(DisplayName = "Day 11 - Seating Area - Floor Should Remain Floor")]
        public void Day11_SeatingArea_DetermineSeatsNewState_Floor(string input, int x, int y, int expectedSeatingOption)
        {
            var seatingArea = SeatingAreaFactory.CreateSeatingAreaFromString(input);

            Assert.Equal(expectedSeatingOption, seatingArea.DetermineNewSeatStateUsingAdjacentRules(y, x));
        }
        
        [InlineData(@"LLL
LLL
LLL", 1, 1, SeatingOptions.OccupiedSeat)]
        [InlineData(@"LLL
LLL
LLL", 0, 0, SeatingOptions.OccupiedSeat)]
        [InlineData(@"LLL
LLL
LLL", 2, 2, SeatingOptions.OccupiedSeat)]
        [InlineData(@"...
.L.
...", 1, 1, SeatingOptions.OccupiedSeat)]
        
        [Theory(DisplayName = "Day 11 - Seating Area - Empty Seat With No Occupied Seats Nearby Should Become Occupied")]
        public void Day11_SeatingArea_DetermineSeatsNewState_EmptyToOccupied(string input, int x, int y, int expectedSeatingOption)
        {
                var seatingArea = SeatingAreaFactory.CreateSeatingAreaFromString(input);

                Assert.Equal(expectedSeatingOption, seatingArea.DetermineNewSeatStateUsingAdjacentRules(y, x));
        }
        
        [InlineData(@"###
###
###", 0, 0, SeatingOptions.OccupiedSeat)]
        [InlineData(@".#.
.##
.#.", 1, 1, SeatingOptions.OccupiedSeat)]
        [InlineData(@"...
.#.
...", 1, 1, SeatingOptions.OccupiedSeat)]
        [InlineData(@"LLL
L#L
LLL", 1, 1, SeatingOptions.OccupiedSeat)]
        
        [Theory(DisplayName = "Day 11 - Seating Area - Occupied Seat With Less Than Four Occupied Seats Nearby Should Remain Occupied")]
        public void Day11_SeatingArea_DetermineSeatsNewState_OccupiedToOccupied(string input, int x, int y, int expectedSeatingOption)
        {
                var seatingArea = SeatingAreaFactory.CreateSeatingAreaFromString(input);

                Assert.Equal(expectedSeatingOption, seatingArea.DetermineNewSeatStateUsingAdjacentRules(y, x));
        }
        
        [InlineData(@"###
###
###", 1, 1, SeatingOptions.EmptySeat)]
        [InlineData(@".#.
.##
##.", 1, 1, SeatingOptions.EmptySeat)]
        [InlineData(@"#L#
L#L
#L#", 1, 1, SeatingOptions.EmptySeat)]
        
        [Theory(DisplayName = "Day 11 - Seating Area - Occupied Seat With Four Or More Occupied Seats Nearby Should Become Unoccupied")]
        public void Day11_SeatingArea_DetermineSeatsNewState_OccupiedToUnoccupied(string input, int x, int y, int expectedSeatingOption)
        {
                var seatingArea = SeatingAreaFactory.CreateSeatingAreaFromString(input);

                Assert.Equal(expectedSeatingOption, seatingArea.DetermineNewSeatStateUsingAdjacentRules(y, x));
        }
        
        [InlineData(@".......#.
...#.....
.#.......
.........
..#L....#
....#....
.........
#........
...#.....", 3, 4, SeatingOptions.EmptySeat)]
        [InlineData(@".............
.L.L.#.#.#.#.
.............", 1, 1, SeatingOptions.OccupiedSeat)]
        [InlineData(@".##.##.
#.#.#.#
##...##
...L...
##...##
#.#.#.#
.##.##.", 3, 3, SeatingOptions.OccupiedSeat)]
        
        [Theory(DisplayName = "Day 11 - Seating Area - Determine New Seat State Using Line Of Sight Rules")]
        public void Day11_SeatingArea_DetermineNewSeatStateUsingLineOfSightRules(string input, int x, int y, int expectedSeatingOption)
        {
                var seatingArea = SeatingAreaFactory.CreateSeatingAreaFromString(input);

                Assert.Equal(expectedSeatingOption, seatingArea.DetermineNewSeatStateUsingLineOfSightRules(y, x));
        }
    }
}