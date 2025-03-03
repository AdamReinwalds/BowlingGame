using BowlingGame.scoreGenerator;
using static BowlingGame.GameManager;
using Microsoft.Extensions.DependencyInjection;
using BowlingGame.Core;
using BowlingGame.Factory;
//using Microsoft.Extensions.Logging;
using BowlingGame.data;



namespace BowlingGame
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<ILogger, ConsoleLogger>()
                .AddTransient<IScoreGenerator, RandomScoreGenerator>()
                .AddTransient<PlayerFactory>()
                .AddTransient<GameManager>()
                .AddDbContext<MyDbContext>()
                .AddTransient<Game>()
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILogger>() ??
                throw new InvalidOperationException("Logger is not available.");
            var playerFactory = serviceProvider.GetRequiredService<PlayerFactory>();
            var gameManager = serviceProvider.GetRequiredService<GameManager>();

            do
            {
                Console.WriteLine("Type in name of player1: ");
                var player1Name = Console.ReadLine() ?? "";
                Console.WriteLine("Type in name of player2: ");
                var player2Name = Console.ReadLine() ?? "";

                var player1 = playerFactory.CreatePlayer(player1Name);
                var player2 = playerFactory.CreatePlayer(player2Name);

                gameManager.SetPlayers(player1, player2);
                logger.Log("Game started!");
                GameResult result = gameManager.StartGame();
                if (result == GameResult.Tie)
                {
                    Console.WriteLine("It's a tie!🎳");
                }
                else if (result == GameResult.Player1Win)
                {
                    Console.WriteLine(player1.Name + " wins! 🎳");
                }
                else
                {
                    Console.WriteLine(player2.Name + " wins!🎳");
                }
                logger.Log("Results has been saved to the database.");
                Console.WriteLine("Play again? (Y/N)");
            }
            while (Console.ReadLine().ToUpper() == "Y");
            





        }
    }
}
