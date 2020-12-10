namespace AdventOfCode2020.Day_10
{
    public record JoltageAdapter
    {
        public int RatedJoltage { get; }

        public JoltageAdapter(int ratedJoltage)
        {
            RatedJoltage = ratedJoltage;
        }

        public bool CanBeAdaptedBy(JoltageAdapter joltageAdapter)
        {
            var joltageDifference = joltageAdapter.RatedJoltage - RatedJoltage;
            return joltageDifference >= 0 && joltageDifference <= 3;
        }
    }
}
