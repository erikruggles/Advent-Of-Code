using System.Collections.Generic;
using System.Collections.Immutable;

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
    }
}
