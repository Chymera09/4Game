﻿using System;
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
    /// Interaction logic for ColorPickerSurface.xaml
    /// </summary>
    public partial class ColorPickerSurface : UserControl
    {
        private Label sender;
        public ColorPickerSurface(object sender)
        {
            InitializeComponent();
            this.sender = (Label)sender;
        }

        private void Color_Click(object sender, RoutedEventArgs e)
        {
            Label label = (Label)sender;
            NewGameSurface.setColor(this.sender, label.Background);
            WindowController.closeSecondaryWindow();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            WindowController.closeSecondaryWindow();
        }
    }
}
