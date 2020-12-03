using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day_2
{
    public record PasswordAndPolicy
    {
        public int FirstNumber { get; set; }
        public int SecondNumber { get; set; }
        public char RequiredCharacter { get; set; }
        public string Password { get; set; }

        public bool IsValidPerOldJobPolicy()
        {
            var occurences = Regex.Matches(Password, RequiredCharacter.ToString()).Count;
            return occurences >= FirstNumber && occurences <= SecondNumber;
        }

        public bool IsValidPerPolicy()
        {
            return (Password.Length >= FirstNumber && Password[FirstNumber - 1] == RequiredCharacter)
                ^ (Password.Length >= SecondNumber && Password[SecondNumber - 1] == RequiredCharacter);
        }
    }

    public class PasswordAndPolicyFactory
    {
        public static PasswordAndPolicy ParseFromRawPasswordAndPolicyString(string rawPasswordAndPolicy)
        {
            var parts = rawPasswordAndPolicy.Split(" ");
            var minAndMax = parts[0].Split("-");
            var requiredString = parts[1].Trim(':');
            var password = parts[2];

            return new PasswordAndPolicy
            {
                FirstNumber = int.Parse(minAndMax[0]),
                SecondNumber = int.Parse(minAndMax[1]),
                RequiredCharacter = requiredString[0],
                Password = password
            };
        }
    }
}
