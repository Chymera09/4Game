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
    /// Interaction logic for SaveWarning.xaml
    /// </summary>
    public partial class SaveWarning : UserControl
    {
        Button sender;
        public SaveWarning(object sender)
        {
            InitializeComponent();
            this.sender = (Button)sender;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNoSave_Click(object sender, RoutedEventArgs e)
        {
            if(this.sender.Name == "btnNewGame")
            {
                WindowController.closeSecondaryWindow();
                WindowController.setNewGameSurface();
            }

            else
            {
                WindowController.closeSecondaryWindow();
                WindowController.closePrimaryWindow();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowController.closeSecondaryWindow();
        }
        
    }
}
