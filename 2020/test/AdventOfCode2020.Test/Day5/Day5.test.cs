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
        [Theory(DisplayName = "Day 5 - Boarding Pass - Binary Search")]
        public void Day5_BoardingPass_BinarySearch(string input, string lowerHalfIndicator, int arraySize, int expectedValue)
        {
            var boardingPass = new BoardingPass(string.Empty, string.Empty);
            var result = boardingPass.BinarySearch(input, lowerHalfIndicator, Enumerable.Range(0, arraySize-1).ToArray());

            Assert.Equal(expectedValue, result);
        }
    }
}
