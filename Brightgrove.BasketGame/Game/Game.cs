using Brightgrove.BasketGame.Players;
using Brightgrove.BasketGame.Players.Base;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Brightgrove.BasketGame.Game
{
    public class Game
    {
        private object lockObject = new object();

        private List<Player> players = new List<Player>();

        private Basket basket = new Basket();

        private History.History history = new History.History();

        private CancellationTokenSource cancellationTokenSource;

        public void RegisterPlayer(string name, PlayerType type)
        {
            Player player;
            switch (type)
            {
                case PlayerType.Random:
                    player = new RandomPlayer(name);
                    break;
                case PlayerType.Memory:
                    player = new MemoryPlayer(name);
                    break;
                case PlayerType.Thorough:
                    player = new ThoroughPlayer(name);
                    break;
                case PlayerType.Cheater:
                    player = new CheaterPlayer(name, history);
                    break;
                case PlayerType.ThoroughCheater:
                    player = new ThoroughCheaterPlayer(name, history);
                    break;
                default:
                    throw new NotSupportedException($"Player type '{type}' is not supported.");
            }

            players.Add(player);
        }

        public void Start()
        {
            Console.WriteLine($"Starting a game...");

            cancellationTokenSource = new CancellationTokenSource();
            var tasks = new List<Task>();

            foreach (Player player in players)
            {
                tasks.Add(Task.Run(() => ProcessPlayer(player, cancellationTokenSource), cancellationTokenSource.Token));
            }

            tasks.Add(Task.Run(() => StopGameWhenTimeIsOut(cancellationTokenSource), cancellationTokenSource.Token));

            try
            {
                Task.WaitAll(tasks.ToArray());
            }
            catch (Exception e) when ((e.InnerException is TaskCanceledException))
            {
                // ingore
            }
            catch (Exception e)
            {
                Console.Error.WriteLine($"Exception happened: " + e.ToString());
            }
        }

        private void ProcessPlayer(Player player, CancellationTokenSource cancellationTokenSource)
        {
            while (!cancellationTokenSource.IsCancellationRequested)
            {
                int difference;
                lock (lockObject)
                {
                    if (cancellationTokenSource.IsCancellationRequested)
                    {
                        return;
                    }

                    int guess = player.Guess();
                    difference = Math.Abs(basket.Weight - guess);
                    Console.WriteLine($"Player: {player}. Guess: {guess}. Difference: {difference}");

                    history.AddItem(player, guess);

                    if (difference == 0)
                    {
                        Console.WriteLine($"Player {player} won!. Basket size: {basket.Weight}");
                        cancellationTokenSource.Cancel();
                        return;
                    }

                    if (history.Length >= Constants.MaxGameAttemptsAmount)
                    {
                        Console.WriteLine($"Max attempts amount of {Constants.MaxGameAttemptsAmount} has been exceeded.");
                        cancellationTokenSource.Cancel();
                        return;
                    }
                }

                cancellationTokenSource.Token.WaitHandle.WaitOne(difference);
            }
        }

        private void StopGameWhenTimeIsOut(CancellationTokenSource cancellationTokenSource)
        {
            cancellationTokenSource.Token.WaitHandle.WaitOne(Constants.MaxGameDurationInMilliseconds);

            lock (lockObject)
            {
                if (!cancellationTokenSource.IsCancellationRequested)
                {
                    Console.WriteLine($"Time is out. {Constants.MaxGameDurationInMilliseconds} ms elasped.");
                    cancellationTokenSource.Cancel();
                }
            }
        }
    }
}