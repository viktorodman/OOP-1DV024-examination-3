using System;
using System.Collections.Generic;

namespace TwentyOne
{
    /// <summary>
    /// Represents a discard pile
    /// </summary>
    public class DiscardPile
    {
        /// <summary>
        /// A list of cards
        /// </summary>
        /// <typeparam name="Card"></typeparam>
        /// <returns></returns>
        private List<Card> _cards = new List<Card>(Constants.DeckMaxCapacity);

        /// <summary>
        /// Adds a list of cards to the discard pile
        /// </summary>
        /// <param name="cards"></param>
        public void AddCards(List<Card> cards)
        {
            _cards.AddRange(cards);
        }

        /// <summary>
        /// Removes and returns the cards from the discard pile
        /// </summary>
        /// <returns>A list of cards</returns>
        public List<Card> EmptyDiscardPile()
       {
           List<Card> cardsInDiscardPile = new List<Card>();
           cardsInDiscardPile.AddRange(_cards);
           _cards.Clear();

           return cardsInDiscardPile;
       }

    }
}