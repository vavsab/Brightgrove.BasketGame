using Brightgrove.BasketGame.Players.Base;

namespace Brightgrove.BasketGame
{
    public struct HistoryItem
    {
        public HistoryItem(Player player, int guess)
        {
            Player = player;
            Guess = guess;
        }

        public Player Player { get; }

        public int Guess { get; }
    }
}
