using System;

namespace TwentyOne
{
    /// <summary>
    /// Represents a Card
    /// </summary>
    public class Card
    {
        /// <summary>
        /// The cards rank
        /// </summary>
        public CardRank Rank {get; private set;}

        /// <summary>
        /// The cards suit
        /// </summary>
        public CardSuit Suit {get; private set;}

        /// <summary>
        /// The string representation of the cards suit
        /// </summary>
        /// <value></value>
        public string SuitSymbol
        {
            get
            {
                switch (Suit)
                {
                    case CardSuit.Clubs:
                        return "♣";
                    case CardSuit.Diamonds:
                        return "♦";
                    case CardSuit.Hearts:
                        return "♥";
                    case CardSuit.Spades:
                        return "♠";
                    default:
                        return null;
                }
            }
        }

        /// <summary>
        /// Initializes a new instance of Card
        /// </summary>
        /// <param name="rank">The cards Rank</param>
        /// <param name="suit">The cards Rank</param>        
        public Card(CardRank rank, CardSuit suit)
        {
            Rank = Enum.IsDefined(typeof(CardRank), rank) ? rank : throw new ArgumentException(nameof(rank));
            Suit = Enum.IsDefined(typeof(CardSuit), suit) ? suit : throw new ArgumentException(nameof(suit));
        }

        /// <summary>
        /// Return a string representing the card
        /// </summary>
        /// <returns></returns>
        public override string ToString() => $"{SuitSymbol} {Rank}";
    }
}