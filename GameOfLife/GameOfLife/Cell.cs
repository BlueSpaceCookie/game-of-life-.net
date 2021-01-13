using System.Windows.Controls;
using System.Windows.Media;

namespace GameOfLife
{
    class Cell : Button
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
                Background = value ? Brushes.Black : Brushes.White;
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
