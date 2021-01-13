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
        private Cell[,] CellArray;
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
            CellArray = new Cell[x, y];
            Playing = false;

            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Cell c = new Cell(i, j);
                    c.Click += CellClick;

                    CellArray[i, j] = c;
                }
            }

            CreateGameView(x, y);
        }

        private void CreateGameView(int x, int y)
        {
            grid.Width = grid.Height;

            for (int i = 0; i < x; i++)
            {
                RowDefinition horizontal = new RowDefinition();
                grid.RowDefinitions.Add(horizontal);

                ColumnDefinition vertical = new ColumnDefinition();
                grid.ColumnDefinitions.Add(vertical);
            }



            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    Cell c = CellArray[i, j];

                    grid.Children.Add(c);
                    Grid.SetRow(c, i);
                    Grid.SetColumn(c, j);

                }
            }
        }



        private void PlayOneRound()
        {
            GameGrid.PlayRound();

            for (int i = 0; i < GameGrid.SizeX; i++)
            {
                for (int j = 0; j < GameGrid.SizeY; j++)
                {
                    CellArray[i, j].State = GameGrid.GetCellState(i, j);
                }
            }
        }


        private void CellClick(object sender, RoutedEventArgs e)
        {
            if (!Playing)
            {
                Cell c = (Cell)sender;
                c.State = !c.State;

                GameGrid.SetCellState(c.X, c.Y, c.State);
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
