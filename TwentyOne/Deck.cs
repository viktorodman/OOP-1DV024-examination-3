using System;
using System.Linq;
using System.Collections.Generic;

namespace TwentyOne
{
    public class Deck
    {
        private List<Card> Cards = new List<Card>(52);


        public Deck()
        {
            foreach (CardSuit suit in Enum.GetValues(typeof(CardSuit)))
            {
                foreach (CardRank rank in Enum.GetValues(typeof(CardRank)))
                {
                    Cards.Add(new Card(rank, suit));
                }
            }
        }


        public override string ToString() 
        { 
            string str = "";

            Cards.ForEach(card => str += card.ToString() + "\n");

            return str; 
        }
    }
}