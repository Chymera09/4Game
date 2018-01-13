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

namespace _4Game.Pages
{
    /// <summary>
    /// Interaction logic for SettingSurface.xaml
    /// </summary>
    public partial class SettingSurface : UserControl
    {
        public SettingSurface()
        {
            InitializeComponent();
            cbDiagonalClick.IsChecked = Settings.Diagonal;
            cbMaxValueButtonClick.IsChecked = Settings.MaxValueClick;
            cbHiddenFieldNumbers.IsChecked = Settings.HiddenFieldNumbers;
        }

        private void ApplyButton_Click(object sender, RoutedEventArgs e)
        {
            Settings.Diagonal = (bool)cbDiagonalClick.IsChecked;
            Settings.MaxValueClick = (bool)cbMaxValueButtonClick.IsChecked;
            Settings.HiddenFieldNumbers = (bool)cbHiddenFieldNumbers.IsChecked;
            WindowController.closeSecondaryWindow();
        }

        private void DefaultButton_Click(object sender, RoutedEventArgs e)
        {
            cbDiagonalClick.IsChecked = false;
            cbMaxValueButtonClick.IsChecked = true;
            cbHiddenFieldNumbers.IsChecked = false;
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            WindowController.closeSecondaryWindow();
        }
    }
}
