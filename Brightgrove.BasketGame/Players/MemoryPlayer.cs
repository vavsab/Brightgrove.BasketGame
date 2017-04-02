using Brightgrove.BasketGame.Players.Base;
using System.Collections.Generic;

namespace Brightgrove.BasketGame.Players
{
    public class MemoryPlayer : Player
    {
        private HashSet<int> historyOfGuesses = new HashSet<int>();

        public MemoryPlayer(string name) 
            : base(name)
        {
        }

        public override int GetGuessNumber()
        {
            return PlayerHelper.GetRandomGuessAvoidingPreviousGuesses(historyOfGuesses);
        }
    }
}
