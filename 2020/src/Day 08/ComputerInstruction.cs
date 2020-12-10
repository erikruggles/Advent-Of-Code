namespace AdventOfCode2020.Day_08
{
    public record ComputerInstruction
    {
        public int Operation { get; set; }
        public int OperationValue { get; set; }

        public ComputerInstruction(int operation, int operationValue)
        {
            Operation = operation;
            OperationValue = operationValue;
        }
    }

    public class ComputerOperation
    {
        public const int NoOperation = 0;
        public const int Jump = 1;
        public const int Accumulate = 2;
    }
}
