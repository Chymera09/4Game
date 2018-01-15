using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace _4Game
{
    public class WindowController
    {
        private static PrimaryWindow primaryWindow;
        private static SecondaryWindow secondaryWindow;
        public static void createPrimaryWindow()
        {
            primaryWindow = new PrimaryWindow();
            //primaryWindow.Show();
            primaryWindow.Hide();
        }

        public static void showPrimaryWindow()
        {
            primaryWindow.Show();
        }

        public static void closePrimaryWindow()
        {
            primaryWindow.Close();
        }

        public static void setPrimaryWindowContent(UserControl content)
        {
            primaryWindow.Content = content;
        }

        /*public static void setNewGameSurface()
        {
            primaryWindow.Content = new Pages.NewGameSurface();
        }*/

        /*public static void setNewGameSurface(byte playerNumber, List<Player> players)
        {
            primaryWindow.Content = new Pages.NewGameSurface(playerNumber, players);
        }*/

        /*public static void setGameSurface(Player p1, Player p2, Player p3 = null, Player p4 = null)
        {
            if(p3 != null && p4 != null)
                primaryWindow.Content = new Pages.GameSurface(p1, p2, p3, p4);

            else if (p3 != null && p4 == null)
                primaryWindow.Content = new Pages.GameSurface(p1, p2, p3);

            else
                primaryWindow.Content = new Pages.GameSurface(p1, p2);

        }*/

        /*public static void setGameSurface(List<Player> players, byte currentPlayer, GameLogic field)
        {
            primaryWindow.Content = new Pages.GameSurface(players, currentPlayer, field);
        }*/

        public static void showSecondaryWindow(UserControl userControl)
        {
            primaryWindow.IsEnabled = false;
            secondaryWindow = new SecondaryWindow();
            secondaryWindow.Content = userControl;
            secondaryWindow.ShowDialog();
        }

        /*public static void showColorPicker(object sender)
        {
            primaryWindow.IsEnabled = false;
            secondaryWindow = new SecondaryWindow();
            Pages.ColorPickerSurface colorPicker = new Pages.ColorPickerSurface(sender);
            secondaryWindow.Content = colorPicker;
            secondaryWindow.ShowDialog();            
        }*/

        /*public static void showNumberOutOfRangeWarning()
        {
            primaryWindow.IsEnabled = false;
            secondaryWindow = new SecondaryWindow();
            secondaryWindow.Content = new WarningSurfaces.NumberNotInRangeWarning();
            secondaryWindow.ShowDialog();            
        }*/

        /*public static void showSettings()
        {
            primaryWindow.IsEnabled = false;
            secondaryWindow = new SecondaryWindow();
            secondaryWindow.Content = new Pages.SettingSurface();
            secondaryWindow.ShowDialog();
        }*/

        public static void closeSecondaryWindow()
        {
            primaryWindow.IsEnabled = true;
            secondaryWindow.Close();           
        }

        
    }
}
