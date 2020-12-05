using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Day_1;
using AdventOfCode2020.Day_2;
using AdventOfCode2020.Day_3;
using AdventOfCode2020.Day_4;
using AdventOfCode2020.Day_5;

namespace AdventOfCode2020
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Day 1");
            Console.WriteLine($"Part 1: {Day1.FindProductOfPairThatAddsTo(Day1InputFactory.GetInput(), 2020)}");
            Console.WriteLine($"Part 2: {Day1.FindProductOfSetThatAddsTo(Day1InputFactory.GetInput(), 3, 2020)}");

            Console.WriteLine();

            Console.WriteLine("Day 2");
            Console.WriteLine($"Part 1: {Day2.FindNumberOfValidPasswordsPerOldJobPolicy()}");
            Console.WriteLine($"Part 2: {Day2.FindNumberOfValidPasswords()}");

            Console.WriteLine();

            Console.WriteLine("Day 3");
            Console.WriteLine($"Part 1: {Day3.FindPath(Day3Input.ParseInput(), 1, 3).Count(x => x.IsTree)}");
            var movements = new List<(int, int)> { (1, 1), (1, 3), (1, 5), (1, 7), (2, 1) };
            Console.WriteLine($"Part 2: {Day3.FindProductOfNumberOfTreesPaths(Day3Input.ParseInput(), movements)}");

            Console.WriteLine();

            Console.WriteLine("Day 4");
            var passports = Day4Input.ParseAllPassports();
            Console.WriteLine($"Part 1: {passports.Count(x => x.NaiveIsValid())}");
            Console.WriteLine($"Part 2: {passports.Count(x => x.StrictIsValid())}");

            Console.WriteLine();

            Console.WriteLine("Day 5");
            Console.WriteLine($"Part 1: {Day5Input.ParseBoardingPasses().Select(x => x.DetermineSeatId()).Max()}");
            Console.WriteLine($"Part 2: {Day5.FindMySeatId()}");

            Console.ReadKey();
        }
    }
}