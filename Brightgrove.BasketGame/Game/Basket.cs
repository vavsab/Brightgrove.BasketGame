namespace Brightgrove.BasketGame.Game
{
    public class Basket
    {
        public Basket()
        {
            Weight = GameHelper.GetRandomWeight();
        }

        public int Weight { get; }
    }
}
