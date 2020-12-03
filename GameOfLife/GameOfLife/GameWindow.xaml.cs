using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace GameOfLife
{
    /// <summary>
    /// Logique d'interaction pour GameWindow.xaml
    /// </summary>
    public partial class GameWindow : Window
    {
        private Grid gameGrid;
        public GameWindow(int x, int y)
        {

            gameGrid = new Grid(x, y);

            for(int i = 0; i < x; i++)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition());
                for(int j = 0; j < y; j++)
                {
                    Button b = new Button();
                    b.Content = $"({i};{j})";
                    grid.RowDefinitions.Add(new RowDefinition());
                }
            }
            InitializeComponent();

        }
    }
}
