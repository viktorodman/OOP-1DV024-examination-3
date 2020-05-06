using System;
using System.Collections.Generic;

namespace TwentyOne
{
    
    public class Dealer: Player
    {
        private Deck _deck = new Deck();

        private DiscardPile _discardPile = new DiscardPile();

        /// <summary>
        /// Instantiate random number generator
        /// </summary>
        /// <returns></returns>
        private readonly Random _random = new Random();

        public Dealer(int stopValue)
            :base("Dealer", stopValue)
        {
            // Empty
        }


        public void DealStartingCards(List<Player> players)
        {
            players.ForEach(player => player.ReceiveCard(DealCard()));
        }


        /// <summary>
        /// Draws the top card of the deck
        /// </summary>
        /// <returns></returns>
        public void DrawCards() 
        {   
            while(ShouldHit)
            {
                if (_deck.IsLastCard)
                {
                    _deck.AddCards(_discardPile.EmptyDiscardPile());
                }
                _hand.AddCard(_deck.TopCard);
            }
        }


        public Card DealCard()
        {
            if (_deck.IsLastCard)
            {
                _deck.AddCards(_discardPile.EmptyDiscardPile());
            }

            return _deck.TopCard;
        }

        public void CollectUsedCards(List<Card> playerCards)
        {
            _discardPile.AddCards(playerCards);
            _discardPile.AddCards(ThrowCards());
        }



         /// <summary>
        /// Fisher Yates shuffle
        /// 
        /// Shuffles the cards in the deck
        /// 
        /// Source: https://stackoverflow.com/questions/273313/randomize-a-listt/1262619#1262619
        /// 
        /// </summary>
        public void ShuffleDeck()
        {
            int n = _deck.Cards.Count;
            while (n > 1)
            {
                n--;
                int k = _random.Next(n + 1);
                Card value = _deck.Cards[k];
                _deck.Cards[k] = _deck.Cards[n];
                _deck.Cards[n] = value;
            }
        }
    }
}