using System;
using System.Linq;
using System.Collections.Generic;

namespace TwentyOne
{
    /// <summary>
    /// Represents a game of Twenty One
    /// </summary>
    public class Game
    {
        /// <summary>
        /// A list of players
        /// </summary>
        /// <typeparam name="Player"></typeparam>
        /// <returns></returns>
        private List<Player> _players = new List<Player>(Constants.NumberOfSeats);

        /// <summary>
        /// The dealer
        /// </summary>
        private Dealer _dealer;

        /// <summary>
        /// The round winner
        /// </summary>
        private Player _roundWinner;

        /// <summary>
        /// The round loser
        /// </summary>
        private Player _roundLoser;
        
        /// <summary>
        /// Initializes a new instance of Game
        /// </summary>
        /// <param name="numberOfPlayers"></param>
        /// <param name="dealerStopValue"></param>
        /// <param name="playerStopValues"></param>
        public Game(int numberOfPlayers, int dealerStopValue, int[] playerStopValues)
        {
            _players.AddRange(Enumerable
                    .Repeat(0, numberOfPlayers)
                    .Select((x, i) => new Player($"Player {i + 1}", playerStopValues[i])));

            _dealer = new Dealer(dealerStopValue);
        }

        /// <summary>
        /// Runs a game of Twenty One
        /// </summary>
        public void RunGame()
        {
            _dealer.ShuffleDeck();
            _dealer.DealStartingCards(_players);
            foreach (Player player in _players)
            {
                PlayAgainstDealer(player, _dealer);
                GameView.DisplayResult(_roundWinner, _roundLoser);
                _dealer.CollectUsedCards(player.ThrowCards());
            }
        }

        /// <summary>
        /// A player plays a round against the dealer
        /// </summary>
        /// <param name="player"></param>
        /// <param name="dealer"></param>
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

        /// <summary>
        /// A player draws cards until the player is satisfied.
        /// </summary>
        /// <param name="player">A Player</param>
        private void DrawCards (Player player) 
        {
            do
            {

                Card drawnCard = _dealer.DealCard();
                player.ReceiveCard(drawnCard);

            } while (player.ShouldHit);
        }

        /// <summary>
        /// Compares the player and the dealers cards
        /// and determines a winner and loser
        /// </summary>
        /// <param name="player">A Player</param>
        /// <param name="dealer">A Dealer</param>
        private void CompareCards(Player player, Dealer dealer)
        {
           if (player.Score <= dealer.Score)
           {
               _roundWinner = dealer;
               _roundLoser = player;
           } else
           {
               _roundWinner = player;
               _roundLoser = dealer;
           }
        }

        /// <summary>
        /// Determines if the round has a winner
        /// </summary>
        /// <param name="player1"></param>
        /// <param name="player2"></param>
        /// <returns></returns>
        private bool RoundHasWinner(Player player1, Player player2)
        {
            bool roundHasWinner = false;

            if (player1.HasFiveCards)
            {
                _roundWinner = player1;
                _roundLoser = player2;
                roundHasWinner = true;
            }

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