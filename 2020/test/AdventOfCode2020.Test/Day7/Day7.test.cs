using AdventOfCode2020.Day_7;
using Xunit;

namespace AdventOfCode2020.Test.Day7
{
    public class Day7
    {
        [InlineData(@"shiny purple bags contain 2 pale blue bags, 1 wavy fuchsia bag, 5 pale salmon bags.", "shiny purple", "pale blue", 2)]
        [InlineData(@"shiny purple bags contain 2 pale blue bags, 1 wavy fuchsia bag, 5 pale salmon bags.", "shiny purple", "wavy fuchsia", 1)]
        [InlineData(@"shiny purple bags contain 2 pale blue bags, 1 wavy fuchsia bag, 5 pale salmon bags.", "shiny purple", "pale salmon", 5)]
        [InlineData(@"dull orange bags contain 4 dull gray bags.", "dull orange", "dull gray", 4)]
        [Theory(DisplayName = "Day 7 - Bag Factory - Create Bag From String with Child Bags")]
        public void Day7_BagFactory_CreateBagFromString(string input, string expectedColor, string expectedChildColor, int expectedChildAmount)
        {
            var bag = BagFactory.CreateBagFromString(input);

            Assert.Equal(expectedColor, bag.Color);
            Assert.True(bag.PossibleContents.ContainsKey(expectedChildColor));
            Assert.Equal(expectedChildAmount, bag.PossibleContents[expectedChildColor]);
        }

        [Fact(DisplayName = "Day 7 - Bag Factory - Create Bag From String with No Child Bags")]
        public void Day7_BagFactory_CreateBagFromString_NoChildBags()
        {
            var bag = BagFactory.CreateBagFromString(@"dark silver bags contain no other bags.");

            Assert.Equal("dark silver", bag.Color);
            Assert.Empty(bag.PossibleContents);
        }
    }
}
