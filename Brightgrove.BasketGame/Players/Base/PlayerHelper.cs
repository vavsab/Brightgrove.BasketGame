using Brightgrove.BasketGame.Game;
using Brightgrove.BasketGame.History;
using System.Collections.Generic;

namespace Brightgrove.BasketGame.Players.Base
{
    public static class PlayerHelper
    {
        public static int GetRandomGuessAvoidingPreviousGuesses(ISet<int> historyOfGuesses)
        {
            int number;

            do
            {
                number = GameHelper.GetRandomWeight();
            }
            while (historyOfGuesses.Contains(number));

            historyOfGuesses.Add(number);

            return number;
        }

        public static int GetRandomGuessAvoidingOtherPlayersGuesses(Player player, IHistory history)
        {
            int number;
            HashSet<int> otherPlayersGuessesSet = history.GetOtherPlayersGuessesSet(player);

            do
            {
                number = GameHelper.GetRandomWeight();
            }
            while (otherPlayersGuessesSet.Contains(number));

            return number;
        }

        public static int GetNextNumber(ref int currentNumber)
        {
            int numberToReturn = currentNumber;
            currentNumber++;

            return numberToReturn;
        }

        public static int GetNextNumberAvoidingOtherPlayersGuesses(Player player, IHistory history, ref int currentNumber)
        {
            int numberToReturn;
            HashSet<int> otherPlayersGuessesSet = history.GetOtherPlayersGuessesSet(player);

            do
            {
                numberToReturn = GetNextNumber(ref currentNumber);
            }
            while (otherPlayersGuessesSet.Contains(numberToReturn));

            return numberToReturn;
        }
    }
}
