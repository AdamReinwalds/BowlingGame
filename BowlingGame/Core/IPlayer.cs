using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.Core
{
    public interface IPlayer
    {
        string Name { get; set; }
        int GetScore();

    }
}
