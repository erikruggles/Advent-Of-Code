using AdventOfCode2020.Day_2;
using AdventOfCode2020.Day_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace AdventOfCode2020.Test.Day3
{
    public class Day3_test
    {
        [Fact(DisplayName = "Day 3 - Day 3 Input - Parse Input")]
        public void Day3_Day3Input_ParseInput()
        {
            var biome = Day3Input.ParseInput();

            Assert.Equal(323, biome.GetLength(0));
            Assert.Equal(31, biome.GetLength(1));

            Assert.False(biome[0, 0].IsTree);
            Assert.True(biome[0, 2].IsTree);
        }

        [InlineData(0, 0, 0, 0, 0, 0, false)]
        [InlineData(1, 3, 0, 0, 1, 3, true)]
        [InlineData(0, 33, 0, 0, 0, 2, true)]
        [InlineData(0, 31, 0, 0, 0, 0, false)]
        [InlineData(1, 3, 323, 0, -1, -1, null)]
        [Theory(DisplayName = "Day 3 - Day 3 - Make Move")]
        public void Day3_Day3_MakeMove(int moveY, int moveX, int currentY, int currentX, int expectedNewY,
            int expectedNewX, bool? expectedIsTree)
        {
            var biome = Day3Input.ParseInput();
            var (newY, newX, newLocation) = Day_3.Day3.MakeMove(biome, currentY, currentX, moveY, moveX);


            Assert.Equal(expectedNewY, newY);
            Assert.Equal(expectedNewX, newX);
            Assert.Equal(expectedIsTree, newLocation?.IsTree);
        }
    }
}
