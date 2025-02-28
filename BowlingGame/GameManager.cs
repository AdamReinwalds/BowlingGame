using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BowlingGame.Core;
using BowlingGame.data;

namespace BowlingGame
{
    public class GameManager
    {
        private IPlayer player1;
        private IPlayer player2;

        public GameManager(IPlayer player1, IPlayer player2) {
            this.player1 = player1;
            this.player2 = player2;
        }
        public GameResult StartGame()
        {
            int player1Score = player1.GetScore();
            int player2Score = player2.GetScore();
            Console.WriteLine($"{player1.Name} scored {player1Score} & {player2.Name} scored {player2Score}");
            var game = new Game
            {
                Player1Name = player1.Name,
                Player1Score = player1Score,
                Player2Name = player2.Name,
                Player2Score = player2Score
            };
            using (var context = new MyDbContext())
            {
                context.Add(game);
                context.SaveChanges();
            }

            if (player1Score == player2Score)
            {
                return GameResult.Tie;
            }
            else if (player1Score > player2Score)
            {
                return GameResult.Player1Win;
            }
            else
            {
                return GameResult.Player2Win;
            } 
        }
        public enum GameResult
        {
            Player1Win,
            Player2Win,
            Tie
        }

    }
}
