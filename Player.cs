using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media;

namespace _4Game
{
    public class Player
    {        
        public string Name { get; }

        public int Score { get; set; }

        public Brush Color { get; }

        public Label scoreLabel { get; set; }

        public Player(string name, Brush color, int score = 0)
        {
            Name = name;
            Score = score;
            Color = color;
        }

        public void addScore()
        {
            Score += Constants.MAXFIELDVALUE;
        }
    }
}
