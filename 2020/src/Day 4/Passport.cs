using System.Text.RegularExpressions;

namespace AdventOfCode2020.Day_4
{
    public class Passport
    {
        public int? BirthYear { get; set; }
        public int? IssueYear { get; set; }
        public int? ExpirationYear { get; set; }
        public string? Height { get; set; }
        public string? HairColor { get; set; }
        public string? EyeColor { get; set; }
        public string? PassportId { get; set; }
        public int? CountryId { get; set; }
        
        public bool NaiveIsValid()
        {
            return BirthYear != null && IssueYear != null && ExpirationYear != null && Height != null &&
                   HairColor != null && EyeColor != null && PassportId != null;
        }

        public bool StrictIsValid()
        {
            return BirthYearIsValid() && IssueYearIsValid() && ExpirationYearIsValid() && HeightIsValid() &&
                   HairColorIsValid() && EyeColorIsValid() && PassportIdIsValid();
        }

        public bool BirthYearIsValid()
        {
            return BirthYear != null && IsBetweenInclusive(BirthYear.Value, 1920, 2002);
        }
        
        public bool IssueYearIsValid()
        {
            return IssueYear != null && IsBetweenInclusive(IssueYear.Value, 2010, 2020);
        }
        
        public bool ExpirationYearIsValid()
        {
            return ExpirationYear != null && IsBetweenInclusive(ExpirationYear.Value, 2020, 2030);
        }

        public bool HeightIsValid()
        {
            if (Height == null) return false;
            if (Height.EndsWith("cm"))
            {
                return int.TryParse(Height.Substring(0, Height.Length - 2), out var cmHeight) &&
                       IsBetweenInclusive(cmHeight, 150, 193);
            }

            if (Height.EndsWith("in"))
            {
                return int.TryParse(Height.Substring(0, Height.Length - 2), out var inHeight) &&
                       IsBetweenInclusive(inHeight, 59, 76);
            }

            return false;
        }

        public bool HairColorIsValid()
        {
            return HairColor!= null && Regex.IsMatch(HairColor, @"^#[0-9a-f]{6}$");
        }
        
        public bool EyeColorIsValid()
        {
            return EyeColor != null && EyeColor switch
            {
                "amb" => true,
                "blu" => true,
                "brn" => true,
                "gry" => true,
                "grn" => true,
                "hzl" => true,
                "oth" => true,
                _ => false
            };
        }
        
        public bool PassportIdIsValid()
        {
            return PassportId != null && Regex.IsMatch(PassportId, @"^[0-9]{9}$");
        }
        
        public bool IsBetweenInclusive(int input, int lowerBound, int upperBound)
        {
            return input >= lowerBound && input <= upperBound;
        }
    }

    public class PassportFactory
    {
        public static Passport ParsePassportFromString(string input)
        {
            return new Passport
            {
                BirthYear = int.TryParse(ParsePassportField(input, "byr"), out var birthYear) ? (int?) birthYear : null,
                IssueYear = int.TryParse(ParsePassportField(input, "iyr"), out var issueYear) ? (int?) issueYear : null,
                ExpirationYear = int.TryParse(ParsePassportField(input, "eyr"), out var expirationYear)
                    ? (int?) expirationYear
                    : null,
                Height = ParsePassportField(input, "hgt"),
                HairColor = ParsePassportField(input, "hcl"),
                EyeColor = ParsePassportField(input, "ecl"),
                PassportId = ParsePassportField(input, "pid"),
                CountryId = int.TryParse(ParsePassportField(input, "cid"), out var countryId) ? (int?) countryId : null
            };
        }

        public static string? ParsePassportField(string input, string fieldIdentifier)
        {
            var regexMatches = Regex.Match(input, @$"{fieldIdentifier}:(\S+)");
            return regexMatches.Success ? regexMatches.Groups[1].Value : null;
        }
    }
}