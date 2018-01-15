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
    /// Interaction logic for GameSurface.xaml
    /// </summary>
    public partial class GameSurface : UserControl
    {
        private List<Player> players;
        private GameLogic field;
        private int maxScore, sumScore;
        private byte fontSize, columnNumber, rowNumber;
        int currentPlayerIndex;
        private bool isSaved;
        public GameSurface()
        {
            InitializeComponent();
            this.Resources.MergedDictionaries.Add(Globalization.SetLanguage());
            rowNumber = Settings.RowNumber;
            columnNumber = Settings.ColumnNumber;

            field = new GameLogic(rowNumber, columnNumber);
            CreateField();
            maxScore = rowNumber * columnNumber * Constants.MAXFIELDVALUE;
            sumScore = 0;
            isSaved = true;
            currentPlayerIndex = 0;
            players = new List<Player>();
        }

        public GameSurface(Player p1, Player p2) : this()
        {
            players.Add(p1);
            players[0].scoreLabel = lblPlayer1Score;
            players.Add(p2);
            players[1].scoreLabel = lblPlayer2Score;
            lblCurrentPlayer.Content = players[0].Name;

            lblPlayer1.Foreground = players[0].Color;           
            lblPlayer1Score.Foreground = players[0].Color;
            lblPlayer1.Content = players[0].Name;
            lblPlayer1Score.Content = players[0].Score;

            lblPlayer2.Foreground = players[1].Color;
            lblPlayer2Score.Foreground = players[1].Color;
            lblPlayer2.Content = players[1].Name;
            lblPlayer2Score.Content = players[1].Score;

            lblPlayer3.Foreground = Brushes.Black;
            lblPlayer3Score.Foreground = Brushes.Black;

            lblPlayer4.Foreground = Brushes.Black;
            lblPlayer4Score.Foreground = Brushes.Black;
        }

        public GameSurface(Player p1, Player p2, Player p3) : this(p1, p2)
        {
            players.Add(p3);
            players[2].scoreLabel = lblPlayer3Score;
            lblPlayer3.Foreground = players[2].Color;
            lblPlayer3Score.Foreground = players[2].Color;
            lblPlayer3.Content = players[2].Name;
            lblPlayer3Score.Content = players[2].Score;
        }

        public GameSurface(Player p1, Player p2, Player p3, Player p4) : this(p1, p2, p3)
        {
            players.Add(p4);
            players[3].scoreLabel = lblPlayer4Score;
            lblPlayer4.Foreground = players[3].Color;
            lblPlayer4Score.Foreground = players[3].Color;
            lblPlayer4.Content = players[3].Name;
            lblPlayer4Score.Content = players[3].Score;
        }

        public GameSurface(List<Player> playersList, byte currentPlayer, GameLogic field) : this()
        {
            players = playersList;
            lblPlayer1.Content = players[0].Name;
            players[0].scoreLabel = lblPlayer1Score;
            lblPlayer1Score.Content = players[0].Score;
            lblPlayer1.Foreground = players[0].Color;
            lblPlayer1Score.Foreground = players[0].Color;

            lblPlayer2.Content = players[1].Name;
            players[1].scoreLabel = lblPlayer2Score;
            lblPlayer2Score.Content = players[1].Score;
            lblPlayer2.Foreground = players[1].Color;
            lblPlayer2Score.Foreground = players[1].Color;

            if (players.Count == 3)
            {
                lblPlayer3.Content = players[2].Name;
                players[2].scoreLabel = lblPlayer3Score;
                lblPlayer3Score.Content = players[2].Score;
                lblPlayer3.Foreground = players[2].Color;
                lblPlayer3Score.Foreground = players[2].Color;
            }

            else if(players.Count == 4)
            {
                lblPlayer3.Content = players[2].Name;
                players[2].scoreLabel = lblPlayer3Score;
                lblPlayer3Score.Content = players[2].Score;
                lblPlayer3.Foreground = players[2].Color;
                lblPlayer3Score.Foreground = players[2].Color;

                lblPlayer4.Content = players[3].Name;
                players[3].scoreLabel = lblPlayer4Score;
                lblPlayer4Score.Content = players[3].Score;
                lblPlayer4.Foreground = players[3].Color;
                lblPlayer4Score.Foreground = players[3].Color;
            }

            currentPlayerIndex = currentPlayer;
            lblCurrentPlayer.Content = this.players[currentPlayerIndex].Name;
            this.field = field;
            setTable();
            checkSumScore();
        }

        //Tábla létrehozása gomb
        public void CreateField()
        {
            canvasField.Children.Clear();
            //maxScore = row * column * _4GameLogic.MAXVALUE;
            //setFontSize(height: row, width: column);
            CreateButtons();
        }

        //Canvas gombjainak létrehozása
        private void CreateButtons()
        {
            setFontSize();
            double left = 0, top = 0;
            double width = canvasField.Width / columnNumber;
            double height = canvasField.Height / rowNumber;

            for (byte i = 0; i < rowNumber; i++)
            {
                for (byte j = 0; j < columnNumber; j++)
                {
                    Button newBtn = new Button();

                    newBtn.Height = height;
                    newBtn.Width = width;
                    newBtn.Tag = $"{i.ToString()},{j.ToString()}";
                    newBtn.Content = field.getValue(i, j);
                    newBtn.FontSize = fontSize;
                    newBtn.Background = Brushes.White;
                    //newBtn.BorderBrush = Brushes.Orange;
                    if (Settings.HiddenFieldNumbers)
                        newBtn.Foreground = Brushes.Transparent;
                    else newBtn.Foreground = Brushes.Black;
                    newBtn.Margin = new Thickness(left, top, 0, 0);
                    newBtn.Click += new RoutedEventHandler(Canvas_Click);

                    left += canvasField.Height / columnNumber;
                    canvasField.Children.Add(newBtn);
                }
                left = 0;
                top += canvasField.Width / rowNumber;
            }

            //canvasField.Children.Clear();
            //canvasField.Children.Add(new Button());
        }

        private void setFontSize()
        {
            if (columnNumber <= 10 && rowNumber <= 10)
                fontSize = 12;
            else if (columnNumber <= 15 && rowNumber <= 15)
                fontSize = 10;
            else if (columnNumber <= 20 && rowNumber <= 20)
                fontSize = 9;
            else if (columnNumber <= 25 && rowNumber <= 25)
                fontSize = 8;
            else
                fontSize = 7;
        }
     
        //Canvas-ban lévő gombra kattintás
        private void Canvas_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)sender;
            byte row = 0, column = 0;
            String position = btn.Tag.ToString();

            getCoordinates(position, ref row, ref column);
            field.setFieldValues(row, column, players[currentPlayerIndex]);
            //btn.Content = table.getValue(row, column);
            setTable();
            players[currentPlayerIndex].scoreLabel.Content = players[currentPlayerIndex].Score;
            currentPlayerIndex = ((currentPlayerIndex + 1) % players.Count);
            lblCurrentPlayer.Content = players[currentPlayerIndex].Name;

            isSaved = false;

            checkSumScore();
        }

        private void setTable()
        {
            byte x = 0, y = 0;
            String position;

            foreach (Button btn in canvasField.Children)
            {
                position = btn.Tag.ToString();
                getCoordinates(position, ref x, ref y);
                btn.Content = field.getValue(x, y);
                btn.Background = field.getColor(x, y);
                if (Convert.ToInt32(btn.Content) == 4 && !Settings.MaxValueClick)
                    btn.Click -= new RoutedEventHandler(Canvas_Click);
            }
        }

        private void getCoordinates(string StringCoordinate, ref byte x, ref byte y)
        {
            string[] coordinates = StringCoordinate.Split(',');
            x = Convert.ToByte(coordinates[0]);
            y = Convert.ToByte(coordinates[1]);
        }

        private void checkSumScore()
        {
            sumScore = 0;
            foreach (var player in players)
            {
                sumScore += player.Score;
            }

            if (sumScore == maxScore)
            {
                WindowController.showSecondaryWindow(new Pages.ResultSurface(players));

                if (!Settings.MaxValueClick)
                    foreach (Button button in canvasField.Children)
                    {
                        button.Click -= new RoutedEventHandler(Canvas_Click);
                    }
            }

        }

        private void btnNewGame_Click(object sender, RoutedEventArgs e)
        {
            if (isSaved)
            {
                try
                {
                    Load.LoadEnvironmentFromDB();
                }
                catch
                {
                    WindowController.setPrimaryWindowContent(new Pages.NewGameSurface());
                }
            }
            else
                WindowController.showSecondaryWindow(new WarningSurfaces.SaveWarning(sender, players, (byte)currentPlayerIndex, field));
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

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Save.SaveGameToDatabase(players, field, currentPlayerIndex);
                isSaved = true;
            }
            catch
            {
                WindowController.showSecondaryWindow(new WarningSurfaces.SaveFailedWarning());
            }
        }

        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            if (isSaved)
            {
                WindowController.closePrimaryWindow();
            }
            else
                WindowController.showSecondaryWindow(new WarningSurfaces.SaveWarning(sender, players, (byte)currentPlayerIndex, field));
        }   
    }
}
