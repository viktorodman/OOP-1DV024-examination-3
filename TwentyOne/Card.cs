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

        public string CardSymbol
        {
            get
            {
                switch (Suit)
                {
                    case CardSuit.Clubs:
                        return "Clubs";
                    case CardSuit.Diamonds:
                        return "Diamonds";
                    case CardSuit.Hearts:
                        return "Hearts";
                    case CardSuit.Spades:
                        return "Spades";
                    default:
                        return null;
                }
            }
        }
        
        public Card(CardRank rank, CardSuit suit)
        {
            Rank = rank;
            Suit = suit;
        }

        public override string ToString() => $"{Rank} {CardSymbol}";
    }
}