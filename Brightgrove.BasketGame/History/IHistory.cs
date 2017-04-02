using System.Collections.Generic;

namespace Brightgrove.BasketGame
{
    public interface IHistory
    {
        IEnumerable<HistoryItem> Items { get; }
    }
}
