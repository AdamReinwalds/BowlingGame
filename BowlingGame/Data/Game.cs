using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingGame.data
{
    public class Game
    {
        public int Id { get; set; }
        public string? Player1Name { get; set; }
        public int Player1Score { get; set; }
        public string? Player2Name { get; set; }
        public int Player2Score { get; set; }
        public string DatePlayed { get; set; } = DateTime.Now.ToString("yyyy-MM-dd");
        public Game() { }

    }
}
