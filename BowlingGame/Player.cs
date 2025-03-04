using BowlingGame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame
{
    public class Player : IPlayer
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public Player(string name, IScoreGenerator scoreGenerator)
        {
            this.Name = name;
            this.Score = scoreGenerator.GenerateScore();
        }
        public int GetScore() => Score;
    }
}
