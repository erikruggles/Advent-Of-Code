using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day_8
{
    public class Computer
    {
        private int _accumulator;
        private int _currentInstructionIndex;

        private readonly ComputerInstruction[] _computerInstructions;

        public Computer(IEnumerable<ComputerInstruction> computerInstructions)
        {
            _computerInstructions = computerInstructions.ToArray();
            _accumulator = 0;
            _currentInstructionIndex = 0;
        }

        public (int nextInstructionIndex, int accumulatorValue) PerformNextInstruction()
        {
            var instruction = _computerInstructions[_currentInstructionIndex];
            switch (instruction.Operation)
            {
                case ComputerOperation.NoOperation:
                    _currentInstructionIndex++;
                    break;
                case ComputerOperation.Jump:
                    _currentInstructionIndex += instruction.OperationValue;
                    break;
                case ComputerOperation.Accumulate:
                    _accumulator += instruction.OperationValue;
                    _currentInstructionIndex++;
                    break;
                default:
                    throw new NotImplementedException();
            }

            return (_currentInstructionIndex, _accumulator);
        }
    }
}
