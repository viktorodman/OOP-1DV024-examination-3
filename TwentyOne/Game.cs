using System;
using System.Linq;
using System.Collections.Generic;

namespace TwentyOne
{
    public class Game
    {
        
        private List<Player> _players = new List<Player>(Constants.NumberOfSeats);

        private Deck _deck = new Deck();

        private DiscardPile _discardPile = new DiscardPile();

        private Dealer _dealer = new Dealer("Dealer", 15);

        private Player _roundWinner;

        private Player _roundLoser;


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
            /* PlayAgainstDealer(_players[0], _dealer); */
            

            foreach (Player player in _players)
            {
                PlayAgainstDealer(player, _dealer);
            }

            
        }

        private void PlayAgainstDealer (Player player, Dealer dealer)
        {
            DrawCards(player);

            if (!RoundHasWinner(player, dealer))
            {
                DrawCards(dealer);

                if (!RoundHasWinner(dealer, player))
                {
                    CompareCards(player, dealer);
                }
            }



            System.Console.WriteLine($"Winner: {_roundWinner} Score: {_roundWinner.Score}");
            System.Console.WriteLine($"Loser: {_roundLoser} Score: {_roundLoser.Score}");

            _discardPile.AddCards(player.ThrowCards());
            _discardPile.AddCards(dealer.ThrowCards());

            System.Console.WriteLine($"Number in Deck {_deck.DeckCount}");
            System.Console.WriteLine($"Number in Discard {_discardPile.DeckCount}");
        }


        private void DrawCards (Player player) 
        {
            do
            {
                if (!_deck.IsLastCard)
                {
                    player.Hit(_deck.DrawCard());
                } else {
                    System.Console.WriteLine("Deck empty");
                }
            } while (!player.IsDone);
        }

        private void CompareCards(Player player, Dealer dealer)
        {
           if (player.Score == dealer.Score || player.Score < dealer.Score)
           {
               _roundWinner = dealer;
               _roundLoser = player;
           } else
           {
               _roundWinner = player;
               _roundLoser = dealer;
           }
        }

        private bool RoundHasWinner(Player player1, Player player2)
        {
            bool roundHasWinner = false;

            if (player1.HasTwentyOne)
            {
                _roundWinner = player1;
                _roundLoser = player2;
                roundHasWinner = true;
            }

            if (player1.IsBusted)
            {
                _roundWinner = player2;
                _roundLoser = player1;
                roundHasWinner = true;
            }

            return roundHasWinner;
        }

        private void PrepareNewRound(Player player, Dealer dealer)
        {
            
        }
        
        private void FirstRound() => _players.ForEach(player => player.Hit(_deck.DrawCard()));
        
    }
}