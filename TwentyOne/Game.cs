using System;
using System.Linq;
using System.Collections.Generic;

namespace TwentyOne
{
    public class Game
    {
        
        private List<Player> _players = new List<Player>(Constants.NumberOfSeats);

        private Dealer _dealer = new Dealer(15);

        private Player _roundWinner;

        private Player _roundLoser;

        private GameView _gameView = new GameView();


        public Game(int numberOfPlayers)
        {
            _players.AddRange(Enumerable
                    .Repeat(0, numberOfPlayers)
                    .Select((x, i) => new Player($"Player {i + 1}", 15)));
        }

        public void RunGame()
        {
            _dealer.ShuffleDeck();
            _dealer.DealStartingCards(_players);
            foreach (Player player in _players)
            {
                PlayAgainstDealer(player, _dealer);
                _gameView.DisplayResult(_roundWinner, _roundLoser);
                _dealer.CollectUsedCards(player.ThrowCards());
            }
        }

        private void PlayAgainstDealer (Player player, Dealer dealer)
        {
            DrawCards(player);

            if (!RoundHasWinner(player, dealer))
            {
                dealer.DrawCards();

                if (!RoundHasWinner(dealer, player))
                {
                    CompareCards(player, dealer);
                }
            }
        }


        private void DrawCards (Player player) 
        {
            while (player.ShouldHit)
            {
                Card drawnCard = _dealer.DealCard();
                player.ReceiveCard(drawnCard);
            }
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
    }
}