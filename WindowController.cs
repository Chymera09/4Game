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
        public static void openPrimaryWindow()
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

        public static void openColorPicker(object sender)
        {
            Pages.ColorPickerSurface colorPicker = new Pages.ColorPickerSurface(sender);
            colorPicker.ShowDialog();
        }
    }
}
