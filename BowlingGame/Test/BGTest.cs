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
            TestPlayer player1 = new (100, "Player1Test");
            TestPlayer player2 = new (5, "Player2Test");
            GameManager gameManager = new (player1, player2);
            GameManager.GameResult result = gameManager.StartGame();
            Assert.That(GameManager.GameResult.Player1Win == result);
        }
        [Test]
        public void TestPlayer2Win()
        {
            TestPlayer player1 = new (0, "Player1Test");
            TestPlayer player2 = new (10, "Player2Test");
            GameManager gameManager = new (player1, player2);
            GameManager.GameResult result = gameManager.StartGame();
            Assert.That(GameManager.GameResult.Player2Win == resul        }
        [Test]
        public void TestTie()
        {
            TestPlayer player1 = new (10, "Player1Test");
            TestPlayer player2 = new (10, "Player2Test");
            GameManager gameManager = new (player1, player2);
            GameManager.GameResult result = gameManager.StartGame();
            Assert.That(GameManager.GameResult.Tie == result);
        }
    }
}
