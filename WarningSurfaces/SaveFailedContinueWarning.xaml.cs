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
    /// Interaction logic for SaveFailedContinueWarning.xaml
    /// </summary>
    public partial class SaveFailedContinueWarning : UserControl
    {
        private Button sender;
        public SaveFailedContinueWarning(Button sender)
        {
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(Globalization.SetLanguage());
            this.sender = sender;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowController.closeSecondaryWindow();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (this.sender.Name == "btnNewGame")
            {
                try
                {
                    Load.LoadEnvironmentFromDB();
                    WindowController.closeSecondaryWindow();
                }
                catch
                {
                    WindowController.showSecondaryWindow(new Pages.NewGameSurface());
                }
            }
            else
            {
                WindowController.closeSecondaryWindow();
                WindowController.closePrimaryWindow();
                
            }
        }
    }
}
