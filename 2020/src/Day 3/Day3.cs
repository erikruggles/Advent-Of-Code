using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.Day_3
{
    public static class Day3
    {
        public static long FindProductOfNumberOfTreesPaths(BiomeSquare[,] biome, List<(int, int)> startingLocations)
        {
            long currentProduct = 1;
            foreach (var (moveY, moveX) in startingLocations)
            {
                var path = FindPath(biome, moveY, moveX);
                currentProduct *= path.Count(b => b.IsTree);
            }

            return currentProduct;
        }

        public static List<BiomeSquare> FindPath (BiomeSquare[,] biome, int moveY, int moveX)
        {
            var x = 0;
            var y = 0;
            var currentLocation = biome[0, 0];
            var path = new List<BiomeSquare> { currentLocation };

            while (true)
            {
                (y, x, currentLocation) = MakeMove(biome, y, x, moveY, moveX);
                if (currentLocation == null)
                {
                    break;
                }
                path.Add(currentLocation);
            }

            return path;
        }

        public static (int newY, int newX, BiomeSquare? newLocation) MakeMove(BiomeSquare[,] biome, int currentY, int currentX, int moveY, int moveX)
        {
            var newY = currentY + moveY;
            var newX = currentX + moveX;
            if (newX >= biome.GetLength(1))
            {
                newX = newX - biome.GetLength(1);
            }

            if (newY >= biome.GetLength(0))
            {
                return (-1, -1, null);
            }

            return (newY, newX, biome[newY, newX]);
        }
    }
}
