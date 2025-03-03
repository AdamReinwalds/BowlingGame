using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingGame.Core;

namespace BowlingGame.test
{

    public class TestPlayer : IPlayer
    {
        public string Name { get; set; }
        public int Score { get; set; }

        public TestPlayer(string name, int score)
        {
            Name = name;
            Score = score;
        }
        public int GetScore()
        {
            return Score;
        }
    }
}
