using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4Game
{
    class Player
    {
        private string name;
        private int score;
        private byte color;

        public Player(string name, byte color, int score = 0)
        {
            this.name = name;
            this.score = score;
            this.color = color;
        }

        public string Name { get; }

        public int Score { get; set; }

        public byte Color { get; }

        public void addScore()
        {
            score += Constants.MAXFIELDVALUE;
        }
    }
}
