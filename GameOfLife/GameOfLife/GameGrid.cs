using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    class GameGrid
    {
        public int SizeX { get; }
        public int SizeY { get; }
        private bool[,] Grid { get; }

        public GameGrid(int _SizeX, int _SizeY)
        {
            SizeX = _SizeX;
            SizeY = _SizeY;
            Grid = new bool[SizeX, SizeY];
        }

        public void PlayRound()
        {
            int[,] aliveNeighbours = new int[SizeX, SizeY];
            for (int x = 0; x < SizeX; ++x)
            {
                for (int y = 0; y < SizeY; ++y)
                {
                    aliveNeighbours[x, y] = AliveNeighborsCount(x, y);
                }
            }

            for (int x = 0; x < SizeX; ++x)
            {
                for (int y = 0; y < SizeY; ++y)
                {
                    int aliveNeighborsCount = aliveNeighbours[x, y];
                    bool currentCellAlive = Grid[x, y];

                    // Any live cell with two or three live neighbours survives.
                    // All other live cells die in the next generation. Similarly, all other dead cells stay dead.
                    if (currentCellAlive && !(aliveNeighborsCount == 2 || aliveNeighborsCount == 3))
                    {
                        Grid[x, y] = false;
                    }
                    else if (!currentCellAlive && aliveNeighborsCount == 3)
                    {
                        Grid[x, y] = true;
                    }
                }
            }
        }

        private int AliveNeighborsCount(int x, int y)
        {
            int count = 0;
            for (int searchX = x - 1; searchX <= x + 1; ++searchX)
            {
                for (int searchY = y - 1; searchY <= y + 1; ++searchY)
                {
                    if (
                        searchX < 0 || searchY < 0 || // Lower bound check
                        searchX >= SizeX || searchY >= SizeY || // Upper bound check
                        (searchX == x && searchY == y)) // Do not count the same cell in the neighbors
                    {
                        continue;
                    }

                    if (Grid[searchX, searchY] == true) // Cell is alie
                    {
                        ++count;
                    }
                }
            }
            return count;
        }

        public void SetCellState(int x, int y, bool state)
        {
            Grid[x, y] = state;
        }

        public bool GetCellState(int x, int y)
        {
            return Grid[x, y];
        }
    }
}