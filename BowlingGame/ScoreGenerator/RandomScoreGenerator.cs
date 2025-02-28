using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingGame.Core;

namespace BowlingGame.scoreGenerator
{
    public class RandomScoreGenerator : IScoreGenerator
    {
        private static readonly Random rng = new Random();
        public int GenerateScore()
        {
            return rng.Next(0, 301);
        }
    }
}
