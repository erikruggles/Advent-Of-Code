using System.Collections.Generic;
using System.Collections.Immutable;

namespace AdventOfCode2020.Day_06
{
    public class PassengerGroupFactory
    {
        public static PassengerGroup CreatePassengerGroupFromString(string input)
        {
            return new PassengerGroup(input.Split("\r\n"));
        }
    }

    public record PassengerGroup
    {
        public ImmutableList<string> SurveyResponses { get; set; }

        public PassengerGroup(IEnumerable<string> surveyResponses)
        {
            SurveyResponses = surveyResponses.ToImmutableList();
        }

        public ImmutableList<char> DetermineAffirmativeQuestionsThatAnyoneAnswered()
        {
            return SurveyResponses.SelectMany(r => r.ToCharArray()).Distinct().ToImmutableList();
        }

        public ImmutableList<char> DetermineAffirmativeQuestionsThatEveryoneAnswered()
        {
            var responses = SurveyResponses.Select(r => r.ToCharArray()).ToList();
            var allAgreedResponses = responses[0];
            foreach (var response in SurveyResponses.Skip(1))
            {
                allAgreedResponses = allAgreedResponses.Intersect(response).ToArray();
            }
            return allAgreedResponses.ToImmutableList();
        }
    }
}
