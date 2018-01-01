using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Game
{
    public class WindowController
    {
        private static PrimaryWindow primaryWindow;
        private static SecondaryWindow secondaryWindow;
        public static void showPrimaryWindow()
        {
            primaryWindow = new PrimaryWindow();
            primaryWindow.Show();
        }

        public static void closePrimaryWindow()
        {
            primaryWindow.Close();
        }

        public static void setNewGameSurface()
        {
            primaryWindow.Content = new Pages.NewGameSurface();
        }

        public static void showColorPicker(object sender)
        {
            secondaryWindow = new SecondaryWindow();
            Pages.ColorPickerSurface colorPicker = new Pages.ColorPickerSurface(sender);
            secondaryWindow.Content = colorPicker;
            secondaryWindow.ShowDialog();
        }

        public static void showNumberOutOfRangeWarning()
        {
            secondaryWindow = new SecondaryWindow();
            secondaryWindow.Content = new WarningSurfaces.NumberNotInRangeWarning();
            secondaryWindow.ShowDialog();
        }

        public static void closeSecondaryWindow()
        {
            secondaryWindow.Close();
            secondaryWindow = new SecondaryWindow();
        }

        public static void setGameSurface()
        {
            primaryWindow.Content = new Pages.GameSurface();
        }
    }
}
