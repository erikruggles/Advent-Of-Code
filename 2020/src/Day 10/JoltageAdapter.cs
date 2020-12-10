using System.Collections.Immutable;

namespace AdventOfCode2020.Day_10
{
    public class JoltageAdapter
    {
        public int RatedJoltage { get; }

        public long NumberOfPossiblePathsFromHereToEnd { get; set; }

        public JoltageAdapter(int ratedJoltage)
        {
            RatedJoltage = ratedJoltage;
        }

        public ImmutableList<int> CanBeAdaptedBy()
        {
            return new int[] { RatedJoltage + 1, RatedJoltage + 2, RatedJoltage + 3 }.ToImmutableList();
        }

        public ImmutableList<int> CanBeConnectedTo()
        {
            return new int[] { RatedJoltage - 1, RatedJoltage - 2, RatedJoltage - 3 }.ToImmutableList();
        }
    }
}
