namespace AdventOfCode2020.Day_10
{
    public class JoltageAdapterFactory
    {
        public static JoltageAdapter CreateJoltageAdapterFromString(string input)
        {
            return new JoltageAdapter(int.Parse(input));
        }
    }
}
