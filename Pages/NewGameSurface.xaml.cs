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
    public partial class NewGameSurface : UserControl
    {        
        private byte playerNumber;

        public NewGameSurface()
        {
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(Globalization.SetLanguage());

            btn2Players_Click(this, null);
            setColor(lblColor1);
            setColor(lblColor2);
        }

        /* BETÖLTÉSHEZ!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
         * public NewGameSurface()
         {
             InitializeComponent();
         }*/

        private void btn2Players_Click(object sender, RoutedEventArgs e)
        {
            playerNumber = 2;
            btn2Players.IsChecked = true;
            btn3Players.IsChecked = false;
            btn4Players.IsChecked = false;

            lblPlayer3.Foreground = Brushes.Black;
            tbName3.IsEnabled = false;
            lblColorText3.Foreground = Brushes.Black;
            lblColor3.Background = Brushes.Black;
            lblColor3.IsEnabled = false;

            lblPlayer4.Foreground = Brushes.Black;
            tbName4.IsEnabled = false;
            lblColorText4.Foreground = Brushes.Black;
            lblColor4.Background = Brushes.Black;
            lblColor4.IsEnabled = false;
        }

        private void btn3Players_Click(object sender, RoutedEventArgs e)
        {
            btn2Players.IsChecked = false;
            btn3Players.IsChecked = true;
            btn4Players.IsChecked = false;

            playerNumber = 3;
            byte color = Convert.ToByte(lblColor3.Tag);

            lblPlayer3.Foreground = Brushes.Orange;
            tbName3.IsEnabled = true;
            lblColorText3.Foreground = Brushes.Orange;
            lblColor3.IsEnabled = true;
            setColor(lblColor3);

            lblPlayer4.Foreground = Brushes.Black;
            tbName4.IsEnabled = false;
            lblColorText4.Foreground = Brushes.Black;
            lblColor4.IsEnabled = false;
            lblColor4.Background = Brushes.Black;           
        }

        private void btn4Players_Click(object sender, RoutedEventArgs e)
        {
            btn2Players.IsChecked = false;
            btn3Players.IsChecked = false;
            btn4Players.IsChecked = true;

            playerNumber = 4;
            byte color = Convert.ToByte(lblColor3.Tag);

            lblPlayer3.Foreground = Brushes.Orange;
            tbName3.IsEnabled = true;
            lblColorText3.Foreground = Brushes.Orange;
            lblColor3.IsEnabled = true;
            setColor(lblColor3);

            lblPlayer4.Foreground = Brushes.Orange;
            tbName4.IsEnabled = true;
            lblColorText4.Foreground = Brushes.Orange;
            color = Convert.ToByte(lblColor4.Tag);
            lblColor4.IsEnabled = true;
            setColor(lblColor4);
        }

        private void setColor(Label lblColor)
        {
            byte color = Convert.ToByte(lblColor.Tag);
            lblColor.Background = new SolidColorBrush(Color.FromArgb(ColorPalette.alpha, ColorPalette.colors[color, 0],
                                                   ColorPalette.colors[color, 1], ColorPalette.colors[color, 2]));            
        }

        public static void setColor(Label sender, Byte color)
        {
            sender.Background = new SolidColorBrush(Color.FromArgb(ColorPalette.alpha, ColorPalette.colors[color, 0],
                                                   ColorPalette.colors[color, 1], ColorPalette.colors[color, 2]));
        }

        private void imgHunFlag_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Resources.MergedDictionaries.Add(Globalization.SetLanguage(_4Game.Language.HUN));
        }

        private void imgEngFlag_MouseUp(object sender, MouseButtonEventArgs e)
        {
            this.Resources.MergedDictionaries.Add(Globalization.SetLanguage(_4Game.Language.ENG));
        }        

        private void SelectAllText(object sender, RoutedEventArgs e)
        {
            TextBox textBox = e.OriginalSource as TextBox;
            if (textBox != null)
            {
                Keyboard.Focus(textBox);
                textBox.SelectAll();
            }
        }

        private void SelecAllTextMouseButton(object sender, MouseButtonEventArgs e)
        {
            TextBox textBox = (sender as TextBox);
            if (textBox != null)
            {
                if (!textBox.IsKeyboardFocusWithin)
                {
                    e.Handled = true;
                    textBox.Focus();
                }
            }
        }

        private void EnterKeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key != System.Windows.Input.Key.Enter)
                return;
            //StartGameButton_Click(this, e);

            e.Handled = true;
        }

        private new void PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = !Validators.isNumber(e.Text);
        }
        private void ColorPicker_Click(object sender, MouseButtonEventArgs e)
        {
            WindowController.openColorPicker(sender);
        }

        private void btnRandom1_Click(object sender, RoutedEventArgs e)
        {
            tbColumnNumber.Text = Random.getRandom().ToString();
        }

        private void btnRandom2_Click(object sender, RoutedEventArgs e)
        {
            tbRowNumber.Text = Random.getRandom().ToString();
        }
    }
}
