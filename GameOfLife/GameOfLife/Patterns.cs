using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class Patterns
    {
        public static int[][] Cell(int x, int y)
        {
            return new int[][]
            {
                new int[]{ x, y }
            };
        }

        public static int[][] Line(int x, int y)
        {
            return new int[][]
            {
                new int[]{ x, y },
                new int[]{ x, y + 1 },
                new int[]{ x, y - 1 }
            };
        }

        public static int[][] Glider(int x, int y)
        {
            return new int[][]
            {
                new int[]{ x, y },
                new int[]{ x, y + 1 },
                new int[]{ x, y - 1 },
                new int[]{ x - 1, y + 1 },
                new int[]{ x - 2, y}
            };
        }

        public static int[][] Cross(int x, int y)
        {
            return new int[][]
            {
                new int[]{ x, y },
                new int[]{ x + 1, y },
                new int[]{ x - 1, y },
                new int[]{ x + 2, y },
                new int[]{ x - 2, y },
                new int[]{ x + 3, y },
                new int[]{ x - 3, y },
                new int[]{ x, y + 1 },
                new int[]{ x, y - 1 },
                new int[]{ x, y + 2 },
                new int[]{ x, y - 2 },
                new int[]{ x, y + 3 },
                new int[]{ x, y - 3 }
            };
        }

        public static int[][] Star(int x, int y)
        {
            return new int[][]
            {
                new int[]{ x, y },
                new int[]{ x + 1, y + 1 },
                new int[]{ x - 1, y - 1 },
                new int[]{ x + 1, y - 1 },
                new int[]{ x - 1, y + 1 },
                new int[]{ x, y + 2 },
                new int[]{ x, y - 2 },
                new int[]{ x + 2, y },
                new int[]{ x - 2, y }
            };
        }
    }
}
