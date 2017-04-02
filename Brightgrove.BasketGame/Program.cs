namespace Brightgrove.BasketGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game.Game();

            game.RegisterPlayer("Memory", Players.Base.PlayerType.Memory);
            game.RegisterPlayer("Thorough", Players.Base.PlayerType.Thorough);
            game.RegisterPlayer("Random", Players.Base.PlayerType.Random);

            game.Start();
        }
    }
}
