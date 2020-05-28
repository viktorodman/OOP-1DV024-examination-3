using System;
using System.Collections.Generic;

namespace TwentyOne
{
    /// <summary>
    /// Represents a Dealer
    /// </summary>
    public class Dealer: Player
    {
        /// <summary>
        /// A deck of cards
        /// </summary>
        /// <returns></returns>
        private Deck _deck = new Deck();

        /// <summary>
        /// A discard pile
        /// </summary>
        /// <returns></returns>
        private DiscardPile _discardPile = new DiscardPile();

       /// <summary>
       /// Initializes a new instance of Dealer
       /// </summary>
       /// <param name="stopValue">The dealers stop value</param>
        public Dealer(int stopValue)
            :base("Dealer", stopValue)
        {
            // Empty
        }

        /// <summary>
        /// Deals one card each to a list of players
        /// </summary>
        /// <param name="players">A list of players</param>
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

        /// <summary>
        /// Returns the top card of the deck
        /// </summary>
        /// <returns></returns>
        public Card DealCard()
        {
            if (_deck.IsLastCard)
            {
                _deck.AddCards(_discardPile.EmptyDiscardPile());
            }

            return _deck.TopCard;
        }

        /// <summary>
        /// Collects the passed player card and the dealers card
        /// and adds them to the discard pile
        /// </summary>
        /// <param name="playerCards">A list of cards</param>
        public void CollectUsedCards(List<Card> playerCards)
        {
            _discardPile.AddCards(playerCards);
            _discardPile.AddCards(ThrowCards());
        }



         /// <summary>
        /// 
        /// Shuffles the cards in the deck
        /// 
        /// </summary>
        public void ShuffleDeck()
        {
           _deck.ShuffleCards();
        }
    }
}