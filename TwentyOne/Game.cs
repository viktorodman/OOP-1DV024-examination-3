using System;
using System.Linq;
using System.Collections.Generic;

namespace TwentyOne
{
    public class Game
    {
        
        private List<Player> _players = new List<Player>(Constants.NumberOfSeats);

        private Deck _deck = new Deck();

        public Game(int numberOfPlayers)
        {
            _players.AddRange(Enumerable
                    .Repeat(0, numberOfPlayers)
                    .Select((x, i) => new Player($"Player {i + 1}", 15)));
            
            _deck.Shuffle();
        }

        public void RunGame()
        {
            FirstRound();
            PlayAgainstDealer(_players[0]);


            /* foreach (Player player in _players)
            {
                System.Console.WriteLine(player.ToString());
            } */

            System.Console.WriteLine(_players[0]);
            System.Console.WriteLine(_players[0].HandCount());
        }

        private void PlayAgainstDealer (Player player)
        {
            do
            {
                if (!_deck.IsLastCard)
            {
                player.Hit(_deck.DrawCard());
            } else {
                System.Console.WriteLine("Deck empty");
            }
            } while (player.IsDone);
        }

        

        private void FirstRound() => _players.ForEach(player => player.Hit(_deck.DrawCard()));
        
    }
}