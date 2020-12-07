using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2020.Day_7
{
    public record Bag
    {
        public string Color { get; set; }
        public Dictionary<string, int> PossibleContents { get; set; }

        public Bag(string color, Dictionary<string, int> possibleContents)
        {
            Color = color;
            PossibleContents = possibleContents;
        }
    }

    public class BagFactory
    {
        public static Bag CreateBagFromString(string input)
        {
            var parts = input.Trim('.').Split(" bags contain ");

            return new Bag(parts[0], CreateChildBagsFromString(parts[1]));
        }

        public static Dictionary<string, int> CreateChildBagsFromString(string input)
        {
            if (input.Equals("no other bags"))
            {
                return new Dictionary<string, int>();
            }

            var rawPossibleContents = input.Split(", ");
            var possibleContents = new Dictionary<string, int>();

            foreach (var rawPossibleContent in rawPossibleContents)
            {
                var contentParts = rawPossibleContent.Split(' ');
                possibleContents.Add(string.Join(" ", contentParts[1..^1]), int.Parse(contentParts[0]));
            }

            return possibleContents;
        }
    }
}
