using Brightgrove.BasketGame.Players.Base;

namespace Brightgrove.BasketGame.Players
{
    public class CheaterPlayer : HistoryAwarePlayer
    {
        public CheaterPlayer(string name, IHistory history) 
            : base(name, history)
        {
        }

        public override int GetGuessNumber()
        {
            return PlayerHelper.GetRandomGuessAvoidingOtherPlayersGuesses(this, History);
        }
    }
}
