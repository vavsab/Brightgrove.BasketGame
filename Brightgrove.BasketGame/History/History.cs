using Brightgrove.BasketGame.Players.Base;
using System.Collections.Generic;

namespace Brightgrove.BasketGame.History
{
    public class History : IHistory
    {
        private List<HistoryItem> items = new List<HistoryItem>();

        public IEnumerable<HistoryItem> Items => items;

        public int Length => items.Count;

        public void AddItem(Player player, int guess)
        {
            items.Add(new HistoryItem(player, guess));
        }
    }
}
