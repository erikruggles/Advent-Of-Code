using System.Linq;

namespace AdventOfCode2020.Day_2
{
    public static class Day2
    {
        public static int FindNumberOfValidPasswordsPerOldJobPolicy()
        {
            var passwords = Day2Input.GetPasswordAndPolicies();

            return passwords.Where(p => p.IsValidPerOldJobPolicy()).Count();
        }

        public static int FindNumberOfValidPasswords()
        {
            var passwords = Day2Input.GetPasswordAndPolicies();

            return passwords.Where(p => p.IsValidPerPolicy()).Count();
        }
    }
}
