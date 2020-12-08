using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day_8
{
    public class Day8
    {
        public static (bool terminatedNormally, int accumulator) RunUntilEndOrLoop(Computer computer)
        {
            var visitedIndexes = new List<int>();
            var (currentIndex, accumulator) = computer.PerformNextInstruction();

            while (true)
            {
                if (visitedIndexes.Contains(currentIndex))
                {
                    return (false, accumulator);
                }

                if (currentIndex == -1)
                {
                    return (true, accumulator);
                }

                visitedIndexes.Add(currentIndex);
                (currentIndex, accumulator) = computer.PerformNextInstruction();
            }
        }
        public static int FindCorruptedInstruction()
        {
            var instructions = Day8Input.ParseInstructionsFromInput().ToArray();

            for (var i = 0; i < instructions.Length; i++)
            {
                var instruction = instructions[i];

                if (instruction.Operation == ComputerOperation.Accumulate)
                {
                    continue;
                }

                var newInstruction = new ComputerInstruction(
                    instruction.Operation == ComputerOperation.NoOperation
                        ? ComputerOperation.Jump
                        : ComputerOperation.NoOperation, instruction.OperationValue);

                instructions[i] = newInstruction;
                var (terminatedNormally, accumulator) = RunUntilEndOrLoop(new Computer(instructions));
                if (terminatedNormally)
                {
                    return accumulator;
                }

                instructions[i] = instruction;
            }

            return -1;
        }
    }
}