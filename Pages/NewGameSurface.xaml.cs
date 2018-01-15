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
        private Player player1, player2, player3, player4;

        public NewGameSurface()
        {
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(Globalization.SetLanguage());

            btn2Players_Click(this, null);
            Settings.Diagonal = false;
            Settings.MaxValueClick = true;
            Settings.HiddenFieldNumbers = false;
        }
     
         public NewGameSurface(byte playerNumber, List<Player> players)
         {
             InitializeComponent();
            this.Resources.MergedDictionaries.Add(Globalization.SetLanguage());
            //player1
            tbName1.Text = players[0].Name;
            lblColor1.Background = players[0].Color;

            //player2
            tbName2.Text = players[1].Name;
            lblColor2.Background = players[1].Color;

            //player3
            tbName3.Text = players[2].Name;
            lblColor3.Background = players[2].Color;

            //player4
            tbName4.Text = players[3].Name;
            lblColor4.Background = players[3].Color;

            if (playerNumber == 2)
                btn2Players_Click(this, null);
            else if(playerNumber == 3)
                btn3Players_Click(this, null);
            else
                btn4Players_Click(this, null);

            tbRowNumber.Text = Settings.RowNumber.ToString();
            tbColumnNumber.Text = Settings.ColumnNumber.ToString();
        }

        private void btn2Players_Click(object sender, RoutedEventArgs e)
        {
            playerNumber = 2;
            btn2Players.IsChecked = true;
            btn3Players.IsChecked = false;
            btn4Players.IsChecked = false;

            lblPlayer3.Foreground = Brushes.Black;
            tbName3.IsEnabled = false;
            lblColorText3.Foreground = Brushes.Black;
            if (lblColor3.Background != Brushes.Black)
                setTag(lblColor3, lblColor3.Background);
            lblColor3.Background = Brushes.Black;
            lblColor3.IsEnabled = false;

            lblPlayer4.Foreground = Brushes.Black;
            tbName4.IsEnabled = false;
            lblColorText4.Foreground = Brushes.Black;
            if (lblColor4.Background != Brushes.Black)
                setTag(lblColor4, lblColor4.Background);
            lblColor4.Background = Brushes.Black;
            lblColor4.IsEnabled = false;
        }

        private void btn3Players_Click(object sender, RoutedEventArgs e)
        {
            btn2Players.IsChecked = false;
            btn3Players.IsChecked = true;
            btn4Players.IsChecked = false;

            playerNumber = 3;

            lblPlayer3.Foreground = Brushes.Orange;
            tbName3.IsEnabled = true;
            lblColorText3.Foreground = Brushes.Orange;
            lblColor3.IsEnabled = true;
            if (lblColor3.Background != Brushes.Black)
                setTag(lblColor3, lblColor3.Background);
            setColorFromTag(lblColor3);

            lblPlayer4.Foreground = Brushes.Black;
            tbName4.IsEnabled = false;
            lblColorText4.Foreground = Brushes.Black;
            if (lblColor4.Background != Brushes.Black)
                setTag(lblColor4, lblColor4.Background);
            lblColor4.IsEnabled = false;            
            lblColor4.Background = Brushes.Black;           
        }

        private void btn4Players_Click(object sender, RoutedEventArgs e)
        {
            btn2Players.IsChecked = false;
            btn3Players.IsChecked = false;
            btn4Players.IsChecked = true;

            playerNumber = 4;

            lblPlayer3.Foreground = Brushes.Orange;
            tbName3.IsEnabled = true;
            lblColorText3.Foreground = Brushes.Orange;
            lblColor3.IsEnabled = true;
            if (lblColor3.Background != Brushes.Black)
                setTag(lblColor3, lblColor3.Background);
            setColorFromTag(lblColor3);

            lblPlayer4.Foreground = Brushes.Orange;
            tbName4.IsEnabled = true;
            lblColorText4.Foreground = Brushes.Orange;
            lblColor4.IsEnabled = true;
            if (lblColor4.Background != Brushes.Black)
                setTag(lblColor4, lblColor4.Background);
            setColorFromTag(lblColor4);
        }

        private void setColor(Label lblColor, string color = "#FFDFD991")
        {
            lblColor.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFDFD991"));
        }

        private void setColorFromTag(Label lblColor)
        {
            lblColor.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString(lblColor.Tag.ToString()));
        }

        private void setTag(Label label, Brush color)
        {
            label.Tag = color.ToString();
        }

        public static void setColor(Label sender, Brush color)
        {
            sender.Background = color;
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

        private void tbTableSize_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            byte size = Convert.ToByte(tb.Text);

            if (size < Constants.MINTABLESIZE)
            {
                WindowController.showSecondaryWindow(new WarningSurfaces.NumberNotInRangeWarning());
                tb.Text = "2";
            }

            if (size > Constants.MAXTABLESIZE)
            {
                WindowController.showSecondaryWindow(new WarningSurfaces.NumberNotInRangeWarning());
                tb.Text = "30";
            }
        }

        private void ColorPicker_Click(object sender, MouseButtonEventArgs e)
        {
            WindowController.showSecondaryWindow(new ColorPickerSurface(sender));
        }

        private void btnRandom1_Click(object sender, RoutedEventArgs e)
        {
            tbColumnNumber.Text = Random.getRandom().ToString();
        }

        private void btnRandom2_Click(object sender, RoutedEventArgs e)
        {
            tbRowNumber.Text = Random.getRandom().ToString();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            Settings.RowNumber = Convert.ToByte(tbRowNumber.Text);
            Settings.ColumnNumber = Convert.ToByte(tbColumnNumber.Text);
            List<Player> playersList = new List<Player>();

            player1 = new Player(tbName1.Text, lblColor1.Background);
            player2 = new Player(tbName2.Text, lblColor2.Background);

            if (playerNumber == 2)
            {
                
                player3 = new Player(tbName3.Text, (Brush)new BrushConverter().ConvertFromString(lblColor3.Tag.ToString()));
                player4 = new Player(tbName4.Text, (Brush)new BrushConverter().ConvertFromString(lblColor4.Tag.ToString()));

                WindowController.setPrimaryWindowContent(new GameSurface(player1, player2));
            }

            else if(playerNumber == 3)
            {
                player3 = new Player(tbName3.Text, lblColor3.Background);
                player4 = new Player(tbName4.Text, (Brush)new BrushConverter().ConvertFromString(lblColor4.Tag.ToString()));
                WindowController.setPrimaryWindowContent(new GameSurface(player1, player2, player3));
            }

            else if (playerNumber == 4)
            {              
                player3 = new Player(tbName3.Text, lblColor3.Background);
                player4 = new Player(tbName4.Text, lblColor4.Background);
                WindowController.setPrimaryWindowContent(new GameSurface(player1, player2, player3, player4));
            }

            playersList.Add(player1);
            playersList.Add(player2);
            playersList.Add(player3);
            playersList.Add(player4);

            Save.SaveEnviromentToDB(Globalization.getLanguage(), playerNumber, playersList);
        }

        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {     
            try
            {
                Load.LoadGameFromDB();               
            }
            catch
            {
                WindowController.showSecondaryWindow(new WarningSurfaces.LoadFailedWarning());
            }
        }

        private void btnSettings_Click(object sender, RoutedEventArgs e)
        {
            WindowController.showSecondaryWindow(new Pages.SettingSurface());
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            WindowController.closePrimaryWindow();
            Application.Current.Shutdown();
        }        
    }
}
