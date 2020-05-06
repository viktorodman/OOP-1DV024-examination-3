using System;
using System.Collections.Generic;

namespace TwentyOne
{
    public class DiscardPile
    {
        private List<Card> _cards = new List<Card>(Constants.DeckMaxCapacity);


        public int DeckCount 
        {
            get => _cards.Count;
        }

        public void AddCards(List<Card> cards)
        {
            _cards.AddRange(cards);
        }


        public List<Card> EmptyDiscardPile()
       {
           List<Card> cardsInDiscardPile = new List<Card>();
           cardsInDiscardPile.AddRange(_cards);
           _cards.Clear();

           return cardsInDiscardPile;
       }

    }
}