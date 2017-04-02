using Brightgrove.BasketGame.Game;
using Brightgrove.BasketGame.Players.Base;

namespace Brightgrove.BasketGame.Players
{
    public class RandomPlayer : Player
    {
        public RandomPlayer(string name) 
            : base(name)
        {
        }

        public override int GetGuessNumber()
        {
            return GameHelper.GetRandomWeight();
        }
    }
}
