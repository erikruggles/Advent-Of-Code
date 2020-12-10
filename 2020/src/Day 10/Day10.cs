using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day_10
{
    public class Day10
    {
        public static Dictionary<int, int> BuildJoltageChain()
        {
            var adapters = Day10Input.ParseInput();
            var adapterOrder = adapters.OrderBy(a => a.RatedJoltage).ToArray();
            var joltageDifferences = new Dictionary<int, int>() { { 1, 0 }, { 2, 0 }, { 3, 1 } };

            joltageDifferences[adapterOrder[0].RatedJoltage] = 1;

            for (var i = 1; i < adapterOrder.Length; i++)
            {
                var difference = adapterOrder[i].RatedJoltage - adapterOrder[i - 1].RatedJoltage;
                joltageDifferences[difference] = joltageDifferences[difference] + 1;
            }
            return joltageDifferences;
        }

        public static long DetermineNumberOfPermutations()
        {
            var adapters = Day10Input.ParseInput();
            var adapterOrder = adapters.OrderByDescending(a => a.RatedJoltage).ToArray();

            for (var i=0; i < adapterOrder.Length; i++)
            {
                var currentItem = adapterOrder[i];
                var possibleAdapters = adapters.Where(a => currentItem.CanBeAdaptedBy().Contains(a.RatedJoltage)).ToList();
                //var possibleConnectedTos = adapters.Where(a => currentItem.CanBeConnectedTo().Contains(a.RatedJoltage)).ToList();

                //This should only be true on the last node.
                if (possibleAdapters.Count == 0)
                {
                    currentItem.NumberOfPossiblePathsFromHereToEnd = 1;
                    continue;
                }

                currentItem.NumberOfPossiblePathsFromHereToEnd = possibleAdapters.Sum(a => a.NumberOfPossiblePathsFromHereToEnd);
            }

            return adapterOrder.Where(a => a.RatedJoltage <= 3).Sum(a => a.NumberOfPossiblePathsFromHereToEnd);
        }
    }
}
