
using System.Windows.Media;
using System.Windows.Shapes;

namespace GameOfLife
{
    class Cell
    {
        private bool _state;

        public int X { get; }
        public int Y { get; }
        public bool State
        {
            get { return _state; }
            set
            {
                _state = value;
            }
        }

        public Cell(int x, int y)
        {
            State = false;
            X = x;
            Y = y;
        }
    }
}
