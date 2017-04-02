using System;

namespace Brightgrove.BasketGame.Game
{
    public static class GameHelper
    {
        private static readonly Random random = new Random(DateTime.Now.Millisecond);

        public static int GetRandomWeight()
        {
            return random.Next(Constants.MinBasketWeight, Constants.MaxBasketWeight + 1); // +1 because upper bound is exclusive
        }
    }
}
