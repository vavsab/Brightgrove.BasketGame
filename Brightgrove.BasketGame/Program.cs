using Brightgrove.BasketGame.Game;
using Brightgrove.BasketGame.Game.Config;
using System;
using System.IO;
using System.Xml.Serialization;

namespace Brightgrove.BasketGame
{
    class Program
    {
        static void Main(string[] args)
        {
            var game = new Game.Game();

            Console.Write("Speficy config file: ");

            string filePath = Console.ReadLine();

            var serializer = new XmlSerializer(typeof(GameConfig));
            var gameConfig = (GameConfig)serializer.Deserialize(File.OpenRead(filePath));

            int playersCount = gameConfig.Players.Count;
            if (playersCount < Constants.MinPlayersAmount 
                || playersCount > Constants.MaxPlayersAmount)
            {
                Console.Error.Write($"Invalid players count of {playersCount}. Players count must lay in range [{Constants.MinPlayersAmount},{Constants.MaxPlayersAmount}]");
            }

            foreach (PlayerConfig playerConfig in gameConfig.Players)
            {
                game.RegisterPlayer(playerConfig.Name, playerConfig.Type);
            }

            game.Start();
        }
    }
}
