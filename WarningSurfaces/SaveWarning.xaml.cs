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
        List<Player> players;
        byte currentPlayer;
        GameLogic field;
        public SaveWarning(object sender, List<Player> players, byte currentPlayer, GameLogic field)
        {
            InitializeComponent();
            this.sender = (Button)sender;
            this.players = players;
            this.currentPlayer = currentPlayer;
            this.field = field;
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            if (this.sender.Name == "btnNewGame")
            {
                try
                {
                    Save.SaveGameToDatabase(players, field, currentPlayer);
                    WindowController.closeSecondaryWindow();
                    Load.LoadEnvironmentFromDB();
                }
                catch
                {
                    WindowController.closeSecondaryWindow();
                    WindowController.showSecondaryWindow(new WarningSurfaces.SaveFailedContinueWarning(this.sender));
                }                
            }

            else
            {
                try
                {
                    Save.SaveGameToDatabase(players, field, currentPlayer);
                    WindowController.closeSecondaryWindow();
                    WindowController.closePrimaryWindow();
                }
                catch
                {
                    WindowController.closeSecondaryWindow();
                    WindowController.showSecondaryWindow(new WarningSurfaces.SaveFailedContinueWarning(this.sender));
                }                
            }
        }

        private void btnNoSave_Click(object sender, RoutedEventArgs e)
        {
            if(this.sender.Name == "btnNewGame")
            {
                WindowController.closeSecondaryWindow();
                WindowController.setPrimaryWindowContent(new Pages.NewGameSurface());
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
