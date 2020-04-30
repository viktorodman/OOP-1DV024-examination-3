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

        public int HandValue
        {
            get
            {
               int handSum = _cards.Aggregate(0, (acc, card) => acc + card.CardValue);

               return 
            }
        }

       public void AddCard(Card card)
       {
           if(_cards.Count == 5)
           {
               throw new IndexOutOfRangeException("Hand cant have more than five items");
           }
            _cards.Add(card);
       }



       public override string ToString() => string.Join(", ", _cards);
    }
}