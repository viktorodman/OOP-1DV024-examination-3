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
        /// Instantiate random number generator
        /// </summary>
        /// <returns></returns>
        private readonly Random _random = new Random();

        /// <summary>
        /// A list of cards
        /// </summary>
        /// <typeparam name="Card"></typeparam>
        /// <returns></returns>
        private List<Card> _cards = new List<Card>(Constants.DeckMaxCapacity);
        
       
        /// <summary>
        /// Returns true if its only 1 card left in the deck
        /// </summary>
        /// <value>True or false</value>
        public bool IsLastCard
        {
            get => _cards.Count == 1;
        }

        /// <summary>
        /// Returns the top card of the deck
        /// </summary>
        /// <value></value>
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

        /// <summary>
        /// Adds a list of cards to the deck
        /// </summary>
        /// <param name="cards"></param>
         public void AddCards(List<Card> cards)
        {
            _cards.AddRange(cards);
        }

        /// <summary>
        /// Fisher Yates shuffle
        /// 
        /// Shuffles the cards in the deck
        /// 
        /// Source: https://stackoverflow.com/questions/273313/randomize-a-listt/1262619#1262619
        /// 
        /// </summary>
        public void ShuffleCards()
        {
            int n = _cards.Count;
            while (n > 1)
            {
                n--;
                int k = _random.Next(n + 1);
                Card value = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = value;
            }
        }

        

        /// <summary>
        /// Returns the deck as a string
        /// </summary>
        /// <returns>String</returns>
        public override string ToString() => string.Join("\n", _cards);
    }
}