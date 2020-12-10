using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;

namespace AdventOfCode2020.Day_01
{
    public static class Day1
    {
        public static int FindProductOfPairThatAddsTo(ImmutableList<int> input, int additionTarget)
        {
            var (firstNumber, secondNumber, _) = FindPairThatAddsTo(input, additionTarget);

            return firstNumber * secondNumber;
        }

        public static (int firstNumber, int secondNumber, bool foundResult) FindPairThatAddsTo(
            ImmutableList<int> input, int additionTarget)
        {
            var set = FindSetThatAddsTo(input, 2, additionTarget);
            if (set.Count == 2)
            {
                return (set[0], set[1], true);
            }

            return (0, 0, false);
        }

        public static int FindProductOfSetThatAddsTo(
            ImmutableList<int> input, int setSize, int additionTarget)
        {
            var set = FindSetThatAddsTo(input, setSize, additionTarget);

            var product = 1;
            foreach (var item in set)
            {
                product *= item;
            }

            return product;
        }

        public static ImmutableList<int> FindSetThatAddsTo(
            ImmutableList<int> input, int setSize, int additionTarget)
        {
            var sets = FindSetsOfSize(input, setSize);

            foreach (var set in sets)
            {
                if (set.Sum() == additionTarget)
                {
                    return set;
                }
            }

            return new List<int>().ToImmutableList();
        }

        private static ImmutableList<ImmutableList<int>> FindSetsOfSize(
            ImmutableList<int> input, int setSize)
        {
            if (setSize == 0)
            {
                return new List<ImmutableList<int>> { new List<int>().ToImmutableList() }.ToImmutableList();
            }

            if (setSize == 1)
            {
                return input.Select(i => new List<int> { i }.ToImmutableList()).ToImmutableList();
            }

            var smallerSets = FindSetsOfSize(input, setSize - 1);

            var workingList = new List<ImmutableList<int>>();

            for (var i = setSize; i < input.Count; i++)
            {
                workingList.AddRange(smallerSets.Select(s => s.Add(input[i])));
            }

            return workingList.ToImmutableList();
        }
    }
}