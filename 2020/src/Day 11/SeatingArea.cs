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
        
        public int DetermineNewSeatStateUsingAdjacentRules(int y, int x)
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

        public int DetermineNewSeatStateUsingLineOfSightRules(int y, int x)
        {
            var seat = Floor[y, x];

            if (seat == SeatingOptions.Floor)
            {
                return SeatingOptions.Floor;
            }

            var occupiedNearby = 0;
            if (IsTheNextSeatOccupied(y, x, SeatingDirection.Up)) occupiedNearby++;
            if (IsTheNextSeatOccupied(y, x, SeatingDirection.Down)) occupiedNearby++;
            if (IsTheNextSeatOccupied(y, x, SeatingDirection.Left)) occupiedNearby++;
            if (IsTheNextSeatOccupied(y, x, SeatingDirection.Right)) occupiedNearby++;
            if (IsTheNextSeatOccupied(y, x, SeatingDirection.DiagonalDownLeft)) occupiedNearby++;
            if (IsTheNextSeatOccupied(y, x, SeatingDirection.DiagonalDownRight)) occupiedNearby++;
            if (IsTheNextSeatOccupied(y, x, SeatingDirection.DiagonalUpLeft)) occupiedNearby++;
            if (IsTheNextSeatOccupied(y, x, SeatingDirection.DiagonalUpRight)) occupiedNearby++;

            if (seat == SeatingOptions.EmptySeat)
            {
                return occupiedNearby == 0 ? SeatingOptions.OccupiedSeat : SeatingOptions.EmptySeat;
            }

            return occupiedNearby < 5 ? SeatingOptions.OccupiedSeat : SeatingOptions.EmptySeat;
        }

        public bool IsTheNextSeatOccupied(int y, int x, SeatingDirection seatingDirection)
        {
            var currentY = y;
            var currentX = x;
            while (true)
            {
                if (seatingDirection.HasFlag(SeatingDirection.Up))
                {
                    currentY--;
                }

                if (seatingDirection.HasFlag(SeatingDirection.Down))
                {
                    currentY++;
                }

                if (seatingDirection.HasFlag(SeatingDirection.Left))
                {
                    currentX--;
                }

                if (seatingDirection.HasFlag(SeatingDirection.Right))
                {
                    currentX++;
                }

                if (currentY < 0 || currentY >= Floor.GetLength(0))
                {
                    return false;
                }

                if (currentX < 0 || currentX >= Floor.GetLength(1))
                {
                    return false;
                }

                if (Floor[currentY, currentX] == SeatingOptions.EmptySeat)
                {
                    return false;
                }
                
                if (Floor[currentY, currentX] == SeatingOptions.OccupiedSeat)
                {
                    return true;
                }
            }
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

    [Flags]
    public enum SeatingDirection
    {
        Up = 1,
        Down = 2,
        Left = 4,
        Right = 8,
        DiagonalUpRight = Up | Right,
        DiagonalUpLeft = Up | Left,
        DiagonalDownRight = Down | Right,
        DiagonalDownLeft = Down | Left
    }
}