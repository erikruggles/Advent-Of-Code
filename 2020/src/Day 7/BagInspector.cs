using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode2020.Day_7
{
    public class BagInspector
    {
        public static List<string> DetermineBagsThatCanContainBagOfColor(string color)
        {
            var bags = Day7Input.CreateBagsFromInput();

            return DetermineBagsThatCanContainBagOfColor(bags, color, new List<string>());
        }

        private static List<string> DetermineBagsThatCanContainBagOfColor(ImmutableList<Bag> bags, string color, List<string> colorsSoFar)
        {
            foreach (var bag in bags)
            {
                if (colorsSoFar.Contains(bag.Color)) continue;

                if (bag.PossibleContents.ContainsKey(color))
                {
                    colorsSoFar.Add(bag.Color);
                    DetermineBagsThatCanContainBagOfColor(bags, bag.Color, colorsSoFar);
                }
            }

            return colorsSoFar;
        }


        public static int DetermineHowManyBagsAreInOneBagOfColor(string color)
        {
            var bags = Day7Input.CreateBagsFromInput();

            return DetermineHowManyBagsAreInOneBagOfColor(bags, color);
        }

        private static int DetermineHowManyBagsAreInOneBagOfColor(ImmutableList<Bag> bags, string color)
        {
            var bag = bags.First(b => b.Color == color);

            var count = 0;

            foreach (var (subBagColor, subBagCount) in bag.PossibleContents)
            {
                count += subBagCount;
                count += subBagCount * DetermineHowManyBagsAreInOneBagOfColor(bags, subBagColor);
            }

            return count;
        }
    }
}
