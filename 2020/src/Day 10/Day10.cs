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
    }
}
