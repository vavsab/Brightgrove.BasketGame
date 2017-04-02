namespace Brightgrove.BasketGame.Players.Base
{
    public abstract class Player
    {
        public Player(string name)
        {
            Name = name;
        }

        public string Name { get; }

        public int Attempts { get; private set; }

        public int Guess()
        {
            Attempts++;
            return GetGuessNumber();
        }

        public abstract int GetGuessNumber();

        public override string ToString() => $"{Name}";
    }
}
