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
    /// Interaction logic for ResultSurface.xaml
    /// </summary>
    public partial class ResultSurface : UserControl
    {
        private List<Player> players;
        private StringBuilder result, winners;
        public ResultSurface(List<Player> players)
        {
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(Globalization.SetLanguage());
            this.players = players;                        
            getWinners();
            getResult();
        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Load.LoadEnvironmentFromDB();
            }
            catch
            {
                WindowController.setPrimaryWindowContent(new Pages.NewGameSurface());                
            }
            WindowController.closeSecondaryWindow();
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            WindowController.closeSecondaryWindow();
        }

        private void getWinners()
        {
            winners = new StringBuilder();
            players = players.OrderByDescending(x => x.Score).ToList();

            int i = 1;
            winners.Append(players[0].Name + ": " + players[0].Score);

            while (players[i].Score == players[0].Score)
            {
                winners.Append("\n" + players[i].Name + ": " + players[i].Score);
                players.RemoveAt(i);
                i++;
            }
            players.RemoveAt(0);

            lblWinner.Content = winners;
        }

        private void getResult()
        {
            result = new StringBuilder();
            for (int i = 0; i < players.Count; i++)
            {
                result.Append("\n" + players[i].Name + ": " + players[i].Score);
            }

            lblResult.Content = result;
        }
    }
}
