using AdventOfCode2020.Day_02;
using Xunit;

namespace AdventOfCode2020.Test.Day02
{
    public class Day2_test
    {
        [InlineData("15-16 m: mhmjmzrmmlmmmmmm", 15, 16, 'm', "mhmjmzrmmlmmmmmm")]
        [InlineData("5-6 d: dcdddhzld", 5, 6, 'd', "dcdddhzld")]
        [InlineData("3-4 s: vqssdcbl", 3, 4, 's', "vqssdcbl")]
        [Theory(DisplayName = "Day 2 - Password And Policy Factory - Parse From String")]
        public void Day2_PasswordAndPolicyFactory_ParseFromRawPasswordAndPolicyString(string inputString,
            int expectedFirstNumber, int expectedSecondNumber, char expectedRequiredCharacter,
            string expectedPassword)
        {
            var parsedPasswordAndPolicy = PasswordAndPolicyFactory.ParseFromRawPasswordAndPolicyString(inputString);

            Assert.Equal(expectedFirstNumber, parsedPasswordAndPolicy.FirstNumber);
            Assert.Equal(expectedSecondNumber, parsedPasswordAndPolicy.SecondNumber);
            Assert.Equal(expectedRequiredCharacter, parsedPasswordAndPolicy.RequiredCharacter);
            Assert.Equal(expectedPassword, parsedPasswordAndPolicy.Password);
        }

        [InlineData("15-16 m: mhmjmzrmmlmmmmmm", false)]
        [InlineData("5-6 d: dcdddhzld", true)]
        [InlineData("3-4 s: vqssdcbl", false)]
        [InlineData("4-5 j: jjhnn", false)]
        [Theory(DisplayName = "Day 2 - Password And Policy - Is Valid Per Old Job Policy")]
        public void Day2_PasswordAndPolicy_IsValidPerOldJobPolicy(string inputString, bool expectedIsValidPassword)
        {
            var parsedPasswordAndPolicy = PasswordAndPolicyFactory.ParseFromRawPasswordAndPolicyString(inputString);

            Assert.Equal(expectedIsValidPassword, parsedPasswordAndPolicy.IsValidPerOldJobPolicy());
        }

        [InlineData("15-16 m: mhmjmzrmmlmmmmmm", false)]
        [InlineData("5-6 d: dcdddhzld", true)]
        [InlineData("3-4 s: vqssdcbl", false)]
        [InlineData("4-5 j: jjhnn", false)]
        [Theory(DisplayName = "Day 2 - Password And Policy - Is Valid Per Job Policy")]
        public void Day2_PasswordAndPolicy_IsValidPerPolicy(string inputString, bool expectedIsValidPassword)
        {
            var parsedPasswordAndPolicy = PasswordAndPolicyFactory.ParseFromRawPasswordAndPolicyString(inputString);

            Assert.Equal(expectedIsValidPassword, parsedPasswordAndPolicy.IsValidPerPolicy());
        }
    }
}
