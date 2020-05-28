using System;
using System.Linq;
using System.Collections.Generic;

namespace TwentyOne
{
    /// <summary>
    /// Represents a Hand
    /// </summary>
    public class Hand
    {
        /// <summary>
        /// A list of cards
        /// </summary>
        /// <typeparam name="Card"></typeparam>
        /// <returns></returns>
        private List<Card> _cards = new List<Card>(Constants.HandMaxCapacity);

        /// <summary>
        /// Represents the values of the cards on the hand
        /// </summary>
        /// <typeparam name="int"></typeparam>
        /// <returns></returns>
        private List<int> _cardValues = new List<int>(Constants.HandMaxCapacity);

        /// <summary>
        /// The value of card on the hand
        /// </summary>
        /// <value></value>
        public int HandValue
        {
            get
            {
               

               if (SumOfCardValues() > Constants.BustValue)
               {
                   for (int i = 0; i < _cards.Count; i++)
                   {
                       if (_cards[i].Rank == CardRank.Ace)
                       {
                           _cardValues[i] = 1;
                       }
                       if (SumOfCardValues() <= Constants.BustValue)
                       {
                           break;
                       }
                   }
               }

               return SumOfCardValues();
            }
        }

    
        /// <summary>
        /// Checks if the hand is full
        /// </summary>
        /// <value></value>
        public bool IsFull
        {
            get => _cards.Count == Constants.HandMaxCapacity;
        }


        /// <summary>
        /// Adds a card to the hand
        /// </summary>
        /// <param name="card"></param>
       public void AddCard(Card card)
       {
           if(IsFull)
           {
               throw new IndexOutOfRangeException("Hand cant have more than five items");
           }
            _cards.Add(card);
            _cardValues.Add((int)card.Rank);
       }

        /// <summary>
        /// Removes and returns the card on the hand
        /// </summary>
        /// <returns></returns>
       public List<Card> EmptyHand()
       {
            List<Card> cardsOnHand = new List<Card>();
            cardsOnHand.AddRange(_cards);
            _cards.Clear();
            _cardValues.Clear();

           return cardsOnHand;
       }

        /// <summary>
        /// Returns the sum of the card values on the hand.
        /// </summary>
        /// <returns></returns>
       private int SumOfCardValues() => _cardValues.Aggregate(0, (acc, cardValue) => acc + cardValue);


        /// <summary>
        /// A string representing the card on the hand
        /// </summary>
        /// <returns></returns>
       public override string ToString() => string.Join(", ", _cards);
    }
}