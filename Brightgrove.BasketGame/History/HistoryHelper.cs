using Brightgrove.BasketGame.Players.Base;
using System.Collections.Generic;
using System.Linq;

namespace Brightgrove.BasketGame.History
{
    public static class HistoryHelper
    {
        public static HashSet<int> GetOtherPlayersGuessesSet(this IHistory history, Player currentPlayer)
        {
            return new HashSet<int>(history.Items.Where(i => i.Player != currentPlayer).Select(i => i.Guess));
        }
    }
}
