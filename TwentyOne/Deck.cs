using System;
using System.Linq;
using System.Collections.Generic;

namespace TwentyOne
{
    /// <summary>
    /// Represents a deck
    /// </summary>
    public class Deck
    {   
        

        /// <summary>
        /// A list of cards
        /// </summary>
        /// <typeparam name="Card"></typeparam>
        /// <returns></returns>
        private List<Card> _cards = new List<Card>(Constants.DeckMaxCapacity);
        
        /// <summary>
        /// The number of cards in the deck
        /// </summary>
        /// <value></value>
        public int DeckCount 
        {
            get => _cards.Count;
        }

        public bool IsLastCard
        {
            get => _cards.Count == 1;
        }

        public Card TopCard
        {
            get
            {
                if (IsLastCard)
                {
                    throw new IndexOutOfRangeException("Cant draw the last card");
                }

                Card topCard = _cards[0];
                _cards.RemoveAt(0);

                return topCard;
            }
        }

        public List<Card> Cards {get;}

        /// <summary>
        /// Initializes a new instance of Deck
        /// </summary>
        public Deck()
        {
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                {
                    _cards.Add(new Card(rank, suit));
                }
            }
        }


         public void AddCards(List<Card> cards)
        {
            _cards.AddRange(cards);
        }

        

        /// <summary>
        /// Returns the deck as a string
        /// </summary>
        /// <returns>String</returns>
        public override string ToString() => string.Join("\n", _cards);
    }
}