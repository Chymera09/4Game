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
            using (var db = new GameContext())
            {
                var environment = db.environment
                    .Where(x => x.OID == db.environment.Max(y => y.OID))
                    .FirstOrDefault();

                if (environment.Language == "HUN")
                    Globalization.SetLanguage(Language.HUN);
                else
                    Globalization.SetLanguage(Language.ENG);                

                var player = db.players
                    .Where(x => x.Environments.OID == environment.OID)
                    .Select(x => new SimplePlayer()
                    {
                        Name = x.Name,
                        Color = x.Color
                    })
                         .ToList();

                List<Player> players = new List<Player>();
                players.Add(new Player(player[0].Name, new SolidColorBrush((Color)ColorConverter.ConvertFromString(player[0].Color))));
                players.Add(new Player(player[1].Name, new SolidColorBrush((Color)ColorConverter.ConvertFromString(player[1].Color))));
                players.Add(new Player(player[2].Name, new SolidColorBrush((Color)ColorConverter.ConvertFromString(player[2].Color))));
                players.Add(new Player(player[3].Name, new SolidColorBrush((Color)ColorConverter.ConvertFromString(player[3].Color))));


                Settings.RowNumber = (byte)environment.RowNumber;
                Settings.ColumnNumber = (byte)environment.ColumnNumber;
                Settings.Diagonal = environment.Diagonal;
                Settings.MaxValueClick = environment.MaxValueClick;
                Settings.HiddenFieldNumbers = environment.HiddenFieldNumbers;

                WindowController.setNewGameSurface((byte)environment.PlayerNumber, players);
            }           
        }        
    }
}
