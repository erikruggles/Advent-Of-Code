using System.Collections.Generic;
using AdventOfCode2020.Day_08;
using Xunit;

namespace AdventOfCode2020.Test.Day08
{
    public class Day8
    {
        [InlineData(@"acc +18", 2, 18)]
        [InlineData(@"jmp -393", 1, -393)]
        [InlineData(@"nop -348", 0, -348)]
        [Theory(DisplayName = "Day 8 - Computer Instruction Factory - Create Computer Instruction From String")]
        public void Day8_ComputerInstructionFactory_CreateBagFromString(string input, int expectedOperation, int expectedOperationValue)
        {
            var computerInstruction = ComputerInstructionFactory.CreateComputerInstructionFromString(input);

            Assert.Equal(expectedOperation, computerInstruction.Operation);
            Assert.Equal(expectedOperationValue, computerInstruction.OperationValue);
        }

        [Fact(DisplayName = "Day 8 - Computer - Perform Next Instruction")]
        public void Day8_Computer_PerformNextInstruction()
        {
            var computer = new Computer(new List<ComputerInstruction>
            {
                new ComputerInstruction(ComputerOperation.NoOperation, -23),
                new ComputerInstruction(ComputerOperation.Accumulate, 3),
                new ComputerInstruction(ComputerOperation.Jump, -2),
                new ComputerInstruction(ComputerOperation.Accumulate, -20),
            });

            int nextInstructionIndex;
            int accumulator;

            (nextInstructionIndex, accumulator) = computer.PerformNextInstruction();
            Assert.Equal(1, nextInstructionIndex);
            Assert.Equal(0, accumulator);

            (nextInstructionIndex, accumulator) = computer.PerformNextInstruction();
            Assert.Equal(2, nextInstructionIndex);
            Assert.Equal(3, accumulator);

            (nextInstructionIndex, accumulator) = computer.PerformNextInstruction();
            Assert.Equal(0, nextInstructionIndex);
            Assert.Equal(3, accumulator);

            (nextInstructionIndex, accumulator) = computer.PerformNextInstruction();
            Assert.Equal(1, nextInstructionIndex);
            Assert.Equal(3, accumulator);
        }
    }
}
