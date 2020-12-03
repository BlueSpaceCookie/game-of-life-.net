using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class Grid
    {
        private int SizeX { get; }
        private int SizeY { get; }
        private int[,] GameGrid { get;  } 

        public Grid(int _SizeX, int _SizeY)
        {
            SizeX = _SizeX;
            SizeY = _SizeY;
            GameGrid = new int[SizeX, SizeY];
        }
    }
}
