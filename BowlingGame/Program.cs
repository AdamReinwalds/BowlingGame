
namespace BowlingGame
{ 
    internal class Program
    {
        static void Main(string[] args)
        {
            GameManager gameManager = new();
            gameManager.Gameloop();
        }
    }
}
