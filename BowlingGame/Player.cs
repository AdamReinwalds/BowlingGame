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
        public int _score { get; set; }
        //private readonly int _score;
        private readonly IScoreGenerator _scoreGenerator;

        public Player(string name, IScoreGenerator scoreGenerator)
        {
            Name = name;
            _scoreGenerator = scoreGenerator;
            _score = _scoreGenerator.GenerateScore();
        }
        public int GetScore() => _score;
    }
}
