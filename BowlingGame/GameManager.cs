using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using BowlingGame.Core;
using BowlingGame.data;
using BowlingGame.Factory;
using BowlingGame.scoreGenerator;
using Microsoft.Extensions.DependencyInjection;

namespace BowlingGame
{
    public class GameManager
    {
        private IPlayer? player1;
        private IPlayer? player2;
        private readonly SingletonLogger _logger = SingletonLogger.Instance;

        public void SetPlayers(IPlayer player1, IPlayer player2)
        {
            this.player1 = player1;
            this.player2 = player2;
        }
        public void Gameloop()
        {
            var serviceProvider = new ServiceCollection()
                .AddTransient<IScoreGenerator, RandomScoreGenerator>()
                .AddTransient<PlayerFactory>()
                .AddDbContext<MyDbContext>()
                .AddTransient<Game>()
                .BuildServiceProvider();

            var playerFactory = serviceProvider.GetRequiredService<PlayerFactory>();

            do
            {
                Console.WriteLine("Type in name of player1: ");
                var player1Name = Console.ReadLine() ?? "";
                Console.WriteLine("Type in name of player2: ");
                var player2Name = Console.ReadLine() ?? "";

                var player1 = playerFactory.CreatePlayer(player1Name);
                var player2 = playerFactory.CreatePlayer(player2Name);

                SetPlayers(player1, player2);
                Console.WriteLine("Game started!");
                GameResult result = StartGame();
                if (result == GameResult.Tie)
                {
                    Console.WriteLine("It's a tie!🎳");
                }
                else if (result == GameResult.Player1Win)
                {
                    Console.WriteLine(player1.Name + " wins!🎳");
                }
                else
                {
                    Console.WriteLine(player2.Name + " wins!🎳");
                }
                Console.WriteLine("Play again? (Y/N)");
            }
            while (Console.ReadLine().ToUpper() == "Y");
        }
        private GameResult StartGame()
        {
            if (player1 == null || player2 == null)
            {
                throw new InvalidOperationException("Players not added");
            }
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
            _logger.Log("Results has been saved to the database.");

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
