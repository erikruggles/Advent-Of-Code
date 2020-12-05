using System.Collections.Generic;
using AdventOfCode2020.Day_5;
using System.Linq;
using Xunit;

namespace AdventOfCode2020.Test.Day5
{
    public class Day5
    {
        [InlineData(@"BBBFFFBLLR", "BBBFFFB", "LLR")]
        [InlineData(@"BFFFFFFRRL", "BFFFFFF", "RRL")]
        [Theory(DisplayName = "Day 5 - Boarding Pass Factory - Create Boarding Pass From String")]
        public void Day5_BoardingPassFactory_CreateBoardingPassFromString(string input, string expectedRowIndicator, string expectedSeatIndicator)
        {
            var result = BoardingPassFactory.CreateBoardingPassFromString(input);

            Assert.Equal(expectedRowIndicator, result.RowIndicator);
            Assert.Equal(expectedSeatIndicator, result.SeatIndicator);
        }

        [InlineData(@"FBFBBFF", "f", 128, 44)]
        [InlineData(@"RLR", "l", 8, 5)]
        [InlineData(@"FFFFBBF", "f", 128, 6)]
        [InlineData(@"RRR", "l", 8, 7)]
        [InlineData(@"RRL", "l", 8, 6)]
        [Theory(DisplayName = "Day 5 - Boarding Pass - Binary Search")]
        public void Day5_BoardingPass_BinarySearch(string input, string lowerHalfIndicator, int arraySize, int expectedValue)
        {
            var boardingPass = new BoardingPass(string.Empty, string.Empty);
            var result = boardingPass.BinarySearch(input, lowerHalfIndicator, Enumerable.Range(0, arraySize).ToArray());

            Assert.Equal(expectedValue, result);
        }
        
        [Fact(DisplayName = "Day 5 - Day 5 - Determine Minimum Row From List Of Seat Ids")]
        public void Day5_BoardingPass_DetermineMinimumRowFromListOfSeatIds()
        {
            var (minRow, minSeatId) = Day_5.Day5.DetermineMinimumRowFromListOfSeatIds(new List<int> { 17, 10, 123, 29, 615});

            Assert.Equal(1, minRow);
            Assert.Equal(10, minSeatId);
        }
        
        [Fact(DisplayName = "Day 5 - Day 5 - Determine Maximum Row From List Of Seat Ids")]
        public void Day5_BoardingPass_DetermineMaximumRowFromListOfSeatIds()
        {
            var (maxRow, maxSeatId) = Day_5.Day5.DetermineMaximumRowFromListOfSeatIds(new List<int> { 17, 10, 123, 29, 615});

            Assert.Equal(76, maxRow);
            Assert.Equal(615, maxSeatId);
        }
    }
}
