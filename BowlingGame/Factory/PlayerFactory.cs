using BowlingGame.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingGame.data;

namespace BowlingGame.Factory
{
    public class PlayerFactory
    {
        private readonly IScoreGenerator _scoreGenerator;
        public PlayerFactory(IScoreGenerator scoreGenerator)
        {
            _scoreGenerator = scoreGenerator;
        }
        public IPlayer CreatePlayer(string name)
        {
            var player = new Player(name, _scoreGenerator);

            return player;
        }
    }
}
