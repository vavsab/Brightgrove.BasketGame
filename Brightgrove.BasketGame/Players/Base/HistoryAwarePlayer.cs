namespace Brightgrove.BasketGame.Players.Base
{
    public abstract class HistoryAwarePlayer : Player
    {
        public HistoryAwarePlayer(string name, IHistory history) 
            : base(name)
        {
            History = history;
        }

        protected IHistory History { get; }
    }
}
