using System;
using System.Threading;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace GameOfLife
{
    /// <summary>
    /// Logique d'interaction pour GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private GameGrid GameGrid;
        private bool Playing;
        

        private DispatcherTimer Timer;
        public GameWindow(int x, int y)
        {
            InitializeComponent();

            Timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 500)
            };
            Timer.Tick += TimerTick;

            GameGrid = new GameGrid(x, y);
            CellArray = new GeometryDrawing[x, y];
            Playing = false;

            

            UpdateImage();

            grid.MouseDown += CellClick;
        }

        private void UpdateImage()
        {
            DrawingGroup imageDrawings = new DrawingGroup();
            

            for (int i = 0; i < GameGrid.SizeX; i++)
            {
                for (int j = 0; j < GameGrid.SizeY; j++)
                {
                    bool state = GameGrid.GetCellState(i, j);
                    GeometryDrawing rect = new GeometryDrawing(state ? Brushes.Black : Brushes.White, new Pen(Brushes.Black, 1), new RectangleGeometry(new Rect(10 * i, 10 * j, 10, 10)));
                    CellArray[i, j] = rect;
                    imageDrawings.Children.Add(rect);
                }
            }

            DrawingImage image = new DrawingImage(imageDrawings);
            grid.Source = image;
            image.Freeze();
        }

        private void PlayOneRound()
        {
            GameGrid.PlayRound();

            UpdateImage();
        }


        private void CellClick(object sender, MouseEventArgs e)
        {
            if (!Playing)
            {
                Point pos = e.GetPosition(grid);

                double width = grid.ActualWidth;
                double height = grid.ActualHeight;

                int i = (int)(pos.X / width * GameGrid.SizeX);
                int j = (int)(pos.Y / height * GameGrid.SizeY);
                bool newState = !GameGrid.GetCellState(i, j);
                GameGrid.SetCellState(i, j, newState);
                UpdateImage();
            }
        }

        private void PlayClick(object sender, RoutedEventArgs e)
        {
            Playing = true;
            Timer.Start();
        }

        private void PauseClick(object sender, RoutedEventArgs e)
        {
            Playing = false;
        }

        private void ResetClick(object sender, RoutedEventArgs e)
        {
        }

        private void TimerTick(object sender, EventArgs e)
        {
            if (Playing)
            {
                PlayOneRound();
            }
            else
            {
                Timer.Stop();
            }
        }
    }
}
