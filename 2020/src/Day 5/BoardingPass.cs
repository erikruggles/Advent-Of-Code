using System;
using System.Linq;

namespace AdventOfCode2020.Day_5
{

    public record BoardingPass
    {
        public string RowIndicator { get; set; }
        public string SeatIndicator { get; set; }

        public BoardingPass(string rowIndicator, string seatIndicator)
        {
            RowIndicator = rowIndicator;
            SeatIndicator = seatIndicator;
        }

        public int DetermineRowNumber()
        {
            var seats = Enumerable.Range(0, 127).ToArray();
            return BinarySearch(RowIndicator, "f", seats);
        }

        public int DetermineSeatNumber()
        {
            var seats = Enumerable.Range(0, 7).ToArray();
            return BinarySearch(SeatIndicator, "l", seats);
        }

        public int DetermineSeatId()
        {
            return 8 * DetermineRowNumber() + DetermineSeatNumber();
        }

        public int BinarySearch(string searchString, string lowerHalfIndicator, int[] remainingSeats)
        {
            if (remainingSeats.Length == 1)
            {
                return remainingSeats[0];
            }

            if (searchString[0].ToString().Equals(lowerHalfIndicator, StringComparison.OrdinalIgnoreCase))
            {
                return BinarySearch(searchString[1..], lowerHalfIndicator, remainingSeats[..^(remainingSeats.Length / 2)]); ;
            }

            return BinarySearch(searchString[1..], lowerHalfIndicator, remainingSeats[^(remainingSeats.Length / 2)..]);
        }
    }

    public class BoardingPassFactory
    {
        public static BoardingPass CreateBoardingPassFromString(string input)
        {
            return new BoardingPass(input[..^3], input[^3..]);
        }
    }
}