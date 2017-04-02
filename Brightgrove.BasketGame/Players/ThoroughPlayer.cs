using Brightgrove.BasketGame.Players.Base;

namespace Brightgrove.BasketGame.Players
{
    public class ThoroughPlayer : Player
    {
        private int currentNumber = Constants.MinBasketWeight;

        public ThoroughPlayer(string name) 
            : base(name)
        {
        }

        public override int GetGuessNumber()
        {
            return PlayerHelper.GetNextNumber(ref currentNumber);
        }
    }
}
