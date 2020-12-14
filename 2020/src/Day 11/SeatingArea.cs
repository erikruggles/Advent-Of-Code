using System;

namespace AdventOfCode2020.Day_11
{
    public class SeatingArea
    {
        public SeatingArea(int[,] floor)
        {
            Floor = floor;
        }

        public int[,] Floor { get; }

        public (int floor, int unoccupied, int occupied) DetermineFloorStatus()
        {
            var floor = 0;
            var unoccupied = 0;
            var occupied = 0;

            for (var y = 0; y < Floor.GetLength(0); y++)
            {
                for (var x = 0; x < Floor.GetLength(1); x++)
                {
                    switch (Floor[y, x])
                    {
                        case SeatingOptions.Floor:
                            floor++;
                            break;
                        case SeatingOptions.EmptySeat:
                            unoccupied++;
                            break;
                        case SeatingOptions.OccupiedSeat:
                            occupied++;
                            break;
                    }
                }
            }

            return (floor, unoccupied, occupied);
        }
        
        public int DetermineSeatsNewState(int x, int y)
        {
            var seat = Floor[y, x];

            if (seat == SeatingOptions.Floor)
            {
                return SeatingOptions.Floor;
            }

            var occupiedNearby = 0;
            for (var i = Math.Max(0, x - 1); i <= Math.Min(x + 1, Floor.GetLength(1) - 1); i++)
            {
                for (var j = Math.Max(0, y - 1); j <= Math.Min(y + 1, Floor.GetLength(0) - 1); j++)
                {
                    if (i == x && j == y)
                    {
                        continue;
                    }

                    var inspectingSeat = Floor[j, i];

                    switch (inspectingSeat)
                    {
                        case SeatingOptions.Floor:
                            continue;
                        case SeatingOptions.OccupiedSeat:
                            occupiedNearby++;
                            break;
                    }
                }
            }
            
            if (seat == SeatingOptions.EmptySeat)
            {
                return occupiedNearby == 0 ? SeatingOptions.OccupiedSeat : SeatingOptions.EmptySeat;
            }

            return occupiedNearby < 4 ? SeatingOptions.OccupiedSeat : SeatingOptions.EmptySeat;
        }
        
        public static bool operator ==(SeatingArea left, SeatingArea right)
        {
            if (left.Floor.Rank != 2 || right.Floor.Rank != 2)
            {
                return false;
            }
            
            if (left.Floor.GetLength(0) != right.Floor.GetLength(0))
            {
                return false;
            }

            if (left.Floor.GetLength(1) != right.Floor.GetLength(1))
            {
                return false;
            }

            for (var y = 0; y < left.Floor.GetLength(0); y++)
            {
                for (var x = 0; x < left.Floor.GetLength(1); x++)
                {
                    if (left.Floor[y, x] != right.Floor[y, x])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        
        public static bool operator !=(SeatingArea left, SeatingArea right)
        {
            if (left.Floor.Rank != 2 || right.Floor.Rank != 2)
            {
                return true;
            }
            
            if (left.Floor.GetLength(0) != right.Floor.GetLength(0))
            {
                return true;
            }

            if (left.Floor.GetLength(1) != right.Floor.GetLength(1))
            {
                return true;
            }

            for (var y = 0; y < left.Floor.GetLength(0); y++)
            {
                for (var x = 0; x < left.Floor.GetLength(1); x++)
                {
                    if (left.Floor[y, x] != right.Floor[y, x])
                    {
                        return true;
                    }
                }
            }

            return false;
        }
        
        protected bool Equals(SeatingArea other)
        {
            return Floor == other.Floor;
        }

        public override bool Equals(object? obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((SeatingArea) obj);
        }

        public override int GetHashCode()
        {
            return Floor.GetHashCode();
        }

    }

    public class SeatingOptions
    {
        public const int Floor = 0;
        public const int EmptySeat = 1;
        public const int OccupiedSeat = 2;
    }
}