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

        private List<int> _cardValues = new List<int>(Constants.HandMaxCapacity);

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

       public void AddCard(Card card)
       {
           if(_cards.Count == 5)
           {
               throw new IndexOutOfRangeException("Hand cant have more than five items");
           }
            _cards.Add(card);
            _cardValues.Add((int)card.Rank);
       }

       private int SumOfCardValues() => _cardValues.Aggregate(0, (acc, cardValue) => acc + cardValue);



       public override string ToString() => string.Join(", ", _cards);
    }
}