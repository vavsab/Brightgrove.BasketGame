using Brightgrove.BasketGame.Game;
using Brightgrove.BasketGame.Players.Base;

namespace Brightgrove.BasketGame.Players
{
    public class ThoroughCheaterPlayer : HistoryAwarePlayer
    {
        private int currentNumber = Constants.MinBasketWeight;

        public ThoroughCheaterPlayer(string name, IHistory history) 
            : base(name, history)
        {
        }

        public override int GetGuessNumber()
        {
            return PlayerHelper.GetNextNumberAvoidingOtherPlayersGuesses(this, History, ref currentNumber);
        }
    }
}
