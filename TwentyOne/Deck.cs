using System;
using System.Linq;
using System.Collections.Generic;

namespace TwentyOne
{
    public class Deck
    {
        private readonly Random random = new Random();
        private List<Card> _cards = new List<Card>(52);
        



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

        public void Shuffle()
        {
            int n = _cards.Count;
            while (n > 1)
            {
                n--;
                int k = random.Next(n + 1);
                Card value = _cards[k];
                _cards[k] = _cards[n];
                _cards[n] = value;
            }
        }





        public override string ToString() => string.Join("\n", _cards);
    }
}