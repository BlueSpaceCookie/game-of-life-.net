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
        private DispatcherTimer Timer;
        private bool Playing;
        private int IterationsCount;
        private MenuItem LastSelectedMenuItem = null;

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
            IterationsCount = 0;
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
            IterationsCount++;
            SetIterationCountLabel(IterationsCount);
        }


        private void CellClick(object sender, RoutedEventArgs e)
        {
            if (!Playing)
            {
                Cell c = (Cell)sender;

                int[][] cells = getCellSelectionType(c.X, c.Y);

                c.State = !c.State;

                foreach(int[] cell in cells)
                {
                    if(cell[0] >= 0 && cell[0] < GameGrid.SizeX  && cell[1] >= 0 && cell[1] < GameGrid.SizeY)
                    {
                        CellArray[cell[0], cell[1]].State = c.State;
                    }
                }

                GameGrid.SetCellState(cells, c.State);
            }
        }

        private void PlayPauseClick(object sender, RoutedEventArgs e)
        {
            if (!Playing)
            {
                playButton.Content = "Pause";
                resetButton.IsEnabled = false;
                Playing = true;
                Timer.Start();
            }
            else
            {
                playButton.Content = "Play";
                Playing = false;
                resetButton.IsEnabled = true;
            }
        }

        private void ResetClick(object sender, RoutedEventArgs e)
        {
            IterationsCount = 0;
            SetIterationCountLabel(IterationsCount);
            for (int i = 0; i < GameGrid.SizeX; i++)
            {
                for (int j = 0; j < GameGrid.SizeY; j++)
                {
                    CellArray[i, j].State = false;
                    int[][] cell = new int[][] { new int[]{ i, j } };
                    GameGrid.SetCellState(cell, false);
                }
            }
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

        private void SetIterationCountLabel(int counter)
        {
            iterationsCounterLabel.Content = "Iterations : " + counter;
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            MenuItem m = sender as MenuItem;

            if (LastSelectedMenuItem != null)
            {
                LastSelectedMenuItem.IsChecked = false;
            }

            LastSelectedMenuItem = m;
        }

        private int[][] getCellSelectionType(int x, int y)
        {
            if(LastSelectedMenuItem != null && LastSelectedMenuItem.IsChecked) 
            { 
                String selectionType = LastSelectedMenuItem.Name as String;

                switch (selectionType)
                {
                    case "gliderPattern":
                        return Patterns.glider(x, y);
                }
            }
            return Patterns.cell(x, y);

        }
    }
}
