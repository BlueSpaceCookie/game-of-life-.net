using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GameOfLife
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            int[] gridSize = GetSelectedSize();
            GameWindow game = new GameWindow(gridSize[0], gridSize[1]);
            game.Show();
        }

        private int[] GetSelectedSize()
        {
            if ((bool)aSize.IsChecked)
            {
                return new int[]{10, 10};
            }
            else if((bool)bSize.IsChecked)
            {
                return new int[] { 50, 50 };
            }
            else if ((bool)cSize.IsChecked)
            {
                return new int[] { 100, 100 };
            }
            else if ((bool)dSize.IsChecked)
            {
                return new int[] { 150, 150 };
            }
            return new int[] { 50, 50 };
        }
    }
}
