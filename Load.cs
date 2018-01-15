using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using DAL.Models;

namespace _4Game
{
    class Load
    {
        public static void LoadEnvironmentFromDB()
        {
            List<Player> players = new List<Player>();
            using (var db = new GameContext())
            {
                var environment = db.environment
                    .Where(x => x.OID == db.environment.Max(y => y.OID))
                    .FirstOrDefault();

                if (environment.Language == "HUN")
                    Globalization.SetLanguage(Language.HUN);
                else
                    Globalization.SetLanguage(Language.ENG);                

                var simplePlayersList = db.players
                    .Where(x => x.Environment.OID == environment.OID)
                    .Select(x => new SimplePlayer()
                    {
                        Name = x.Name,
                        Color = x.Color
                    })
                         .ToList();
                
                for (int i = 0; i < simplePlayersList.Count; i++)
                {
                    players.Add(new Player(simplePlayersList[i].Name, new SolidColorBrush((Color)ColorConverter.ConvertFromString(simplePlayersList[i].Color))));
                }              

                Settings.RowNumber = (byte)environment.RowNumber;
                Settings.ColumnNumber = (byte)environment.ColumnNumber;
                Settings.Diagonal = environment.Diagonal;
                Settings.MaxValueClick = environment.MaxValueClick;
                Settings.HiddenFieldNumbers = environment.HiddenFieldNumbers;

                WindowController.setPrimaryWindowContent(new Pages.NewGameSurface((byte)environment.PlayerNumber, players));
            }           
        }

        public static void LoadGameFromDB()
        {
            byte currentPlayer;
            List<Player> playersList = new List<Player>();
            using (var db = new GameContext())
            {
                var game = db.games
                    .Where(x => x.OID == db.games.Max(y => y.OID))
                    .FirstOrDefault();

                Settings.RowNumber = (byte)game.RowNumber;
                Settings.ColumnNumber = (byte)game.ColumnNumber;
                currentPlayer = (byte)game.CurrentPlayer;
                Settings.Diagonal = game.Diagonal;
                Settings.MaxValueClick = game.MaxValueClick;
                Settings.HiddenFieldNumbers = game.HiddenFieldNumbers;

                var simplePlayersList = db.players
                   .Where(x => x.Game.OID == game.OID)
                   .Select(x => new SimplePlayer()
                   {
                       Name = x.Name,
                       Score = (int)x.Score,
                       Color = x.Color
                   })
                   .ToList();

                for (int i = 0; i < simplePlayersList.Count; i++)
                {
                    playersList.Add(new Player(simplePlayersList[i].Name, 
                        new SolidColorBrush((Color)ColorConverter.ConvertFromString(simplePlayersList[i].Color)),
                        simplePlayersList[i].Score));
                }

                var fieldDataList = db.field
                    .Where(x => x.Game.OID == game.OID)
                    .Select(x => new FieldData()
                    {
                        Row = x.Row,
                        Column = x.Column,
                        Value = x.Value,
                        Color = x.Color
                    })
                    .ToList();

                GameLogic field = new GameLogic(Settings.RowNumber, Settings.ColumnNumber);
                foreach (var item in fieldDataList)
                {
                    field.setValue(item.Row, item.Column, item.Value);
                    field.setColor(item.Row, item.Column, new SolidColorBrush((Color)ColorConverter.ConvertFromString(item.Color)));
                }

                WindowController.setPrimaryWindowContent(new Pages.GameSurface(playersList, currentPlayer, field));
            }
        }
    }
}
