using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace BowlingGame.test
{
    public class BGTest
    {
        [Test]
        public void TestPlayer1Win()
        {
            TestPlayer player1 = new ("Player1Test", 50);
            TestPlayer player2 = new ("Player2Test", 5);
            GameManager gameManager = new GameManager();
            gameManager.SetPlayers(player1, player2);
            GameManager.GameResult result = gameManager.StartGame();
            Assert.That(GameManager.GameResult.Player1Win == result);
        }
        [Test]
        public void TestPlayer2Win()
        {
            TestPlayer player1 = new ("Player1Test", 0);
            TestPlayer player2 = new ("Player2Test", 50);
            GameManager gameManager = new GameManager();
            gameManager.SetPlayers(player1, player2);
            GameManager.GameResult result = gameManager.StartGame();
            Assert.That(GameManager.GameResult.Player2Win == result);        
        }
        [Test]
        public void TestTie()
        {
            TestPlayer player1 = new ("Player1Test", 10);
            TestPlayer player2 = new ("Player2Test", 10);
            GameManager gameManager = new GameManager();
            gameManager.SetPlayers(player1, player2);
            GameManager.GameResult result = gameManager.StartGame();
            Assert.That(GameManager.GameResult.Tie == result);
        }
    }
}
