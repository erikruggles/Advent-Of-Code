using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode2020.Day_9
{
    public class CodeBreaker
    {
        public static long FindCodeWeakness(ImmutableList<long> code)
        {
            for (int i = 25; i < code.Count; i++)
            {
                if (!ExistsPairThatAddsTo(code.Skip(i-25).Take(25).ToArray(), code[i]))
                {
                    return code[i];
                }
            }

            return -1;
        }

        public static bool ExistsPairThatAddsTo(long[] numbersThatCanBeAdded, long targetNumber)
        {
            for (int i = 0; i < numbersThatCanBeAdded.Length; i++)
            {
                for (int j = i; j < numbersThatCanBeAdded.Length; j++)
                {
                    if (numbersThatCanBeAdded[i] + numbersThatCanBeAdded[j] == targetNumber)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        public static long FindEncryptionWeakness(ImmutableList<long> code, long targetNumber)
        {
            for (int i = 0; i < code.Count; i++)
            {
                var (segmentExists, segment) = FindSegmentThatAddsTo(code.Skip(i).ToArray(), targetNumber);
                if (segmentExists)
                {
                    return segment.Min() + segment.Max();
                }
            }

            return -1;
        }

        public static (bool segmentExists, long[] segment) FindSegmentThatAddsTo(long[] numbersThatCanBeAdded, long targetNumber)
        {
            var workingSum = numbersThatCanBeAdded[0];
            var currentIndex = 1;
            do
            {
                workingSum += numbersThatCanBeAdded[currentIndex];
                if (workingSum == targetNumber)
                {
                    return (true, numbersThatCanBeAdded[..currentIndex]);
                }

                currentIndex++;
            } while (workingSum < targetNumber);

            return (false, System.Array.Empty<long>());
        }
    }
}
