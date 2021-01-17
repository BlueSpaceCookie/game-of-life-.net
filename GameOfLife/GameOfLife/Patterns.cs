using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class Patterns
    {
        public static int[][] cell(int x, int y)
        {
            return new int[][]
            {
                new int[]{ x, y }
            };
        }
        public static int[][] glider(int x, int y)
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
    }
}
