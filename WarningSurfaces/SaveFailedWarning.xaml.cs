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

namespace _4Game.WarningSurfaces
{
    /// <summary>
    /// Interaction logic for SaveFailedWarning.xaml
    /// </summary>
    public partial class SaveFailedWarning : UserControl
    {
        public SaveFailedWarning()
        {
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(Globalization.SetLanguage());
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowController.closeSecondaryWindow();
        }
    }
}
