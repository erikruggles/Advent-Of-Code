using System.Collections.Generic;
using System.Collections.Immutable;
using Xunit;

namespace AdventOfCode2020.Test.Day1
{
    public class Day1_test
    {
        [Fact(DisplayName = "Day 1 - FindPairThatAddsTo2020 - Success")]
        public void Day1_FindPairThatAddsTo2020_Success()
        {
            var input = new List<int> {1011, 1010, 1009, 1008, 1007}.ToImmutableList();
            var (firstNumber, secondNumber, success) = Day_1.Day1.FindPairThatAddsTo(input, 2020);
            
            Assert.Equal(1011, firstNumber);
            Assert.Equal(1009, secondNumber);
            Assert.True(success);
        }
        
        [Fact(DisplayName = "Day 1 - FindPairThatAddsTo2020 - Failure")]
        public void Day1_FindPairThatAddsTo2020_Failure()
        {
            var input = new List<int> {1010, 1009, 1008, 1007}.ToImmutableList();
            var (firstNumber, secondNumber, success) = Day_1.Day1.FindPairThatAddsTo(input, 2020);
            
            Assert.Equal(0, firstNumber);
            Assert.Equal(0, secondNumber);
            Assert.False(success);
        }
    }
}