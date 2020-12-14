using System;
using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020.Day_01;
using AdventOfCode2020.Day_02;
using AdventOfCode2020.Day_03;
using AdventOfCode2020.Day_04;
using AdventOfCode2020.Day_05;
using AdventOfCode2020.Day_06;
using AdventOfCode2020.Day_07;
using AdventOfCode2020.Day_08;
using AdventOfCode2020.Day_09;
using AdventOfCode2020.Day_10;
using AdventOfCode2020.Day_11;

namespace AdventOfCode2020
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Day 1");
            Console.WriteLine($"Part 1: {Day1.FindProductOfPairThatAddsTo(Day1InputFactory.GetInput(), 2020)}");
            //Leaving this comment out as I solved this for a general solution which is very slow and memory intensive.
            //Console.WriteLine($"Part 2: {Day1.FindProductOfSetThatAddsTo(Day1InputFactory.GetInput(), 3, 2020)}");

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
            
            Console.WriteLine();

            Console.WriteLine("Day 6");
            Console.WriteLine($"Part 1: {Day6Input.ParsePassengerGroups().Sum(x => x.DetermineAffirmativeQuestionsThatAnyoneAnswered().Count)}");
            Console.WriteLine($"Part 2: {Day6Input.ParsePassengerGroups().Sum(x => x.DetermineAffirmativeQuestionsThatEveryoneAnswered().Count)}");

            Console.WriteLine();

            Console.WriteLine("Day 7");
            Console.WriteLine($"Part 1: {BagInspector.DetermineBagsThatCanContainBagOfColor("shiny gold").Count}");
            Console.WriteLine($"Part 2: {BagInspector.DetermineHowManyBagsAreInOneBagOfColor("shiny gold")}");

            Console.WriteLine();

            Console.WriteLine("Day 8");
            var (_, accumulator) = Day8.RunUntilEndOrLoop(Day8Input.CreateComputerFromInput());
            Console.WriteLine($"Part 1: {accumulator}");
            Console.WriteLine($"Part 2: {Day8.FindCorruptedInstruction()}");

            Console.WriteLine();

            Console.WriteLine("Day 9");
            var day9Input = Day9Input.ParseCodeFromInput();
            var weakness = CodeBreaker.FindCodeWeakness(day9Input);
            Console.WriteLine($"Part 1: {weakness}");
            Console.WriteLine($"Part 2: {CodeBreaker.FindEncryptionWeakness(day9Input, weakness)}");

            Console.WriteLine();

            Console.WriteLine("Day 10");
            var differences = Day10.BuildJoltageChain();
            Console.WriteLine($"Part 1: {differences[1] * differences[3]}");
            Console.WriteLine($"Part 2: {Day10.DetermineNumberOfPermutations()}");

            Console.WriteLine();

            Console.WriteLine("Day 11");
            var stableSeatingArea = SeatingAreaSimulator.FindStableSeatingArea();
            var (_, _, occupied) = stableSeatingArea.DetermineFloorStatus();
            Console.WriteLine($"Part 1: {occupied}");
            stableSeatingArea = SeatingAreaSimulator.FindStableSeatingAreaUsingNewMethod();
            (_, _, occupied) = stableSeatingArea.DetermineFloorStatus();
            Console.WriteLine($"Part 2: {occupied}");

            Console.ReadKey();
        }
    }
}