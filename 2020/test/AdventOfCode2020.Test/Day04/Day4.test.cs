#nullable enable
using AdventOfCode2020.Day_04;
using Xunit;

namespace AdventOfCode2020.Test.Day04
{
    public class Day4_test
    {
        [InlineData(@"eyr:2028 iyr:2016 byr:1995 ecl:oth
pid:543685203 hcl:#c0946f
hgt:152cm
cid:252", "eyr", "2028")]
        [InlineData(@"eyr:2028 iyr:2016 byr:1995 ecl:oth
pid:543685203 hcl:#c0946f
hgt:152cm
cid:252", "hgt", "152cm")]
        [InlineData(@"eyr:2028 iyr:2016 byr:1995 ecl:oth
pid:543685203 hcl:#c0946f
hgt:152cm
cid:252", "cid", "252")]
        [InlineData(@"byr:1957 hcl:#c0946f hgt:152cm ecl:blu eyr:2027 pid:325917033
iyr:2010", "cid", null)]
        [Theory(DisplayName = "Day 4 - Passport Factory - Parse Passport Field")]
        public void Day4_PassportFactory_ParsePassportField(string input, string passportField, string? expectedOutput)
        {
            var result = PassportFactory.ParsePassportField(input, passportField);

            Assert.Equal(expectedOutput, result);
        }
        
        
        [Fact(DisplayName = "Day 4 - Passport Factory - Parse Passport From String")]
        public void Day4_PassportFactory_ParsePassportFromString()
        {
            var passport = PassportFactory.ParsePassportFromString(@"eyr:2028 iyr:2016 byr:1995 ecl:oth
pid:543685203 hcl:#c0946f
hgt:152cm
cid:252");
            Assert.Equal(2028, passport.ExpirationYear);
            Assert.Equal(2016, passport.IssueYear);
            Assert.Equal(1995, passport.BirthYear);
            Assert.Equal(252, passport.CountryId);
            Assert.Equal("543685203", passport.PassportId);
            Assert.Equal("#c0946f", passport.HairColor);
            Assert.Equal("oth", passport.EyeColor);
            Assert.Equal("152cm", passport.Height);
        }
        
        [InlineData(@"ecl:gry pid:860033327 eyr:2020 hcl:#fffffd
byr:1937 iyr:2017 cid:147 hgt:183cm", true)]
        [InlineData(@"iyr:2013 ecl:amb cid:350 eyr:2023 pid:028048884
hcl:#cfa07d byr:1929", false)]
        [InlineData(@"hcl:#ae17e1 iyr:2013
eyr:2024
ecl:brn pid:760753108 byr:1931
hgt:179cm", true)]
        [InlineData(@"hcl:#cfa07d eyr:2025 pid:166559648
iyr:2011 ecl:brn hgt:59in", false)]
        [Theory(DisplayName = "Day 4 - Passport - Naive Is Valid")]
        public void Day4_Passport_NaiveIsValid(string input, bool expectedIsValid)
        {
            var passport = PassportFactory.ParsePassportFromString(input);
            Assert.Equal(expectedIsValid, passport.NaiveIsValid());
        }
        
        [InlineData(@"byr:1919", false)]
        [InlineData(@"byr:1920", true)]
        [InlineData(@"byr:2000", true)]
        [InlineData(@"byr:2002", true)]
        [InlineData(@"byr:2003", false)]
        [InlineData(@"byr:kitten", false)]
        [InlineData(@"", false)]
        [InlineData(@"byr:", false)]
        [InlineData(@"byr:amber", false)]
        [InlineData(@"byr:am", false)]
        [Theory(DisplayName = "Day 4 - Passport - Birth Year Is Valid")]
        public void Day4_Passport_BirthYearIsValid(string input, bool expectedIsValid)
        {
                var passport = PassportFactory.ParsePassportFromString(input);
                Assert.Equal(expectedIsValid, passport.BirthYearIsValid());
        }
        
        [InlineData(@"iyr:1910", false)]
        [InlineData(@"iyr:1920", false)]
        [InlineData(@"iyr:2010", true)]
        [InlineData(@"iyr:2015", true)]
        [InlineData(@"iyr:2020", true)]
        [InlineData(@"iyr:2021", false)]
        [InlineData(@"iyr:20151", false)]
        [InlineData(@"iyr:kitten", false)]
        [InlineData(@"", false)]
        [InlineData(@"iyr:", false)]
        [InlineData(@"iyr:amber", false)]
        [InlineData(@"iyr:am", false)]
        [Theory(DisplayName = "Day 4 - Passport - Issue Year Is Valid")]
        public void Day4_Passport_IssueYearIsValid(string input, bool expectedIsValid)
        {
                var passport = PassportFactory.ParsePassportFromString(input);
                Assert.Equal(expectedIsValid, passport.IssueYearIsValid());
        }
        
        [InlineData(@"eyr:1910", false)]
        [InlineData(@"eyr:1920", false)]
        [InlineData(@"eyr:2020", true)]
        [InlineData(@"eyr:2025", true)]
        [InlineData(@"eyr:2030", true)]
        [InlineData(@"eyr:2031", false)]
        [InlineData(@"eyr:20201", false)]
        [InlineData(@"eyr:kitten", false)]
        [InlineData(@"", false)]
        [InlineData(@"eyr:", false)]
        [InlineData(@"eyr:amber", false)]
        [InlineData(@"eyr:am", false)]
        [Theory(DisplayName = "Day 4 - Passport - Expiration Year Is Valid")]
        public void Day4_Passport_ExpirationYearIsValid(string input, bool expectedIsValid)
        {
                var passport = PassportFactory.ParsePassportFromString(input);
                Assert.Equal(expectedIsValid, passport.ExpirationYearIsValid());
        }
        
        [InlineData(@"hgt:58in", false)]
        [InlineData(@"hgt:59in", true)]
        [InlineData(@"hgt:60in", true)]
        [InlineData(@"hgt:76in", true)]
        [InlineData(@"hgt:77in", false)]
        [InlineData(@"hgt:in", false)]
        [InlineData(@"hgt:0cm", false)]
        [InlineData(@"hgt:149cm", false)]
        [InlineData(@"hgt:150cm", true)]
        [InlineData(@"hgt:175cm", true)]
        [InlineData(@"hgt:193cm", true)]
        [InlineData(@"hgt:194cm", false)]
        [InlineData(@"hgt:cm", false)]
        [InlineData(@"hgt:190", false)]
        [InlineData(@"hgt:190am", false)]
        [InlineData(@"hgt:2031", false)]
        [InlineData(@"hgt:kitten", false)]
        [InlineData(@"", false)]
        [InlineData(@"hgt:", false)]
        [InlineData(@"hgt:amber", false)]
        [Theory(DisplayName = "Day 4 - Passport - Height Is Valid")]
        public void Day4_Passport_HeightIsValid(string input, bool expectedIsValid)
        {
                var passport = PassportFactory.ParsePassportFromString(input);
                Assert.Equal(expectedIsValid, passport.HeightIsValid());
        }
        
        [InlineData(@"hcl:#00000", false)]
        [InlineData(@"hcl:#000000", true)]
        [InlineData(@"hcl:#ffffff", true)]
        [InlineData(@"hcl:#012abc", true)]
        [InlineData(@"hcl:012abc", false)]
        [InlineData(@"hcl:#012abcd", false)]
        [InlineData(@"hcl:#012abz", false)]
        [InlineData(@"hgt:amber", false)]
        [Theory(DisplayName = "Day 4 - Passport - Hair Color Is Valid")]
        public void Day4_Passport_HairColorIsValid(string input, bool expectedIsValid)
        {
                var passport = PassportFactory.ParsePassportFromString(input);
                Assert.Equal(expectedIsValid, passport.HairColorIsValid());
        }
        
        [InlineData(@"ecl:amb", true)]
        [InlineData(@"ecl:blu", true)]
        [InlineData(@"ecl:brn", true)]
        [InlineData(@"ecl:gry", true)]
        [InlineData(@"ecl:grn", true)]
        [InlineData(@"ecl:hzl", true)]
        [InlineData(@"ecl:oth", true)]
        [InlineData(@"ecl:asd", false)]
        [InlineData(@"ecl:kitten", false)]
        [InlineData(@"", false)]
        [InlineData(@"ecl:amber", false)]
        [InlineData(@"ecl:am", false)]
        [Theory(DisplayName = "Day 4 - Passport - Eye Color Is Valid")]
        public void Day4_Passport_EyeColorIsValid(string input, bool expectedIsValid)
        {
                var passport = PassportFactory.ParsePassportFromString(input);
                Assert.Equal(expectedIsValid, passport.EyeColorIsValid());
        }
        
        [InlineData(@"pid:000000000", true)]
        [InlineData(@"pid:123456789", true)]
        [InlineData(@"pid:abcdefghi", false)]
        [InlineData(@"pid:a12345678", false)]
        [InlineData(@"pid:12345678", false)]
        [InlineData(@"pid:0123456789", false)]
        [InlineData(@"", false)]
        [InlineData(@"pid:", false)]
        [InlineData(@"pid:am", false)]
        [Theory(DisplayName = "Day 4 - Passport - Passport ID Is Valid")]
        public void Day4_Passport_PassportIdIsValid(string input, bool expectedIsValid)
        {
                var passport = PassportFactory.ParsePassportFromString(input);
                Assert.Equal(expectedIsValid, passport.PassportIdIsValid());
        }
    }
}