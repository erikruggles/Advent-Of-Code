using System.Linq;

namespace AdventOfCode2020.Day_08
{
    public class ComputerInstructionFactory
    {
        public static ComputerInstruction CreateComputerInstructionFromString(string input)
        {
            var parts = input.Split(" ").ToList();
            return new ComputerInstruction(
                parts[0] switch
                {
                    "nop" => ComputerOperation.NoOperation,
                    "jmp" => ComputerOperation.Jump,
                    "acc" => ComputerOperation.Accumulate,
                    _ => throw new System.NotImplementedException()
                },
                int.Parse(parts[1]));
        }
    }
}
