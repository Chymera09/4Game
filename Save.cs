using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL.Models;

namespace _4Game
{
    class Save
    {
        public static void SaveEnviromentToDB(string language, int playerNumber, List<Player> players)
        {
            using (var db = new GameContext())
            {              
                var environment = new DAL.Models.Environment {
                    Language = language,
                    PlayerNumber = playerNumber,
                    RowNumber = Settings.RowNumber,
                    ColumnNumber = Settings.ColumnNumber,
                    Diagonal = Settings.Diagonal,
                    MaxValueClick = Settings.MaxValueClick,
                    HiddenFieldNumbers = Settings.HiddenFieldNumbers
                };
                db.environment.Add(environment);
                               
                for (int i = 0; i < players.Count; i++)
                {
                    var player = new DAL.Models.Player {
                        Name = players[i].Name,
                        Color = players[i].Color.ToString(),
                        Environment = environment
                    };
                    db.players.Add(player);
                }
                db.SaveChanges();
            }
        }

        public static void SaveGameToDatabase(List<Player> players, GameLogic table, int currentPlayer)
        {
            using (var db = new GameContext())
            {
                var game = new DAL.Models.Game
                {
                    Date = DateTime.Today,
                    RowNumber = Settings.RowNumber,
                    ColumnNumber = Settings.ColumnNumber,
                    CurrentPlayer = currentPlayer,
                    Diagonal = Settings.Diagonal,
                    MaxValueClick = Settings.MaxValueClick,
                    HiddenFieldNumbers = Settings.HiddenFieldNumbers,
                };
                db.games.Add(game);
                //db.SaveChanges();

                for (int i = 0; i < players.Count; i++)
                {
                    var player = new DAL.Models.Player
                    {
                        Name = players[i].Name,
                        Score = players[i].Score,
                        Color = players[i].Color.ToString(),
                        Game = game
                    };
                    db.players.Add(player);
                }
                //db.SaveChanges();

                int row = Settings.RowNumber;
                int column = Settings.ColumnNumber;

                for (byte i = 0; i < row; i++)
                {
                    for (byte j = 0; j < column; j++)
                    {
                        var field = new DAL.Models.Field
                        {
                            Game = game,
                            Row = i,
                            Column = j,
                            Value = table.getValue(i, j), 
                            Color = table.getColor(i, j).ToString()
                        };
                        db.field.Add(field);                     
                    }
                }
                db.SaveChanges();
            }
        }
    }
}
